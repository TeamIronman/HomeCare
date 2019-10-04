using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Admin
{
    public class HelperCorrespondingBillViewModel
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }        

        [Required]
        public string IDcard { get; set; }

        [Required]
        public string BirthDay { get; set; }

        [Required]
        public string Address { get; set; }

        public int CancelBillNumber { get; set; }

        [Required]
        public int Paymoney { get; set; }

        public Status Status { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }
    }
}
