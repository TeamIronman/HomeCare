using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("Notifications")]
    public class Notification : DomainEntity<string>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
