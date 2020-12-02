using DataTransfer.Domain.Entities.Temp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            //string temp = $"{DateTime.Now.ToString("yyyy年MM月dd日")}";

            //string schedules = "[{\"ClassDate\":null,\"Week\":1,\"WeekName\":\"周一\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":2,\"WeekName\":\"周二\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":3,\"WeekName\":\"周三\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":4,\"WeekName\":\"周四\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"},{\"ClassDate\":null,\"Week\":5,\"WeekName\":\"周五\",\"BeginTime\":\"08:30\",\"EndTime\":\"11:30\"}]";
            //List<SimpleClassSchedule> scss = new List<SimpleClassSchedule>();
            //scss = JsonConvert.DeserializeObject<List<SimpleClassSchedule>>(schedules);
            //StringBuilder scheduleBuilder = new StringBuilder();
            //foreach (var scs in scss)
            //{
            //    var beginTime = Convert.ToDateTime(scs.BeginTime);
            //    var endTime = Convert.ToDateTime(scs.EndTime);
            //    var currentTime = beginTime.AddHours(1);
            //    while (true)
            //    {
            //        scheduleBuilder.Append($"{scs.Week}*{beginTime.ToString("HH:mm")}*{currentTime.ToString("HH:mm")}&");
            //        if (currentTime >= endTime)
            //            break;
            //        beginTime = currentTime;
            //        currentTime = currentTime.AddHours(1);
            //    }
            //}
            //string result = scheduleBuilder.ToString().TrimEnd('&');
            //var data=
            //Console.WriteLine(result);
            var data = "[{\"Clas_Name\":\"新概念二（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (U)M200920\"},{\"Clas_Name\":\"新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)M210410\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)M220416\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (M)A210531\"},{\"Clas_Name\":\"新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE1 (W)A210512\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教中班）周内\",\"Clas_Code\":\"FZ-LNCE2 (W)A220518\"},{\"Clas_Name\":\"新概念（中外教小班）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (F)A201127\"},{\"Clas_Name\":\"新概念一（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (F)A200925\"},{\"Clas_Name\":\"新概念二（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (F)A211015\"},{\"Clas_Name\":\"新概念二（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)A201024\"},{\"Clas_Name\":\"新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)A211106\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)A221112\"},{\"Clas_Name\":\"新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)A210925\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)A221015\"},{\"Clas_Name\":\"新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE1 (T)A211014\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (T)A221020\"},{\"Clas_Name\":\"新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)M211204\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)M221210\"},{\"Clas_Name\":\"长期新概念一册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (F)A211105\"},{\"Clas_Name\":\"长期新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (F)A221111\"},{\"Clas_Name\":\"新概念二册（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (M)A201019-2\"},{\"Clas_Name\":\"新概念二（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (V)A210309-2\"},{\"Clas_Name\":\"新概念二册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (M)A201019\"},{\"Clas_Name\":\"新概念二册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (V)A210309\"},{\"Clas_Name\":\"新概念一册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)M220409\"},{\"Clas_Name\":\"新概念二册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)M230415\"},{\"Clas_Name\":\"新概念一册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (U)M201220\"},{\"Clas_Name\":\"新概念二册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (U)M211226\"},{\"Clas_Name\":\"新概念二册\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)M210508\"},{\"Clas_Name\":\"新概念\",\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (T)A201015\"},{\"Clas_Name\":\"新概念二（全中教小班）\",\"Prod_Name\":\"新概念 （一年制全中教小班）周末/周内\",\"Clas_Code\":\"FZ-LNCE2 (S)A210529\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)E201226\"},{\"Clas_Name\":\"新概念二（中外教）\",\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)M201226\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (U)A210321\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (U)A220327\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)A210227\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)A220305\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE1 (W)E201028\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (U)M201018\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周内\",\"Clas_Code\":\"FZ-LNCE2 (W)E211103\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)M201017\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (F)E220304\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (F)E230310\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE2 (S)M211023\"},{\"Clas_Name\":null,\"Prod_Name\":\"新概念  （一年制中外教小班）周末\",\"Clas_Code\":\"FZ-LNCE1 (S)E200926\"}]";

            List<JObject> objs = JsonConvert.DeserializeObject<List<JObject>>(data);
            foreach (var obj in objs)
            {
                var temp = obj["Clas_Name"];
                dynamic dObj = obj;
            }

            Console.ReadKey();
        }
    }
}
