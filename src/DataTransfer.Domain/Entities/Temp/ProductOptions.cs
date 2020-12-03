using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.Temp
{
    /// <summary>
    /// 产品选项
    /// </summary>
    public class ProductOption
    {
        /// <summary>
        /// 班级时段类型
        /// </summary>
        public string Clas_PeriodType { get; set; }
        /// <summary>
        /// 班级规模
        /// </summary>
        public string Clas_ScaleType { get; set; }
        /// <summary>
        /// 班级教室类型
        /// </summary>
        public string Clas_TeacherType { get; set; }
    }
}
