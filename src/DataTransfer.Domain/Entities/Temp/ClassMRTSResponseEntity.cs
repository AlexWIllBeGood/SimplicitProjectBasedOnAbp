using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.Temp
{
    public class ClassMRTSResponseEntity:MTSResponseBaseEntity
    {
        /// <summary>
        /// MTS生成的对应的班级Id
        /// </summary>
        public int MTSClassId
        {
            get
            {
                return Convert.ToInt32(this.ResultData);
            }
            set
            {
            }
        }
    }
}
