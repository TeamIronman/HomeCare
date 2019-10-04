using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("PaymentMethods")]
    public class PaymentMethod : DomainEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
