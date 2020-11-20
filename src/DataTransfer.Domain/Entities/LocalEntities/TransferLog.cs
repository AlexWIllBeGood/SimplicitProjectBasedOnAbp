using DataTransfer.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class TransferLog : Entity<int>
    {
        public string BatchNo { get; set; }
        public string Para { get; set; }
        public string Response { get; set; }
        public TransferLogType Type { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
