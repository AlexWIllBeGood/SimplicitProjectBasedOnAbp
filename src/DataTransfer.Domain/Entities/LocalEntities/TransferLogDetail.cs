using DataTransfer.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class TransferLogDetail : Entity<int>
    {
        /// <summary>
        /// 传输日志记录
        /// </summary>
        public int TransferLogId { get; set; }
        /// <summary>
        /// 学员信息
        /// </summary>
        public string LeadInfo { get; set; }
        /// <summary>
        /// 班级信息
        /// </summary>
        public string ClassInfo { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public string Para { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public string Response { get; set; }

        #region 导航属性
        public virtual TransferLog TransferLog { get; set; }
        #endregion
    }
}
