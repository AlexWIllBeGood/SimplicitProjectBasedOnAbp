using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 区域中心管理
    /// </summary>
    //[NPoco.TableName("Basis_Branch")]
    //[NPoco.PrimaryKey("Bran_ID", AutoIncrement = false)]
    public class CrmBranch:IEntity<int>
    {
        [Key]
        /// <summary>
        /// 系统主键
        /// </summary>
        public int Bran_ID { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public int? Bran_ParentID { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        public string Bran_Code { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string Bran_Name { get; set; }

        /// <summary>
        /// 区域简写
        /// </summary>
        public string Bran_ShortName { get; set; }

        /// <summary>
        /// 区域缩写
        /// </summary>
        public string Bran_Ab { get; set; }

        /// <summary>
        /// 类型（预留）
        /// </summary>
        public int Bran_Type { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        public int Bran_Depth { get; set; }

        /// <summary>
        /// 支付宝支付账号配置
        /// </summary>
        public int Bran_AliPaySetting { get; set; }

        /// <summary>
        /// 支付宝支付账号配置名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Bran_AliPaySetting_Name { get; set; }

        /// <summary>
        /// 微信支付账号配置
        /// </summary>
        public int Bran_WxPaySetting { get; set; }

        /// <summary>
        /// 微信支付账号配置名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Bran_WxPaySetting_Name { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? Bran_CreatedBy { get; set; }
        //[NPoco.Ignore]
        //public string Bran_CreatedBy_Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Bran_CreatedDate { get; set; }
        //[NPoco.Ignore]
        //public string Bran_UpdatedBy_Name { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public int? Bran_UpdatedBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Bran_UpdatedDate { get; set; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public int Bran_Deleted { get; set; }

        /// <summary>
        /// SapID
        /// </summary>
        public int Bran_SapId { get; set; }

        /// <summary>
        /// POS机上线日期
        /// </summary>
        public DateTime? Bran_PosUserDate { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
