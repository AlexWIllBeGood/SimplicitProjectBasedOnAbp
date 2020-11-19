using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class ClassRelation : Entity<int>
    {
        public int? CrmClassId { get; set; }
        public int? MTSClassId { get; set; }
    }
}
