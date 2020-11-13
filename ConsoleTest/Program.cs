using System;
using System.Text.RegularExpressions;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "FZ-LNCE2 (F)A221111";
            var a=code.Replace("FZ-LNCE", "").Substring(0, 1);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
