using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class ClassHourLevel : Entity<int>
    {
        public int Hour { get; set; }
        public int Level { get; set; }
    }
}
