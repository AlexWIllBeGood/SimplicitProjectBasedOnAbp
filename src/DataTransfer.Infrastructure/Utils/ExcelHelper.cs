using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataTransfer.Infrastructure.Utils
{
    public static class ExcelHelper
    {
        public static string ExcelContentType
        {
            get
            {
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
        }
        public static byte[] Export(string sheetName)
        {
            byte[] result = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package=new ExcelPackage())
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("sheetName");

                sheet.Cells[1, 1].Value = 0;
                sheet.Cells[2, 1].Value = 1;
                sheet.Cells[3, 1].Value = 2;
                sheet.Cells[4, 1].Value = 3;

                result = package.GetAsByteArray();
            }
            return result;
        }
        
    }
}
