using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 产品
    /// </summary>
    //[NPoco.TableName("Products")]
    //[NPoco.PrimaryKey("Prod_ProductID", AutoIncrement = true)]
    public class CrmProduct : IEntity<int>
    {
        //[NPoco.Column("Prod_ProductID")]
        [Key]
        [Column("Prod_ProductID")]
        public int Prod_ID { get; set; }
        /// <summary>
        /// 子类ID
        /// </summary>
        public int? Prod_SubTypeID { get; set; }
        /// <summary>
        /// 产品缩写
        /// </summary>
        public string Prod_Ab { get; set; }

        /// <summary>
        /// 单期课时
        /// </summary>
        public int Prod_PeriodClassHour { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Prod_Name { get; set; }

        /// <summary>
        /// 产品总课时
        /// </summary>
        public int? Prod_ClassHour { get; set; }

        /// <summary>
        /// 产品总金额
        /// </summary>
        public decimal Prod_Amount { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public int? Prod_Type { get; set; }

        ///// <summary>
        ///// 产品类型
        ///// </summary>
        //[NPoco.Ignore]
        //public string Prod_Type_Name { get; set; }

        /// <summary>
        /// 产品大类实体
        /// </summary>
        //[NPoco.Ignore]
        //public ProductTypeDTO ProType { get; set; }
        /// <summary>
        /// 产品小类实体
        /// </summary>
        //[NPoco.Ignore]
        //public ProductSubTypeDTO ProSubType { get; set; }

        ///// <summary>
        ///// 产品大类设置的单价类型：0班课，1VIP课
        ///// </summary>
        //[NPoco.Ignore]
        //public int? Prod_Type_ClassRule { get; set; }

        ///// <summary>
        ///// 产品大类设置的单价类型
        ///// </summary>
        //[NPoco.Ignore]
        //public string Prod_Type_ClassRuleShow { get; set; }

        /// <summary>
        /// 产品长短期类型
        /// </summary>
        public int? Prod_TermType { get; set; }

        /// <summary>
        /// 产品长短期类型
        /// </summary>
        //[NPoco.Ignore]
        //public string Prod_TermType_Name { get; set; }

        /// <summary>
        /// 产品状态
        /// 0：启用
        /// 1：禁用
        /// </summary>
        public int Prod_Status { get; set; }

        /// <summary>
        /// 产品状态
        /// </summary>
        //[NPoco.Ignore]
        //public string Prod_StatusName { get; set; }

        /// <summary>
        /// 可选级别ID
        /// </summary>
        public string Prod_Levels { get; set; }

        /// <summary>
        /// 可选级别
        /// </summary>
        //[NPoco.Ignore]
        //public string Prod_LevelNames { get; set; }

        /// <summary>
        /// 可选级别ID列表
        /// </summary>
        //[NPoco.Ignore]
        //public List<string> Prod_LevelList => Prod_Levels?.Split(',').ToList() ?? new List<string>();

        public int? Prod_CreatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Prod_CreatedBy_Name { get; set; }

        public DateTime? Prod_CreatedDate { get; set; }

        public int? Prod_UpdatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Prod_UpdatedBy_Name { get; set; }

        public DateTime? Prod_UpdatedDate { get; set; }

        public int Prod_Deleted { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 产品价格类型（1：单课节，2：课时（阶梯价位）3：总价） 暂时不用
        ///// </summary>
        //public int Prod_PriceType { get; set; }

        /// <summary>
        /// 默认售卖中心（初次添加使用）
        /// </summary>
        //[NPoco.Ignore]
        //public int Prod_Branch { get; set; }
        /// <summary>
        /// 默认售卖价格（初次添加使用）
        /// </summary>
        //[NPoco.Ignore]
        //public decimal Prod_Price { get; set; }

    }
}
