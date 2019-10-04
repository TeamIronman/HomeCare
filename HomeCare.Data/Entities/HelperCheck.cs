using HomeCare.Data.Interfaces;
using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("HelperChecks")]
    public class HelperCheck : DomainEntity<int>
    {

        public bool? Firstcheck { get; set; }

        public bool? Secondcheck { get; set; }

        public bool? Thirdcheck { get; set; }

        public bool? Cancel { get; set; }

        public int BillId { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

        
    }
}
