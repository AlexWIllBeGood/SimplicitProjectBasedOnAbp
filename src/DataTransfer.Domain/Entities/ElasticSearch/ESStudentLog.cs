using DataTransfer.Domain.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.ElasticSearch
{
    public class ESStudentLog
    {
        public string Id { get; set; }
        public CrmStudentInfoModel Para { get; set; }
        public CommonMTSResponseEntity Response { get; set; }
    }
}
