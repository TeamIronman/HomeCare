using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Customer
{
    // Dùng cho việc add và edit bill của Customer
    public class CustomerBillViewModel
    {
        
        public int Id { get; set; }

        [Required]
        public string Workplace { get; set; }

        [Required]
        public string Apartmentnumber { get; set; }

        [Required]
        public string Workday { get; set; }

        [Required]
        public string Starttime { get; set; }

        public string Description { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        [Phone]
        public string CustomerMobile { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        

        public int BillOptionId { get; set; }

        public int PaymentMethodId { get; set; }
        
    }
}
