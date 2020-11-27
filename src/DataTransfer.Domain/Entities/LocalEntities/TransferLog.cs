using DataTransfer.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class TransferLog : Entity<int>
    {
        public TransferLog()
        {
            this.TransferLogDetails = new List<TransferLogDetail>();
        }
        /// <summary>
        /// 数据批次号码
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 记录数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 产品类型信息
        /// </summary>
        public string ProductTypeInfo{ get; set; }
        /// <summary>
        /// 中心信息
        /// </summary>
        public string BranchInfo { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public TransferLogType Type { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        #region 导航属性
        public virtual ICollection<TransferLogDetail> TransferLogDetails { get; set; }
        #endregion
    }
}
