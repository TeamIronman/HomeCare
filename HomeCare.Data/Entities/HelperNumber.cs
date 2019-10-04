using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("HelperNumbers")]
    public class HelperNumber : DomainEntity<int>
    {
        public int Amount { get; set; }


        public virtual ICollection<BillOptionHelperNumber> BillOptionHelperNumbers { get; set; }
    }
}
