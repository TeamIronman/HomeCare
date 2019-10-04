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
    [Table("Bills")]
    public class Bill : DomainEntity<int>, IDateTracking, ISwitchable
    {
                  
        [Required]
        public string Workplace { get; set; }

        [Required]
        public string Apartmentnumber { get; set; }

        [Required]
        public DateTime Workday { get; set; }

        [Required]
        public string Starttime { get; set; }   // Thời gian bắt đầu làm
                                   
        public string Description { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        [Phone]
        public string CustomerMobile { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public BillStatus BillStatus { get; set; }

        public Status Status { get; set; }

        public int SortOrder { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public int BillOptionId { get; set; }

        public int PaymentMethodId { get; set; }

        public string CustomerId { get; set; }


        public string HelperId { get; set; }


        [ForeignKey("BillOptionId")]
        public virtual BillOption BillOption { get; set; }


        [ForeignKey("CustomerId")]
        public virtual AppCustomer AppCustomer { get; set; }


        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { get; set; }


        [ForeignKey("HelperId")]
        public virtual AppHelper AppHelper { get; set; }


        public virtual ICollection<HelperCheck> HelperChecks { get; set; }
    }
}
