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
    [Table("AppCustomers")]
    public class AppCustomer : DomainEntity<string>, IDateTracking, ISwitchable
    {
       
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        
        public DateTime? BirthDay { get; set; }

        public string Avatar { get; set; }

        [Required]
        public string Address { get; set; }

        public int CancelBillNumber { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public Guid RoleId { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }


        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }
    }
}
