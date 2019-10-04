using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Customer
{
    // Dùng lúc Customer muốn xem chi tiết bill và lúc hiển thị Bill ra trang Index
    public class CustomerBillDetailViewModel
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

        [Required]
        public string Workinghours { get; set; }   // Làm trong bao lâu

        [Required]
        public int Acreage { get; set; }     // Diện tích

        [Required]
        public int Rooms { get; set; }       // Số phòng

        [Required]
        public int Price { get; set; }

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

        public BillStatus BillStatus { get; set; }

        public string PaymentMethodName { get; set; }
        

        public string HelperId { get; set; }
    }
}
