using DataTransfer.Domain.Entities.Temp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string code = "FZ-LNCE2 (F)A221111";
            //var a=code.Replace("FZ-LNCE", "").Substring(0, 1);
            //Console.WriteLine(a);

            //List<int> hours = new List<int>() { 33, 66, 99, 132, 165, 198, 231, 264, 297, 330 };
            //hours.ForEach(e=> {
            //    Console.WriteLine();
            //});
            string temp = $"{DateTime.Now.ToString("yyyy年MM月dd日")}";

            string schedules = "[{\"ClassDate\":null,\"Week\":1,\"WeekName\":\"周一\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":2,\"WeekName\":\"周二\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":3,\"WeekName\":\"周三\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":4,\"WeekName\":\"周四\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":5,\"WeekName\":\"周五\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"}]";
            List<SimpleClassSchedule> scss = new List<SimpleClassSchedule>();
            scss = JsonConvert.DeserializeObject<List<SimpleClassSchedule>>(schedules);
            StringBuilder scheduleBuilder = new StringBuilder();
            foreach (var scs in scss)
            {
                var beginTime = Convert.ToDateTime(scs.BeginTime);
                var endTime = Convert.ToDateTime(scs.EndTime);
                var currentTime = beginTime.AddHours(1);
                while (true)
                {
                    scheduleBuilder.Append($"{scs.Week}*{beginTime.ToString("HH:mm")}*{currentTime.ToString("HH:mm")}&");
                    if (currentTime >= endTime)
                        break;
                    beginTime = currentTime;
                    currentTime = currentTime.AddHours(1);
                }
            }
            string result = scheduleBuilder.ToString().TrimEnd('&');
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
