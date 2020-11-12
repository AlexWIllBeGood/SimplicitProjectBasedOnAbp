using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.Coupan
{
    public class CrmOrder:IEntity<int>
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int? Orde_ID { get; set; }

        /// <summary>
        /// 试听记录ID
        /// </summary>
        public int? Orde_DerdID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string Orde_Number { get; set; }

        /// <summary>
        /// 班级源数据
        /// </summary>
        public int? Orde_ClassSource { get; set; }

        /// <summary>
        /// 关联lead
        /// </summary>
        public int? Orde_LeadID { get; set; }

        /// <summary>
        /// 订单类型：订金，合同
        /// </summary>
        public string Orde_Type { get; set; }
        public int? Orde_DepositType { get; set; }
        /// <summary>
        /// 订单签订类型：0新签，1续费，2转班
        /// </summary>
        public int? Orde_SignType { get; set; }
        /// <summary>
        /// 订单状态：0待收，1已收启动,2待退定金，3已退定金，4退费完结，-1定金转学费中，-2审批中
        /// </summary>
        public string Orde_Status { get; set; }
        /// <summary>
        /// 立刻说订单同步状态 0:待同步,1:已同步创建，2：已同步启动，3：已同步冻结 4：退费完结 -1:立刻说创建
        /// </summary>
        public int? Orde_SyncStatus { get; set; }
        /// <summary>
        /// 搭售捆绑关系
        /// </summary>
        public string Orde_BundleSale { get; set; }

        /// <summary>
        /// 客户选择的开课时间
        /// </summary>
        public DateTime? Orde_BeginDate { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal? Orde_Amount { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal? Orde_AccountReceivable { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal? Orde_CashReceived { get; set; }

        /// <summary>
        /// 启动时间
        /// </summary>
        public DateTime? Orde_SignUpDate { get; set; }

        /// <summary>
        /// 所属中心
        /// </summary>
        public int? Orde_Branch { get; set; }

        /// <summary>
        /// 签单CC
        /// </summary>
        public int? Orde_OrderCC { get; set; }

        /// <summary>
        /// 当前CC
        /// </summary>
        public int? Orde_Sales { get; set; }


        /// <summary>
        /// 服务SA
        /// </summary>
        public int? Orde_Sa { get; set; }

        /// <summary>
        /// 产品大类
        /// </summary>
        public int? Orde_ProductType { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        public int? Orde_CreatedBy { get; set; }


        public DateTime? Orde_CreatedDate { get; set; }

        public int? Orde_UpdatedBy { get; set; }

        public DateTime? Orde_UpdatedDate { get; set; }

        public int? Orde_Deleted { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Orde_Remark { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal? Orde_DiscountRate { get; set; }

        /// <summary>
        /// 折扣类型
        /// </summary>
        public int? Orde_DiscountRateType { get; set; }

        /// <summary>
        /// 满减
        /// </summary>
        public decimal? Orde_DiscountAmount { get; set; }

        /// <summary>
        /// 满减类型
        /// </summary>
        public int? Orde_DiscountAmountType { get; set; }

        /// <summary>
        /// 折扣申请ID
        /// </summary>
        public int? Orde_DiscountApplyID { get; set; }

        /// <summary>
        /// 订金ID（订金转学费）
        /// </summary>
        public string Orde_Deposit { get; set; }

        /// <summary>
        /// 代金券赠送设置ID（不满足时值为-1）
        /// </summary>
        public string Orde_VoucherSetIDs { get; set; }

        /// <summary>
        /// 搭售立刻说产品列表
        /// </summary>
        public string Orde_LKSPros { get; set; }

        /// <summary>
        /// 是否使用POS收款流程(包括微信、支付宝)
        /// </summary>
        public bool? Orde_IsPos { get; set; }

        [NotMapped]      
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
