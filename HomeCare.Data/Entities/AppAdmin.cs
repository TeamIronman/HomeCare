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
    [Table("AppAdmins")]
    public class AppAdmin : DomainEntity<string>, IDateTracking, ISwitchable
    {

        public AppAdmin()
        {
            AppAdminModRoles = new HashSet<AppAdminModRole>();
        }
                       

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

        public string Address { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        
        public virtual ICollection<AppAdminModRole> AppAdminModRoles { get; set; }
    }
}
