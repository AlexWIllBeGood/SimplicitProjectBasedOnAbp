using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.LocalEntities
{
    public class ClassTeacher : Entity<int>
    {
        public string BranchName { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public int? BranchId { get; set; }
        public int? ClassId { get; set; }
        public int? TeacherId { get; set; }
    }
}
