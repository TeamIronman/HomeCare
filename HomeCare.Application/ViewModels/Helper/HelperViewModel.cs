using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Helper
{
    public class HelperViewModel
    {
        public string Id { get; set; }        

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }        

        [Required]
        public string BirthDay { get; set; }

        [Required]
        public string Address { get; set; }               
        
    }
}
