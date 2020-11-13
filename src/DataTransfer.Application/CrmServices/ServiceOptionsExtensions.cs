using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Application.CrmServices
{
    /// <summary>
    /// 服务配置扩展
    /// </summary>
    public static class ServiceOptionsExtensions
    {
        /// <summary>
        /// 通用配置选项
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureOptions<TOptions>(this IServiceCollection services, IConfiguration configuration) where TOptions : class
        {
            services.AddOptions<TOptions>()
                .Configure(options =>
                {
                    configuration.Bind(options);
                });
        }
    }

    #region 业务配置项
    public class CRMOptions
    {
        public string ClassSendMTSUrl { get; set; }
        public string StudentSendMTSUrl { get; set; }
    }
    #endregion
}
