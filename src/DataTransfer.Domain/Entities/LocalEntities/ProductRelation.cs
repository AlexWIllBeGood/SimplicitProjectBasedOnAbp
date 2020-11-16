using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class ProductRelation : Entity<int>
    {
        /// <summary>
        /// 原产品名称
        /// </summary>
        public string OriginalProductName { get; set; }
        /// <summary>
        /// 新产品名称
        /// </summary>
        public string NewProductName { get; set; }
    }
}
