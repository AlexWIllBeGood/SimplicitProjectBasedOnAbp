using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.CrmEntities
{
    /// <summary>
    /// 用户管理
    /// </summary>
    //[NPoco.TableName("Basis_User")]
    //[NPoco.PrimaryKey("User_ID", AutoIncrement = true)]
    public class CrmUser:IEntity<int>
    {
        [Key]
        /// <summary>
        /// 用户ID
        /// </summary>
        public int User_ID { get; set; }

        /// <summary>
        /// 登录名/账号
        /// </summary>
        public string User_Logon { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public string User_EnName { get; set; }

        /// <summary>
        /// 中文
        /// </summary>
        public string User_CnName { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        //[NPoco.Ignore]
        //public string DisplayName
        //{
        //    get
        //    {
        //        return User_EnName + User_CnName + (User_Disabled == 1 ? "(离职)" : "");
        //    }
        //}

        /// <summary>
        /// 区域
        /// </summary>
        public int User_PrimaryTerritory { get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        //[NPoco.Ignore]
        //public string User_TerritoryName { get; set; }

        /// <summary>
        /// 0 正常 1禁用 2离职
        /// </summary>
        public int User_Disabled { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public byte User_Deleted { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string User_Phone { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string User_Role { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        //[NPoco.Ignore]
        //public string User_Role_Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string User_Avatar { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string User_Password { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string User_Background { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string User_IDCard { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string User_IDType { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public string User_Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string User_Email { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string User_EmployeeCode { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int User_CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime User_CreatedDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public int? User_UpdatedBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? User_UpdatedDate { get; set; }

        /// <summary>
        /// 用户部门
        /// </summary>
        public int User_Department { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        //[NPoco.Ignore]
        //public string User_Department_Name { get; set; }

        ///// <summary>
        ///// 角色
        ///// </summary>
        //[NPoco.Ignore]
        //public List<string> Roles { get; set; }

        ///// <summary>
        ///// 权限
        ///// </summary>
        //[NPoco.Ignore]
        //public List<string> Prems { get; set; }

        ///// <summary>
        ///// 角色名称集合
        ///// </summary>
        //[NPoco.Ignore]
        //public List<string> RolesName { get; set; }

        ///// <summary>
        ///// 区域
        ///// </summary>
        //[NPoco.Ignore]
        //public List<int> Terrs { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string User_PositionName { get; set; }
        /// <summary>
        /// 用户类型 0 SAP，1 加盟
        /// </summary>
        public int User_Type { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public int User_Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? User_Birthday { get; set; }

        /// <summary>
        /// 角色中心
        /// </summary>
        //[NPoco.Ignore]
        //public List<UserRoleDTO> UserRoles { get; set; }

        ///// <summary>
        ///// CA证书申请状态
        ///// </summary>
        //[NPoco.Ignore]
        //public string User_CAStatus_Name { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        #region 导航属性
        [ForeignKey("User_PrimaryTerritory")]
        public virtual CrmBranch Branch { get; set; }
        #endregion
    }
}
