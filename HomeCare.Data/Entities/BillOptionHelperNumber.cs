using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("BillOptionHelperNumbers")]
    public class BillOptionHelperNumber : DomainEntity<int>
    {
        public int BillOptionId { get; set; }

        public int HelperNumberId { get; set; }


        [ForeignKey("BillOptionId")]
        public virtual BillOption BillOption { get; set; }


        [ForeignKey("HelperNumberId")]
        public virtual HelperNumber HelperNumber { get; set; }
    }
}
