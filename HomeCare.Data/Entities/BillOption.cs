using HomeCare.Data.Enums;
using HomeCare.Data.Interfaces;
using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("BillOptions")]
    public class BillOption : DomainEntity<int>, IDateTracking, ISwitchable
    {
        [Required]
        public string Workinghours { get; set; }   // Làm trong bao lâu

        [Required]
        public int Acreage { get; set; }     // Diện tích

        [Required]
        public int Rooms { get; set; }       // Số phòng

        [Required]
        public int Price { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public Status Status { get; set; }


        public virtual ICollection<Bill> Bills { get; set; }


        public virtual ICollection<BillOptionHelperNumber> BillOptionHelperNumbers { get; set; }
    }
}
