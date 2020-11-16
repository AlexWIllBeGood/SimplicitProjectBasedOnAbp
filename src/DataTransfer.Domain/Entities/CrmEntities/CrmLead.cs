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
    /// Lead表
    /// </summary>
    //[NPoco.TableName("Lead")]
    //[NPoco.PrimaryKey("Lead_LeadID", AutoIncrement = true)]
    public class CrmLead:IEntity<int>
    {
        #region 属性	

        /// <summary>
        /// 咨询结果
        /// </summary>
        public int? Lead_ConsultResult { get; set; }

        /// <summary>
        /// 是否无效（0有效，1无效）
        /// </summary>
        public int? Lead_Invalid { get; set; }

        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public int Lead_LeadID { get; set; }

        /// <summary>
		/// 入库手机号码
		/// </summary>
        public string Lead_Mobile { get; set; }

        /// <summary>
		/// 最新手机号码
		/// </summary>
        //public string Lead_NewMobile { get; set; }

        /// <summary>
        /// 是否添加微信
        /// </summary>
        public bool? Lead_IsAddWeiXin { get; set; }

        /// <summary>
        /// 微信号码
        /// </summary>
        public string Lead_WeiXin { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Lead_Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Lead_Gender { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Lead_Address { get; set; }

        /// <summary>
        /// 渠道
        /// </summary>
        public int? Lead_Channel { get; set; }

        /// <summary>
        /// 二级渠道
        /// </summary>
        public int? Lead_ChannelTwo { get; set; }

        /// <summary>
        /// 市场专员
        /// </summary>
        public int? Lead_MarketCS { get; set; }

        /// <summary>
        /// 保护期
        /// </summary>
        public DateTime? Lead_Protection { get; set; }

        /// <summary>
        /// 状态（1CC待分配，2CC跟进中，3已签单
        /// </summary>
        public int? Lead_Status { get; set; }

        /// <summary>
        /// 销售CC（课程顾问）
        /// </summary>
        public int? Lead_Sales { get; set; }

        /// <summary>
        /// 服务SA
        /// </summary>
        public int? Lead_Sa { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Sa_Name { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? Lead_CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Lead_CreatedDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public int? Lead_UpdatedBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Lead_UpdatedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Lead_Deleted { get; set; }

        /// <summary>
        /// lead身份
        /// </summary>
        public int? Lead_FamilyIdentity { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Lead_Email { get; set; }

        /// <summary>
        /// 到访时间
        /// </summary>
        public DateTime? Lead_ShowUpDate { get; set; }

        /// <summary>
        /// 咨询时长
        /// </summary>
        public int? Lead_Consultation { get; set; }

        /// <summary>
        /// 下次跟进时间
        /// </summary>
        public DateTime? Lead_NextFollowDate { get; set; }

        /// <summary>
        /// 跟进次数
        /// </summary>
        public int? Lead_FollowNum { get; set; }

        /// <summary>
        /// 阶段
        /// </summary>
        public int? Lead_Stage { get; set; }

        /// <summary>
        /// 推广点
        /// </summary>
        public int? Lead_MChannelID { get; set; }

        /// <summary>
        /// 渠道活动
        /// </summary>
        public int? Lead_ChannelActivity { get; set; }

        /// <summary>
        /// 活动表现
        /// </summary>
        public string Lead_ActivityShow { get; set; }

        /// <summary>
        /// 网络二级推广
        /// </summary>
        public string Lead_SupportSecond { get; set; }

        /// <summary>
        /// 网络三级推广
        /// </summary>
        public string Lead_SupportThird { get; set; }

        /// <summary>
        /// 网络关键词（四级推广）
        /// </summary>
        public string Lead_KeyWord { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string Lead_MemberID { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? Lead_RegisterDate { get; set; }

        /// <summary>
        /// offer
        /// </summary>
        public string Lead_Offer { get; set; }

        /// <summary>
        /// 网络客服
        /// </summary>
        public string Lead_CustomerService { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Lead_Avatar { get; set; }

        /// <summary>
        /// 就读学校
        /// </summary>
        public string Lead_School { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Lead_Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Lead_Birthday { get; set; }

        /// <summary>
        /// 客户分类
        /// </summary>
        public int? Lead_CustomerType { get; set; }

        /// <summary>
        /// 参加过的培训机构名称
        /// </summary>
        public int? Lead_Competitor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Lead_Prov { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Lead_City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Lead_District { get; set; }

        /// <summary>
        /// 客户备注
        /// </summary>
        public string Lead_Remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Lead_AgeMonth { get; set; }

        /// <summary>
        /// 电话结果
        /// </summary>
        public int? Lead_CallResult { get; set; }

        /// <summary>
        /// 首次拨打跟进时间
        /// </summary>
        public DateTime? Lead_FirstCallDate { get; set; }

        /// <summary>
        /// 预约到访时间
        /// </summary>
        public DateTime? Lead_BookingDate { get; set; }

        /// <summary>
        /// 报备人 已废置
        /// </summary>
        public string Lead_Referral { get; set; }

        /// <summary>
        /// 推荐学员
        /// </summary>
        public int? Lead_RenewBy { get; set; }

        /// <summary>
        /// 推广员
        /// </summary>
        public string Lead_Promoter { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public int? Lead_Source { get; set; }


        /// <summary>
        /// TMK专员
        /// </summary>
        public int? Lead_Tmk { get; set; }


        /// <summary>
        /// 最后拨打时间
        /// </summary>
        public DateTime? Lead_LastCallDate { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public string Lead_EnName { get; set; }


        /// <summary>
        /// 无效到访原因
        /// </summary>
        public int? Lead_InvalidpresReason { get; set; }


        /// <summary>
        /// 外系统主键ID
        /// </summary>
        public int? Lead_ClassPeriod { get; set; }


        /// <summary>
        /// leads跟进时间
        /// </summary>
        public DateTime? Lead_ProcessDate { get; set; }


        /// <summary>
        /// 最后分配时间
        /// </summary>
        public DateTime? Lead_DistDate { get; set; }


        /// <summary>
        /// 固定电话
        /// </summary>
        public string Lead_Telephone { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        public string Lead_Company { get; set; }

        /// <summary>
        /// 证件类型 0、身份证 1、护照 B、港澳居民往来内地通行证 C、台湾居民来往大陆通行证 F、临时居民身份证
        /// </summary>
        public string Lead_IDType { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        //[NPoco.Ignore]
        //public string Lead_IDType_Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string Lead_IDNo { get; set; }

        /// <summary>
        /// 学员类型（新线索、无效线索、潜在客户）
        /// </summary>
        public int? Lead_StudentType { get; set; }

        /// <summary>
        /// 意向课程
        /// </summary>
        public int? Lead_IntendedCourse { get; set; }


        /// <summary>
        /// 试讲老师UserID
        /// </summary>
        public int? Lead_LectureTeacherUserID { get; set; }

        /// <summary>
        /// 来源方式(立刻说报备成功：7)
        /// </summary>
        public int? Lead_SourceWay { get; set; }

        /// <summary>
        /// 是否预约
        /// </summary>
        public int? Lead_IsBooking { get; set; }

        /// <summary>
        /// 是否到访
        /// </summary>
        public int? Lead_IsShowUp { get; set; }

        /// <summary>
        /// 是否报名
        /// </summary>
        public int? Lead_IsApply { get; set; }

        /// <summary>
        /// 活动场地
        /// </summary>
        public int? Lead_ActivitySpace { get; set; }

        /// <summary>
        /// 姓名首字母（助记码）
        /// </summary>
        public string Lead_NameInitials { get; set; }

        /// <summary>
        /// 回收原因
        /// </summary>
        public int? Lead_RecoveryReason { get; set; }

        /// <summary>
        /// 回收资源
        /// </summary>
        public int? Lead_RecoveryResource { get; set; }

        /// <summary>
        /// 回收时间
        /// </summary>
        public DateTime? Lead_RecoveryDate { get; set; }

        /// <summary>
        /// 是否信息中心
        /// </summary>
        public int? Lead_IsInfoCenter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lead_CrossCenterResourceNotes { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        public int? Lead_User { get; set; }

        /// <summary>
        /// 带访员姓名
        /// </summary>
        public string Lead_NameOfInterviewer { get; set; }

        /// <summary>
        /// 检查评语
        /// </summary>
        public string Lead_CheckComments { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public int? Lead_BranID { get; set; }

        /// <summary>
        /// 组ID
        /// </summary>
        public int? Lead_GroupID { get; set; }

        /// <summary>
        /// tmk中心ID
        /// </summary>
        public int? Lead_TMK_BranID { get; set; }

        /// <summary>
        /// 录入年级（1一年级，2二年级）
        /// </summary>
        public int? Lead_InputGrade { get; set; }

        /// <summary>
        /// 跟进端口（1CC，2tmk）
        /// </summary>
        public int? Lead_FollowPort { get; set; }

        /// <summary>
        /// TMK状态
        /// </summary>
        public int? Lead_Status_TMK { get; set; }

        /// <summary>
        /// 报备老师
        /// </summary>
        /// 数据库类型错误
        public string Lead_ReportedTeacher { get; set; }

        /// <summary>
        /// 更新人姓名
        /// </summary>
        public string Lead_UpdatedByName { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string Lead_CreatedByName { get; set; }

        /// <summary>
        /// 中心名
        /// </summary>
        public string Lead_BranName { get; set; }

        /// <summary>
        /// 所属用户姓名
        /// </summary>
        public string Lead_UserName { get; set; }

        /// <summary>
        /// 导入数据系统那边的leadID
        /// </summary>
        public string Lead_AccountId { get; set; }

        /// <summary>
        /// 系统来源（0CRM 1www库，2crm库,3WEBAPI）
        /// </summary>
        public int? Lead_SystemChannel { get; set; }

        /// <summary>
        /// 覆盖时间
        /// </summary>
        public DateTime? Lead_CoverageDate { get; set; }

        /// <summary>
        /// 首次开课日期Or首次签单时间
        /// </summary>
        public DateTime? Lead_FirstStartDate { get; set; }

        #endregion

        #region 基本信息

        //[NPoco.Ignore]
        //public string Lead_Type_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Gender_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Age_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_AgeMonth_Name { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        //[NPoco.Ignore]
        //public int Lead_Birthday_Age
        //{
        //    get
        //    {
        //        if (Lead_Birthday.HasValue)
        //        {
        //            var age = DateTime.Now.Year - Lead_Birthday.Value.Year - 1;
        //            if (Lead_Birthday.Value.Month < DateTime.Now.Month || (Lead_Birthday.Value.Month == DateTime.Now.Month && Lead_Birthday.Value.Day <= DateTime.Now.Day))
        //            {
        //                age++;
        //            }
        //            return age;
        //        }
        //        return 0;
        //    }
        //    set { }
        //}

        //[NPoco.Ignore]
        //public string Lead_FamilyIdentity_Name { get; set; }

        ///// <summary>
        ///// 扫码到访ID
        ///// </summary>
        //[NPoco.Ignore]
        //public int? Lead_VisitID { get; set; }
        #endregion

        //[NPoco.Ignore]
        //public string Lead_SystemChannel_Name { get; set; }
        /// <summary>
        /// 意向中心
        /// </summary>
        public int? Lead_IntendedBranID { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
        //[NPoco.Ignore]
        //public string Lead_IntendedBranch_Name { get; set; }
        //#region 渠道信息
        //[NPoco.Ignore]
        //public string Lead_Channel_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_ChannelTwo_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_MChannel_Name { get; set; }

        ///// <summary>
        ///// 渠道活动
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_ChannelActivity_Name { get; set; }

        ///// <summary>
        ///// TMK专员
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_Tmk_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_MarketCS_Name { get; set; }

        ///// <summary>
        ///// 渠道来源
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_Source_Name { get; set; }

        ///// <summary>
        ///// 报备老师
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_Teacher_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_RenewBy_Name { get; set; }

        ///// <summary>
        ///// 保护期
        ///// </summary>
        //[NPoco.Ignore]
        //public bool IsProtection
        //{
        //    get
        //    {
        //        return Lead_Protection.HasValue && Lead_Protection.Value > DateTime.Now;
        //    }
        //}

        //[NPoco.Ignore]
        //public string Lead_Status_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Status_TMK_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Stage_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Invalidpresreason_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_CustomerType_Name { get; set; }

        //[NPoco.Ignore]
        //public int DisNum { get; set; }

        //[NPoco.Ignore]
        //public string Lead_CallResult_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Sales_Name { get; set; }
        //#endregion

        //[NPoco.Ignore]
        //public string Lead_CreatedBy_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_UpdatedBy_Name { get; set; }

        //#region 问卷信息
        //[NPoco.Ignore]
        //public string Lead_QueUrgency_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Hobby_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueInvested_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Competitor_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueTemperament_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueCharacteristic_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueProduct_Name { get; set; }

        ///// <summary>
        ///// 多元智能分类
        ///// </summary>
        //[NPoco.Ignore]
        //public int? Lead_QueIntelligent { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueIntelligent_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueIsArt_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueArtType_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_QueChannel_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_ClassPeriod_Name { get; set; }

        //#endregion

        //#region 省市级联

        //[NPoco.Ignore]
        //public string Lead_Prov_Name { get; set; }
        //[NPoco.Ignore]
        //public string Lead_City_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_District_Name { get; set; }
        //#endregion

        //[NPoco.Ignore]
        //public List<FamilyLeadDTO> FamilyList { get; set; }

        //[NPoco.Ignore]
        //public string Lead_Names { get; set; }

        //[NPoco.Ignore]
        //public bool Lead_IsFollow { get; set; }

        //[NPoco.Ignore]
        //public string RealAge
        //{
        //    get
        //    {
        //        if (Lead_Age.HasValue)
        //        {
        //            var now = DateTime.Now;
        //            //创建的时候月份
        //            var createMonth = Lead_Age.Value * 12 + Lead_AgeMonth.GetValueOrDefault(0);//lead月份
        //            var leadMonth = (now.Year - Lead_CreatedDate.Year) * 12 + now.Month - Lead_CreatedDate.Month;
        //            var totalmonth = createMonth + leadMonth;
        //            var nowyear = totalmonth / 12;
        //            var nowmonth = totalmonth % 12 == 0 ? 0 : totalmonth % 12;
        //            return nowyear + "岁" + (nowmonth > 0 ? (nowmonth + "月") : "");
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    set { }
        //}

        //[NPoco.Ignore]
        //public string Lead_InputGrade_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_ConsultResult_Name { get; set; }


        //[NPoco.Ignore]
        //public string Lead_StudentType_Name { get; set; }

        //[NPoco.Ignore]
        //public string Lead_IntendedCourse_Name { get; set; }

        ///// <summary>
        ///// 试讲教师
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_LectureTeacher_Name { get; set; }

        //#region 监护人信息
        ///// <summary>
        ///// 监护人身份
        ///// </summary>
        //[NPoco.Ignore]
        //public int? Fami_Identity { get; set; }

        ///// <summary>
        ///// 监护人姓名
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_GuardianName { get; set; }

        ///// <summary>
        ///// 监护人手机号码
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_GuardianMobile { get; set; }

        ///// <summary>
        ///// 监护人身份证号
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_GuardianIDNo { get; set; }

        ///// <summary>
        ///// 监护人工作单位
        ///// </summary>
        //[NPoco.Ignore]
        //public string Lead_GuardianCompany { get; set; }
        //#endregion


        /// <summary>
        /// 中心
        /// </summary>
        //[NPoco.Ignore]
        //public string Lead_BranID_Name { get; set; }

        /// <summary>
        /// TMK中心
        /// </summary>
        //[NPoco.Ignore]
        //public string Lead_TMK_BranID_Name { get; set; }

        /// <summary>
        /// 是否有到访按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsVisit { get; set; }

        /// <summary>
        /// 是否可覆盖lead
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsCover { get; set; }

        /// <summary>
        /// 是否有合同按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsContButton { get; set; }

        /// <summary>
        /// 是否有删除按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsDeleteButton { get; set; }

        /// <summary>
        /// 是否有编辑按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsEditButton { get; set; }

        /// <summary>
        /// 是否有推荐客户按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsRecommendButton { get; set; }

        /// <summary>
        /// 是否有添加监护人按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsAddGuardianButton { get; set; }

        /// <summary>
        /// 是否有跟进按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsCommFollowButton { get; set; }

        /// <summary>
        /// 是否有添加试听课按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsAddDemoClassButton { get; set; }

        /// <summary>
        /// 是否有咨询结果按钮
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsConsultBtn { get; set; }

        /// <summary>
        /// 是否当前机会中心
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsBranch { get; set; }

        /// <summary>
        /// 是否有订单
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsOrder { get; set; }

        /// <summary>
        /// 订单归属周期（新签【当天算新签】，续费）
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsRenw { get; set; }

        /// <summary>
        /// 是否当前机会CC
        /// </summary>
        //[NPoco.Ignore]
        //public bool IsSelf { get; set; }

        /// <summary>
        /// CA申请状态
        /// </summary>
        //[NPoco.Ignore]
        //public string CAStatus { get; set; }

        #region 导航属性
        [ForeignKey("Lead_BranID")]
        public virtual CrmBranch Branch { get; set; }
        [ForeignKey("Lead_Sa")]
        public virtual CrmUser SA { get; set; }
        //[ForeignKey("Lead_LeadID")]
        public virtual ICollection<CrmContract> Contracts { get; set; }
        //[ForeignKey("Lead_LeadID")]
        public virtual ICollection<CrmOrder> Orders { get; set; }
        #endregion
    }
}
