using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Domain.Entities.Temp
{
    public class SimpleClassSchedule
    {
        public DateTime? ClassDate { get; set; }
        public int Week { get; set; }
        public string WeekName { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
    }
}
