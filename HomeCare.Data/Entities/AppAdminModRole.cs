using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("AppAdminModRoles")]
    public class AppAdminModRole : DomainEntity<int>
    {
        public string AdminModId { get; set; }

        public Guid RoleId { get; set; }


        [ForeignKey("AdminModId")]
        public virtual AppAdmin AppAdmin { get; set; }


        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }
    }
}
