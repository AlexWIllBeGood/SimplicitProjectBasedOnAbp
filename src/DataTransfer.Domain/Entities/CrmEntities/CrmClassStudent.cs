using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 学员，班级关联表
    /// </summary>
    //[NPoco.TableName("ClassStudent")]
    //[NPoco.PrimaryKey("Clst_ID", AutoIncrement = true)]
    public class CrmClassStudent : IEntity<int>
    {
        [Key]
        public int Clst_ID { get; set; }

        /// <summary>
        /// 关联班级
        /// </summary>
        public int? Clst_ClassID { get; set; }

        /// <summary>
        /// 关联合同
        /// </summary>
        public int Clst_ContID { get; set; }
        /// <summary>
        /// 关联学员
        /// </summary>
        public int Clst_LeadID { get; set; }

        /// <summary>
        /// 总课时
        /// </summary>
        public int? Clst_ClassHour { get; set; }

        /// <summary>
        /// 上课状态(0待上课,1上课中,2正常完结,3变更审核中,4已停课,5转班完结,6退费完结,7停课到期)
        /// </summary>
        public int Clst_Status { get; set; }

        /// <summary>
        /// 最后上课状态，用来记录审核前状态
        /// </summary>
        public int Clst_LastStatus { get; set; }

        //[NPoco.Ignore]
        //public string Clst_Status_Name { get; set; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public int Clst_Deleted { get; set; }

        public int Clst_CreatedBy { get; set; }

        public DateTime? Clst_CreatedDate { get; set; }

        public int Clst_UpdatedBy { get; set; }

        public DateTime? Clst_UpdatedDate { get; set; }

        /// <summary>
        /// 调整课时
        /// </summary>
        public int Clst_AdjustHour { get; set; }

        /// <summary>
        /// 已上课时
        /// </summary>
        public int Clst_FinishHour { get; set; }

        /// <summary>
        /// 剩余课时
        /// </summary>
        //[NPoco.Ignore]
        //public int Clst_SurplusHour { get; set; }

        /// <summary>
        /// 开始上课时间
        /// </summary>
        public DateTime? Clst_StartDate { get; set; }

        /// <summary>
        /// 结束上课时间
        /// </summary>
        public DateTime? Clst_EndDate { get; set; }

        /// <summary>
        /// 准备停课次数
        /// </summary>
        //[NPoco.Ignore]
        //public int Clst_StopCount { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        #region 导航属性
        [ForeignKey("Clst_ClassID")]
        public virtual CrmClassCourse ClassCourse { get; set; }
        #endregion
    }
}
