using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.Temp
{
    public abstract class MTSResponseBaseEntity
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string ResultMessage { get; set; }
        ///// <summary>
        ///// 返回结果
        ///// </summary>
        public virtual string ResultData { get; set; }
    }
}
