using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 产品小类
    /// </summary>
    //[NPoco.TableName("ProductSubType")]
    //[NPoco.PrimaryKey("Prost_ID", AutoIncrement = true)]
    public class CrmProductSubType:IEntity<int>
    {
        [Key]
        /// <summary>
        /// 小类ID
        /// </summary>
        public int Prost_ID { get; set; }
        /// <summary>
        /// 大类ID
        /// </summary>
        public int? Prot_ID { get; set; }
        /// <summary>
        /// 小类名称
        /// </summary>
        public string Prost_Name { get; set; }
        /// <summary>
        /// 时段类型
        /// </summary>
        public int? Clas_PeriodType { get; set; }
        /// <summary>
        /// 班级规模类型
        /// </summary>
        public int? Clas_ScaleType { get; set; }
        /// <summary>
        /// 班级教师类型
        /// </summary>
        public int? Clas_TeacherType { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int? Prost_CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Prost_CreatedDate { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        #region 导航属性
        [ForeignKey("Prot_ID")]
        public virtual CrmProductType ProductType { get; set; }
        #endregion
    }
}
