using System;
using System.Collections.Generic;
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
            Console.WriteLine(temp);
            Console.ReadKey();
        }
    }
}
