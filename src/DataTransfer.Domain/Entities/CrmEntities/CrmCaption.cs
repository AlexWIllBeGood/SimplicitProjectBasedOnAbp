using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 字典表
    /// </summary>
    //[NPoco.TableName("Basis_Captions")]
    //[NPoco.PrimaryKey("Capt_ID", AutoIncrement = true)]
    public class CrmCaption : IEntity<int>
    {
        #region 属性		
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Capt_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string Capt_FamilyName
        {
            get;
            set;
        }

        /// <summary>
        /// 字典
        /// </summary>
        public string Capt_Family
        {
            get;
            set;
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string Capt_Code
        {
            get;
            set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Capt_Order
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int? Capt_CreatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? Capt_CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// 更新人ID
        /// </summary>
        public int? Capt_UpdatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? Capt_UpdatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public byte? Capt_Deleted
        {
            get;
            set;
        }

        /// <summary>
        /// 中文
        /// </summary>
        public string Capt_CS
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// 创建人
        /// </summary>
        //[NPoco.Ignore]
        //public string Capt_CreatedBy_Name { get; set; }

        ///// <summary>
        ///// 修改人
        ///// </summary>
        //[NPoco.Ignore]
        //public string Capt_UpdatedBy_Name { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
