using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("AppRoles")]
    public class AppRole : DomainEntity<Guid>
    {
       
        [Required]
        public string Name { get; set; }


        [StringLength(250)]
        public string Description { get; set; }


        public virtual ICollection<AppAdminModRole> AppAdminModRoles { get; set; }

        public virtual ICollection<AppCustomer> AppCustomers { get; set; }

        public virtual ICollection<AppHelper> AppHelpers { get; set; }

    }
}
