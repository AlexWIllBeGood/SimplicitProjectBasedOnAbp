using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.Coupan
{
    /// <summary>
    /// 折扣申请使用详情
    /// </summary>
    public class CrmDiscountUse:IEntity<int>
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int? Disu_ID { get; set; }

        /// <summary>
        /// 折扣类型
        /// </summary>
        public int? Disu_Discount { get; set; }

        /// <summary>
        /// 关联Lead
        /// </summary>
        public int? Disu_LeadID { get; set; }

        /// <summary>
        /// 申请折扣使用中心
        /// </summary>
        public int? Disu_Branch { get; set; }

        /// <summary>
        /// 申请原因
        /// </summary>
        public string Disu_Desc { get; set; }

        /// <summary>
        /// 关联订单
        /// </summary>
        public int? Disu_OrderID { get; set; }

        /// <summary>
        /// 0审核中，1待使用,2使用中，3已使用,4已转赠,-1驳回，-2作废
        /// </summary>
        public int? Disu_Status { get; set; }

        /// <summary>
        /// 优惠折扣
        /// </summary>
        public decimal? Disu_Rate { get; set; }

        /// <summary>
        /// 满减金额
        /// </summary>
        public decimal? Disu_FullAmount { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal? Disu_Amount { get; set; }

        /// <summary>
        /// 关联流程ID
        /// </summary>
        public int? Disu_WorkflowID { get; set; }

        public int? Disu_CreatedBy { get; set; }

        public DateTime? Disu_CreatedDate { get; set; }

        public int? Disu_UpdatedBy { get; set; }

        public DateTime? Disu_UpdatedDate { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? Disu_Deleted { get; set; }

        /// <summary>
        /// 券号
        /// </summary>
        public string Disu_Number { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? Disu_ExpirationDate { get; set; }

        /// <summary>
        /// 代金券来源订单
        /// </summary>
        public int Disu_FromOrderID { get; set; }

        /// <summary>
        /// 代金券来源规则
        /// </summary>
        public int Disu_FromVoucherID { get; set; }

        /// <summary>
        /// 代金券来源（转赠）
        /// </summary>
        public int Disu_FromID { get; set; }

        /// <summary>
        /// 代金券转赠ID
        /// </summary>
        public int Disu_ToID { get; set; }

        /// <summary>
        /// 应用产品
        /// </summary>
        public string Disu_Products { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
