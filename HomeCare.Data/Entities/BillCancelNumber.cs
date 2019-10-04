using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("BillCancelNumbers")]
    public class BillCancelNumber : DomainEntity<string>
    {
        public int Number { get; set; }
    }
}
