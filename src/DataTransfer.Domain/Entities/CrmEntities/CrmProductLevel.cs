using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 产品级别
    /// </summary>
    //[NPoco.TableName("ProductLevel")]
    //[NPoco.PrimaryKey("Prol_ID", AutoIncrement = true)]
    public class CrmProductLevel:IEntity<int>
    {
        [Key]
        public int Prol_ID { get; set; }

        public string Prol_Code { get; set; }

        public string Prol_Name { get; set; }

        /// <summary>
        /// 级别缩写
        /// </summary>
        public string Prol_Ab { get; set; }

        public int? Prol_CreatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Prol_CreatedBy_Name { get; set; }

        public DateTime? Prol_CreatedDate { get; set; }

        public int? Prol_UpdatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Prol_UpdatedBy_Name { get; set; }

        public DateTime? Prol_UpdatedDate { get; set; }

        public int Prol_Deleted { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
