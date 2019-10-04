using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Helper
{
    public class HeCheckViewModel
    {
        //Id của bill
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }

        public bool? HPCheck { get; set; }
    }
}
