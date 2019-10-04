using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("HelperImages")]
    public class HelperImage : DomainEntity<int>
    {
        
        public string HelperId { get; set; }

        [ForeignKey("HelperId")]
        public virtual AppHelper AppHelper { get; set; }

        [Required]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }
    }
}
