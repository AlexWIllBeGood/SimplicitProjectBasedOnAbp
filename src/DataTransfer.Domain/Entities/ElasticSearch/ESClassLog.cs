using DataTransfer.Domain.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.ElasticSearch
{
    public class ESClassLog
    {
        public string Id { get; set; }
        public ClassSendMtsModel Para { get; set; }
        public ClassMRTSResponseEntity Response { get; set; }
    }
}
