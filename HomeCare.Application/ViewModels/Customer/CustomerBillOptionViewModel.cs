using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Customer
{
    public class CustomerBillOptionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Workinghours { get; set; }   // Làm trong bao lâu

        [Required]
        public int Acreage { get; set; }     // Diện tích

        [Required]
        public int Rooms { get; set; }       // Số phòng

        [Required]
        public int Price { get; set; }
    }
}
