using HomeCare.Data.Enums;
using HomeCare.Data.Interfaces;
using HomeCare.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCare.Data.Entities
{
    [Table("Reviews")]
    public class Review : DomainEntity<int>, IDateTracking, ISwitchable
    {
        
        public int Starcount { get; set; }

        public ReviewStatus ReviewStatus { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }


        public string CustomerId { get; set; }


        public string HelperId { get; set; }


        [ForeignKey("CustomerId")]
        public virtual AppCustomer AppCustomer { get; set; }


        [ForeignKey("HelperId")]
        public virtual AppHelper AppHelper { get; set; }
    }
}
