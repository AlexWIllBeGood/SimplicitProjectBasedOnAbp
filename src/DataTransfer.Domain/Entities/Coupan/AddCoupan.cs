using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.Coupan
{
    public class AddCoupan : Entity<int>
    {
        public int OrderId { get; set; }
        public string OrderNO { get; set; }
        public string StudentName { get; set; }
        public int AddCount { get; set; }
    }
}
