using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 班级
    /// </summary>
    //[NPoco.TableName("ClassCourse")]
    //[NPoco.PrimaryKey("Clas_ID", AutoIncrement = true)]
    public class CrmClassCourse : IEntity<int>
    {
        [Key]
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Clas_ID { get; set; }

        /// <summary>
        /// 老系统班号
        /// </summary>
        public string Clas_OldCode { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string Clas_Name { get; set; }

        /// <summary>
        /// 班级编码
        /// </summary>
        public string Clas_Code { get; set; }

        /// <summary>
        /// 所属中心
        /// </summary>
        public int Clas_BranID { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Bran { get; set; }

        /// <summary>
        /// 上课方式
        /// </summary>
        public int? Clas_Way { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Way_Name { get; set; }

        /// <summary>
        /// 课程天数
        /// </summary>
        public int Clas_Day { get; set; }

        /// <summary>
        /// 排课
        /// </summary>
        public string Clas_Schedule { get; set; }

        /// <summary>
        /// 排课
        /// </summary>
        //[NPoco.Ignore]
        //public List<ClassSchedule> Schedule { get; set; }

        /// <summary>
        /// 班级级别
        /// </summary>
        public int Clas_Level { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        //[NPoco.Ignore]
        //public string Clas_Level_Name { get; set; }

        /// <summary>
        /// 上课开始日期
        /// </summary>
        public DateTime? Clas_BeginDate { get; set; }

        /// <summary>
        /// 实际上课开始日期
        /// </summary>
        public DateTime? Clas_ActualBeginDate { get; set; }

        /// <summary>
        /// 结课日期
        /// </summary>
        public DateTime? Clas_EndDate { get; set; }

        /// <summary>
        /// 开课日期
        /// </summary>
        //[NPoco.Ignore]
        //public DateTime? Clas_ClassBegin { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Date { get; set; }

        /// <summary>
        /// 上课时间-周
        /// </summary>
        public int Clas_DateWeek { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Week { get; set; }

        /// <summary>
        /// 上课开始时间
        /// </summary>
        public string Clas_BeginTime { get; set; }

        /// <summary>
        /// 上课结束时间
        /// </summary>
        public string Clas_EndTime { get; set; }

        /// <summary>
        /// 中教
        /// </summary>
        public int? Clas_LT { get; set; }

        //[NPoco.Ignore]
        //public string Clas_LT_Name { get; set; }

        /// <summary>
        /// 中教课时（单节时长）
        /// </summary>
        public int Clas_LTClassTime { get; set; }

        /// <summary>
        /// 外教
        /// </summary>
        public int? Clas_FT { get; set; }

        //[NPoco.Ignore]
        //public string Clas_FT_Name { get; set; }

        /// <summary>
        /// 助教
        /// </summary>
        public int? Clas_SA { get; set; }

        //[NPoco.Ignore]
        //public string Clas_SA_Name { get; set; }

        /// <summary>
        /// 外教课时（单节时长）
        /// </summary>
        public int Clas_FTClassTime { get; set; }

        /// <summary>
        /// 助教课时（单节时长）
        /// </summary>
        public int Clas_SAClassTime { get; set; }

        /// <summary>
        /// 班型人数
        /// </summary>
        public int Clas_Num { get; set; }

        /// <summary>
        /// 已安排人数
        /// </summary>
        public int Clas_UseNum { get; set; }

        /// <summary>
        /// 教室
        /// </summary>
        public string Clas_Classroom { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int Clas_CreatedBy { get; set; }

        public int? Clas_AgeRange { get; set; }

        //[NPoco.Ignore]
        //public string Clas_AgeRange_Name { get; set; }

        //[NPoco.Ignore]
        //public string Clas_CreatedBy_Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Clas_CreatedDate { get; set; }

        public int? Clas_UpdatedBy { get; set; }

        //[NPoco.Ignore]
        //public string Clas_UpdatedBy_Name { get; set; }

        public DateTime? Clas_UpdatedDate { get; set; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public int Clas_Deleted { get; set; }

        /// <summary>
        /// 班型状态
        /// </summary>
        public int Clas_Status { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Status_Name { get; set; }

        /// <summary>
        /// 班型时长（课时）
        /// </summary>
        public int Clas_ClassTime { get; set; }

        /// <summary>
        /// 总课次
        /// </summary>
        public int Clas_ClassHour { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Clas_Remark { get; set; }

        /// <summary>
        /// 课程类型 0 为新班，1为续班
        /// </summary>
        public int Clas_Type { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Type_Name { get; set; }

        /// <summary>
        /// 消耗课时
        /// </summary>
        public int Clas_Hour { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int Clas_ProdID { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Prod_Name { get; set; }

        //[NPoco.Ignore]
        //public ProductDTO Clas_Prod { get; set; }

        /// <summary>
        /// 单价类型：0班课，1VIP课，2全价，3团训
        /// </summary>
        public int? Clas_ClassRule { get; set; }

        /// <summary>
        /// 单期课时
        /// </summary>
        public int? Clas_PeriodClassHour { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Clas_Amount { get; set; }

        /// <summary>
        /// 班级组别（小学组、中学组、高中组、成人组、VIP）
        /// </summary>
        public int? Clas_Group { get; set; }

        //[NPoco.Ignore]
        //public string Clas_Group_Name { get; set; }

        /// <summary>
        /// 授课类型（全中教、全外教、中外教）
        /// </summary>
        public int? Clas_TeachingType { get; set; }

        //[NPoco.Ignore]
        //public string Clas_TeachingType_Name { get; set; }

        /// <summary>
        /// 班型（正价班、特价班）
        /// </summary>
        public int? Clas_ClassType { get; set; }

        //[NPoco.Ignore]
        //public string Clas_ClassType_Name { get; set; }

        /// <summary>
        /// 已上课次
        /// </summary>
        //[NPoco.Ignore]
        //public long Clas_AlreadyHour { get; set; }

        /// <summary>
        /// 待上课次
        /// </summary>
        //[NPoco.Ignore]
        //public long Clas_WaitHour { get; set; }

        /// <summary>
        /// 是否跳过审核
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsSkipAudit { get; set; }

        /// <summary>
        /// 流程ID
        /// </summary>
        //[NPoco.Ignore]
        //public int Clas_WfInstID { get; set; }

        /// <summary>
        /// 是否确认开班
        /// </summary>
        public int Clas_IsConfirm { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 延期审核中
        /// </summary>
        //[NPoco.Ignore]
        //public int Clas_IsDelay { get; set; }
        #region 导航属性
        [ForeignKey("Clas_ProdID")]
        public virtual CrmProduct Product { get; set; }
        #endregion
    }
}
