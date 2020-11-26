using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.Temp
{
    public class CrmStudentInfoModel
    {
        /// <summary>
        /// 配置中包含
        /// </summary>
        public string platfromKey { get; set; } = "";

        /// <summary>
        /// 学员帐号
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string cName { get; set; }

        /// <summary>
        /// 客户英文名
        /// </summary>
        public string eName { get; set; }

        /// <summary>
        /// 客户性别
        /// </summary>
        public int? gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday { get; set; }

        /// <summary>
        /// 客户手机
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 客户区域中心
        /// </summary>
        public int? branchId { get; set; }

        /// <summary>
        /// 客户的CC oa帐号
        /// </summary>
        public string ccUserId { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int? contractId { get; set; }

        /// <summary>
        /// 学员ID
        /// </summary>
        public int? emeId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string contractNum { get; set; }

        /// <summary>
        /// 合同编号组
        /// </summary>
        public string cont_isbinding { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public string contractType { get; set; }

        /// <summary>
        /// 合同中心
        /// </summary>
        public string contractBranchId { get; set; }

        /// <summary>
        /// 合同执行开始日期
        /// </summary>
        public DateTime? contBeginDate { get; set; }

        /// <summary>
        /// 合同结束日期
        /// </summary>
        public DateTime? contEndDate { get; set; }

        /// <summary>
        /// 合同状态
        /// </summary>
        public string contStatus { get; set; }

        /// <summary>
        /// 合同产品ID
        /// </summary>
        public int? productId { get; set; }

        /// <summary>
        /// 合同产品大类ID,实际对应产品
        /// </summary>
        public int? productType { get; set; }

        /// <summary>
        /// 开始级别ID
        /// </summary>
        public string beginProductLevelId { get; set; }

        /// <summary>
        /// 结束级别ID
        /// </summary>
        public string endProductLevelId { get; set; }

        /// <summary>
        /// 当前级别ID,可能有多个
        /// </summary>
        public string currentLevel { get; set; }

        /// <summary>
        /// 合同多级别ID
        /// </summary>
        public string productLevelId { get; set; }

        /// <summary>
        /// 合同变更类型,转让Quit/退费Refund/产品转换Convert
        /// </summary>
        public string contractShift { get; set; }

        /// <summary>
        /// 父合同ID
        /// </summary>
        public int? Cont_ParentId { get; set; }

        /// <summary>
        /// 合同变更类型,转让Quit/退费Refund/产品转换Convert
        /// </summary>
        public string Cont_ShiftType { get; set; }

        /// <summary>
        /// 退费原因
        /// </summary>
        public string Cont_reason { get; set; }

        /// <summary>
        /// 退费金额
        /// </summary>
        public double Cont_RefundAmount { get; set; }

        public string ccUserName { get; set; }

        /// <summary>
        /// MTS班级id
        /// </summary>
        public int? classId { get; set; }

        /// <summary>
        /// 组别Code
        /// </summary>
        public string levelCodes { get; set; }

        /// <summary>
        ///  当前组别Code
        /// </summary>
        public string currLevelCodes { get; set; }

        /// <summary>
        ///  课程小类： 1周末班 2周中班
        /// </summary>
        public int? contractTypeSub { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 是否加入班级
        /// </summary>
        public bool needJoinClass { get; set; };
    }
}
