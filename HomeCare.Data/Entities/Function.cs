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
    [Table("Functions")]
    public class Function : DomainEntity<string>, ISwitchable
    {
        public Function()
        {
            Permissions = new HashSet<Permission>();
        }

        

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]        
        public string URL { get; set; }

        [StringLength(128)]
        public string ParentId { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }


        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
