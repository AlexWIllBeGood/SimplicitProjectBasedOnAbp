using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 排课信息
    /// </summary>
    //[NPoco.TableName("ClassSchedule")]
    //[NPoco.PrimaryKey("Clsc_ID", AutoIncrement = true)]
    public class CrmClassSchedule:IEntity<int>
    {
        #region 属性	

        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int Clsc_ID { get; set; }

        /// <summary>
        /// 班型
        /// </summary>
        public int Clsc_ClassID { get; set; }

        /// <summary>
        /// 上课日期
        /// </summary>
        public DateTime? Clsc_ClassDate { get; set; }

        /// <summary>
        /// 上课开始时间（不带日期）
        /// </summary>
        public string Clsc_BeginTime { get; set; }

        /// <summary>
        /// 上课结束时间（不带日期）
        /// </summary>
        public string Clsc_EndTime { get; set; }

        /// <summary>
        /// 班型时长（课时）
        /// </summary>
        public int Clsc_ClassTime { get; set; }

        /// <summary>
        /// 中教
        /// </summary>
        public int? Clsc_LT { get; set; }

        /// <summary>
        /// 中教课时（单节时长）
        /// </summary>
        public int Clsc_LTClassTime { get; set; }

        /// <summary>
        /// 外教
        /// </summary>
        public int? Clsc_FT { get; set; }

        /// <summary>
        /// 外教课时（单节时长）
        /// </summary>
        public int Clsc_FTClassTime { get; set; }

        /// <summary>
        /// 助教（结课老师）
        /// </summary>
        public int? Clsc_SA { get; set; }

        /// <summary>
        /// 助教课时（单节时长）
        /// </summary>
        public int Clsc_SAClassTime { get; set; }

        /// <summary>
        /// 班型人数
        /// </summary>
        public int Clsc_Num { get; set; }

        /// <summary>
        /// 教室
        /// </summary>
        public string Clsc_Classroom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Clsc_CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Clsc_CreatedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Clsc_UpdatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Clsc_UpdatedDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Clsc_Remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Clsc_Deleted { get; set; }

        /// <summary>
        /// 状态代码（0待上课，1已上课，2已取消）
        /// </summary>
        public int Clsc_Status { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public int Clsc_Period { get; set; }

        /// <summary>
        /// 每期序号
        /// </summary>
        public int Clsc_No { get; set; }
        #endregion

        /// <summary>
        /// 班型名称
        /// </summary>
        //[NPoco.Ignore]
        //public ClassDTO Clsc_class { get; set; }

        ///// <summary>
        ///// 上课日期（格式化）
        ///// </summary>
        //[NPoco.Ignore]
        //public string Clsc_Date { get; set; }

        /// <summary>
        /// 上课开始时间（带日期）
        /// </summary>
        //[NPoco.Ignore]
        //public DateTime Clsc_BeginDate { get; set; }

        ///// <summary>
        ///// 上课结束时间（带日期）
        ///// </summary>
        //[NPoco.Ignore]
        //public DateTime Clsc_EndDate { get; set; }

        ///// <summary>
        ///// 周几
        ///// </summary>
        //[NPoco.Ignore]
        //public string Week { get; set; }

        /// <summary>
        /// 中教名称
        /// </summary>
        //[NPoco.Ignore]
        //public string Clsc_LT_Name { get; set; }

        ///// <summary>
        ///// 外教名称
        ///// </summary>
        //[NPoco.Ignore]
        //public string Clsc_FT_Name { get; set; }

        ///// <summary>
        ///// 助教名称
        ///// </summary>
        //[NPoco.Ignore]
        //public string Clsc_SA_Name { get; set; }

        ///// <summary>
        ///// 预约人数
        ///// </summary>
        //[NPoco.Ignore]
        //public int Clsc_AppNum { get; set; }

        ///// <summary>
        ///// 实际人数
        ///// </summary>
        //[NPoco.Ignore]
        //public int Clsc_UseNum { get; set; }

        //[NPoco.Ignore]
        //public string Clsc_CreatedBy_Name { get; set; }

        //[NPoco.Ignore]
        //public string Clsc_UpdatedBy_Name { get; set; }

        ///// <summary>
        ///// 是否过期
        ///// </summary>
        //[NPoco.Ignore]
        //public bool IsExpired { get; set; }

        ///// <summary>
        ///// 状态名称
        ///// </summary>
        //[NPoco.Ignore]
        //public string Clsc_StatusName { get; set; }

        ///// <summary>
        ///// 上课学员(vip添加排课时选择)
        ///// </summary>
        //[NPoco.Ignore]
        //public List<int> Clsc_LeadIDs { get; set; }
        ///// <summary>
        ///// 消耗课时
        ///// </summary>
        //public int Clsc_ClassHour { get; set; }

        ///// <summary>
        ///// 多选日期(vip添加排课时可以多选)
        ///// </summary>
        //[NPoco.Ignore]
        //public List<ClassDateModel> Clsc_ClassDates { get; set; }

        ///// <summary>
        ///// 课程内容
        ///// </summary>
        //public int Clsc_Course { get; set; }
        //[NPoco.Ignore]
        //public string Clsc_Course_Name { get; set; }
        /// <summary>
        /// 学习进度
        /// </summary>
        public string Clsc_Progress { get; set; }
        /// <summary>
        /// 授课重点
        /// </summary>
        public string Clsc_CourseFocus { get; set; }
        /// <summary>
        /// 课程作业
        /// </summary>
        public string Clsc_CourseTask { get; set; }
        /// <summary>
        /// 教师点评
        /// </summary>
        public string Clsc_TeachReviews { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        #region 导航属性
        [ForeignKey("Clsc_ClassID")]
        public virtual CrmClassCourse ClassCourse { get; set; }
        #endregion
    }
}
