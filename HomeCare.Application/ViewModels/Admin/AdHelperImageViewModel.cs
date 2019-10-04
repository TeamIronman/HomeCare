using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Admin
{
    public class AdHelperImageViewModel
    {
        public int Id { get; set; }

        public string HelperId { get; set; }
       
        [Required]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }
    }
}
