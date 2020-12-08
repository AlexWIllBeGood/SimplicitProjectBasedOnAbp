using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Shared.Enums
{
    /// <summary>
    /// 导出类型
    /// </summary>
    public enum ExportType
    {
        /// <summary>
        /// 无
        /// </summary>
        None=0,
        /// <summary>
        /// Excel
        /// </summary>
        Excel=1,
        /// <summary>
        /// 导出到ElasticSearch
        /// </summary>
        ElasticSearch=2
    }
}
