using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntity<int>
    {
         
        public bool CanCreate { get; set; }

        public bool CanRead { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }


        public string FunctionId { get; set; }

        public Guid RoleId { get; set; }
        

        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }


        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set;}
    }
}
