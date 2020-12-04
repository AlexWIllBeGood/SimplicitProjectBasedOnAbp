using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Infrastructure.Utils
{
    public class ESHelper
    {
        public static string QueryString = "{\"query\":{\"bool\":{{0}}}}";
        public static string ESBaseUrl
        {
            get
            {
                var root = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
                .Build();
                return root.GetSection("ElasticSearchSettings:BaseLocalUrl").Value;
            }
        }
        public static string FullCreateUrl
        {
            get
            {
                return $"{ESBaseUrl}/" + "{0}/_doc";
            }
        }
        public static string FullSearchUrl
        {
            get
            {
                return $"{ESBaseUrl}/" + "{0}/_search";
            }
        }
    }
    public static class ElasticSearchsExtensions
    {
        public static void ToES<T>(this ICollection<T> targetList, string keyName)
        {

            //索引名称
            var indexName = $"index_{typeof(T).Name}";
            foreach (var t in targetList)
            {
                var response1 = HttpHelper.PostAsync<string>(
                    string.Format(ESHelper.FullSearchUrl, indexName),
                    string.Format(ESHelper.QueryString, JsonConvert.SerializeObject(new BoolClause()
                    {
                        minimum_should_match = 1,
                        must = new MustClause()
                        {
                            Musts = new List<object>() {
                                new { keyName = t.GetType().GetProperty(keyName).GetValue(t) }
                            }
                        }
                    }))
                    );
                var response2 = HttpHelper.PostAsync<string>(string.Format(ESHelper.FullCreateUrl, indexName), t);
            }
        }
    }
    public class BoolClause
    {
        public ShouldClause should { get; set; }
        public MustClause must { get; set; }
        public int minimum_should_match { get; set; }
    }
    public class ShouldClause
    {
        public List<object> Shoulds { get; set; }
    }
    public class MustClause
    {
        public List<object> Musts { get; set; }
    }
}
