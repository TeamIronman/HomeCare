using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Admin
{
    public class AppRoleViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }


        [StringLength(250)]
        public string Description { get; set; }
    }
}
