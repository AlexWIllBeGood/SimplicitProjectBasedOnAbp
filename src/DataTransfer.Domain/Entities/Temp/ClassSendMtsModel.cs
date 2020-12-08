using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.Temp
{
    public class ClassSendMtsModel
    {
        public string PlatfromKey { get; set; } = "0ca10fdbfc994b6dea8af3c9ea751dd9";
        public bool? IsDTClass { get; set; } = false;
        public bool? IsDTMianClass { get; set; } = false;
        public int? SchoolId { get; set; }
        public int? ProductId { get; set; }
        public int? ClassTypeId { get; set; }
        public string ProductLevelId { get; set; }
        public string ClassCName { get; set; }
        public int? CourseConfigVersionInfo { get; set; } = 1;
        public string SAId { get; set; }
        public bool? HasLT { get; set; } = false;
        public string LTId { get; set; }
        public bool? HasFT { get; set; } = false;
        public string FTId { get; set; }
        public string ClassOpenDate { get; set; }
        public string CourseTimes { get; set; }
    }
}
