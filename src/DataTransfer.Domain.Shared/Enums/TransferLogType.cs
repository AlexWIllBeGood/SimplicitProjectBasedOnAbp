using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataTransfer.Domain.Shared.Enums
{
    /// <summary>
    /// 转移日志类型
    /// </summary>
    public enum TransferLogType
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None = 0,
        /// <summary>
        /// 班级
        /// </summary>
        [Description("班级")]
        Class = 1,
        /// <summary>
        /// 学生
        /// </summary>
        [Description("学生")]
        Student = 2
    }
}
