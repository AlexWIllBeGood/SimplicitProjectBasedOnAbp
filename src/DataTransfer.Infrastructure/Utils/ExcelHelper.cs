using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static byte[] Export(List<ExportParam> exportParams)
        {
            byte[] result = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                foreach (var ep in exportParams)
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add(ep.SheetName);
                    var jsonData = JsonConvert.SerializeObject(ep.Data);
                    List<JObject> objs = JsonConvert.DeserializeObject<List<JObject>>(jsonData);

                    if (ep.ColumnCnNames == null)
                    {
                        ep.ColumnCnNames = ep.ColumnEnNames;
                    }

                    int columnsCount = ep.ColumnEnNames.Count;
                    int rowCount = objs.Count;

                    //设置标题
                    for (int i = 0; i < columnsCount; i++)
                    {
                        sheet.Cells[1, i + 1].Style.Font.Bold = true;
                        sheet.Cells[1, i + 1].Value = ep.ColumnCnNames[i];
                    }

                    for (int i = 0; i < rowCount; i++)
                    {
                        var obj = objs[i];
                        for (int j = 0; j < columnsCount; j++)
                        {
                            var columnName = ep.ColumnEnNames[j];
                            sheet.Cells[i + 2, j + 1].Value = obj[columnName].ToString();
                        }
                    }
                }
                result = package.GetAsByteArray();
            }
            return result;

        }
        public class ExportParam
        {
            public string SheetName { get; set; }
            public List<string> ColumnEnNames { get; set; }
            public List<string> ColumnCnNames { get; set; }
            public dynamic Data { get; set; }
        }
    }
}
