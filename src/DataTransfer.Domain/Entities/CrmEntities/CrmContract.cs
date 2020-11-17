using DataTransfer.Domain.Entities.Coupan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 合同管理
    /// </summary>
    //[NPoco.TableName("Contract")]
    //[NPoco.PrimaryKey("cont_ContractId", AutoIncrement = true)]
    public class CrmContract : IEntity<int>
    {
        [Key]
        /// <summary>
        /// 合同ID
        /// </summary>
        public int Cont_ContractID { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public int? Cont_OrderID { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string Cont_Number { get; set; }

        /// <summary>
        /// 学员ID
        /// </summary>
        public int? Cont_LeadId { get; set; }

        /// <summary>
        /// 签单中心
        /// </summary>
        public int? Cont_BranchID { get; set; }

        /// <summary>
        /// 中心名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Cont_Branch_Name { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public int? Cont_ClassId { get; set; }

        /// <summary>
        /// 客户选择的开班日期
        /// </summary>
        public DateTime? Cont_ClassBeginDate { get; set; }

        /// <summary>
        /// 产品大类
        /// </summary>
        public int? Cont_ProductType { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? Cont_ProductID { get; set; }

        /// <summary>
        /// 产品等级id ,隔开
        /// </summary>
        public string Cont_ProductLevels { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Cont_ProductName { get; set; }

        /// <summary>
        /// 排课期数
        /// </summary>
        public int? Cont_Period { get; set; }

        /// <summary>
        /// 签订时间
        /// </summary>
        public DateTime? Cont_SignUpDate { get; set; }

        /// <summary>
        /// 签单CC
        /// </summary>
        public int? Cont_Sales { get; set; }

        /// <summary>
        /// 签单CC
        /// </summary>
        //[NPoco.Ignore]
        //public string Cont_Sales_Name { get; set; }

        /// <summary>
        /// 服务SA
        /// </summary>
        public int? Cont_Sa { get; set; }

        /// <summary>
        /// 服务SA
        /// </summary>
        //[NPoco.Ignore]
        //public string Cont_Sa_Name { get; set; }

        /// <summary>
        /// 合同状态0	收银待收全款；-1	收银驳回；1	待签电子合同；2	合同执行中；3	合同完结；4退费完结；5转班完结
        /// </summary>
        public int? Cont_Status { get; set; }

        /// <summary>
        /// 合同状态
        /// </summary>
        //[NPoco.Ignore]
        //public string Cont_Status_Name { get; set; }

        /// <summary>
        /// 合同开始时间
        /// </summary>
        public DateTime? Cont_BegDate { get; set; }

        /// <summary>
        /// 合同结束时间
        /// </summary>
        public DateTime? Cont_EndDate { get; set; }

        /// <summary>
        /// 学员班型总课时关联ID
        /// </summary>
        public int? Cont_StuClassID { get; set; }

        /// <summary>
        /// 产品code （立刻说使用）
        /// </summary>
        public string? Cont_ProductCode { get; set; }

        /// <summary>
        /// 立刻说合同状态
        /// </summary>
        public int? Cont_LksStatus { get; set; }

        /// <summary>
        /// 主体ID
        /// </summary>
        public int? Cont_OrgCodeID { get; set; }

        #region 金额课时

        /// <summary>
        /// 产品单价
        /// </summary>
        public int? Cont_ProductAmount { get; set; }

        /// <summary>
        /// 产品金额
        /// </summary>
        public decimal? Cont_Amount { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal? Cont_AccountReceivable { get; set; }

        /// <summary>
        /// 应收占订单总应收比例
        /// </summary>
        //[NPoco.Ignore]
        //public decimal Cont_AccountRate { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal? Cont_CashReceived { get; set; }

        /// <summary>
        /// 业绩金额
        /// </summary>
        //[NPoco.Ignore]
        //public decimal Cont_ResultAmount { get; set; }

        /// <summary>
        /// 课时数
        /// </summary>
        public int? Cont_ClassHour { get; set; }
        #endregion

        #region 折扣优惠
        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal? Cont_DiscountRate { get; set; }

        /// <summary>
        /// 满减金额
        /// </summary>
        public decimal? Cont_DiscountAmount { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal? Cont_VoucherAmount { get; set; }

        /// <summary>
        /// 选择的优惠方案
        /// </summary>
        //[NPoco.Ignore]
        //public List<DiscountContDTO> Discounts { get; set; }
        #endregion

        #region 其他字段（基本都是没有用上的）

        /// <summary>
        /// 父合同ID
        /// </summary>
        public int? Cont_ParentID { get; set; }

        /// <summary>
        /// 产品售卖类型
        /// </summary>
        public int? Cont_ProductSellType { get; set; }

        //[NPoco.Ignore]
        //public string Cont_ProductSellType_Name { get; set; }

        /// <summary>
        /// 合同类别 0为订单，1为正式合同
        /// </summary>
        public int? Cont_Category { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Cont_Remark { get; set; }

        public int? Cont_Type { get; set; }

        //[NPoco.Ignore]
        //public string Cont_Type_Name { get; set; }

        public int? Cont_FamilyId { get; set; }

        //[NPoco.Ignore]
        //public string Cont_Family_Name { get; set; }

        public string Cont_ClassWeek { get; set; }

        public string Cont_ClassBeginTime { get; set; }

        public string Cont_ClassEndTime { get; set; }

        public string Cont_ClassName { get; set; }

        /// <summary>
        /// 合同签署人(客户)
        /// </summary>
        public int? Cont_SignUser { get; set; }

        /// <summary>
        /// 剩余课时
        /// </summary>
        public int? Cont_RestClassHour { get; set; }

        public int? Cont_RefundStatus { get; set; }

        //[NPoco.Ignore]
        //public string Cont_RefundStatus_Name { get; set; }

        ///// <summary>
        ///// 折扣信息
        ///// </summary>
        //[NPoco.Ignore]
        //public DiscountDTO Cont_Discount { get; set; }

        ///// <summary>
        ///// 产品信息
        ///// </summary>
        //[NPoco.Ignore]
        //public List<ProductDTO> cont_Productes { get; set; }

        /// <summary>
        /// 原始合同ID
        /// 
        /// </summary>
        public int? Cont_RefContId { get; set; }

        /// <summary>
        /// 试听课记录id
        /// </summary>
        public int? Cont_ClassScheduleId { get; set; }

        ///// <summary>
        ///// 记录id
        ///// </summary>
        //[NPoco.Ignore]
        //public ClassScheduleDTO cont_ClassSchedule { get; set; }

        /// <summary>
        /// 是否补差价合同0否，1是
        /// </summary>
        public int? Cont_IsDiff { get; set; }

        /// <summary>
        /// 费用状态（老系统字段）
        /// </summary>
        public string Cont_FeeStatus { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Cont_SalesNum { get; set; }

        public int? Cont_CreatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Cont_CreatedBy_Name { get; set; }

        public DateTime? Cont_CreatedDate { get; set; }

        public int? Cont_UpdatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Cont_UpdatedBy_Name { get; set; }

        public DateTime? Cont_UpdatedDate { get; set; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public int? Cont_Deleted { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 导航属性
        [ForeignKey("Cont_LeadId")]
        public virtual CrmLead Lead { get; set; }
        [ForeignKey("Cont_ProductID")]
        public virtual CrmProduct Product { get; set; }
        [ForeignKey("Cont_OrderID")]
        public virtual CrmOrder Order { get; set; }
        [ForeignKey("Cont_ClassId")]
        public virtual CrmClassCourse ClassCourse { get; set; }
        #endregion
    }
}
