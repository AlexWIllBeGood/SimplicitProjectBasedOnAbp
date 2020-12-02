using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 产品大类
    /// </summary>
    //[NPoco.TableName("ProductType")]
    //[NPoco.PrimaryKey("Prot_ID", AutoIncrement = true)]
    public class CrmProductType: IEntity<int>
    {
        [Key]
        /// <summary>
        /// 大类ID
        /// </summary>
        public int Prot_ID { get; set; }

        /// <summary>
        /// 大类Code
        /// </summary>
        public string Prot_Code { get; set; }

        /// <summary>
        /// 大类名称
        /// </summary>
        public string Prot_Name { get; set; }

        /// <summary>
        /// 单价类型：0班课，1VIP课，2全价，3团训
        /// </summary>
        public int Prot_ClassRule { get; set; }

        /// <summary>
        /// 单价类型
        /// </summary>
        //[NPoco.Ignore]
        //public string Prot_ClassRuleShow { get; set; }

        /// <summary>
        /// 是否允许插班
        /// </summary>
        public int Prot_IsClassInsert { get; set; }

        /// <summary>
        /// 是否允许搭售
        /// </summary>
        public int Prot_IsBundle { get; set; }

        /// <summary>
        /// 售卖规则（0整期，1剩余）
        /// </summary>
        public int Prot_SaleRule { get; set; }

        /// <summary>
        /// 售卖规则（0整期，1剩余）
        /// </summary>
        //[NPoco.Ignore]
        //public string Prot_SaleRuleShow { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? Prot_CreatedBy { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Prot_CreatedBy_Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Prot_CreatedDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public int? Prot_UpdatedBy { get; set; }

        /// <summary>
        /// 更新人名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Prot_UpdatedBy_Name { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? Prot_UpdatedDate { get; set; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public byte Prot_Deleted { get; set; }

        /// <summary>
        /// 同步系统
        /// </summary>
        public string Prot_SyncSys { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
