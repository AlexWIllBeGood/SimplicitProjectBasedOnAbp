using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace DataTransfer.Domain.Entities.Coupan
{
    public class AddCoupan : IEntity<int>
    {
        [Key]
        public int OrderId { get; set; }
        public int Count { get; set; }

        [NotMapped]
        public int Id { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
