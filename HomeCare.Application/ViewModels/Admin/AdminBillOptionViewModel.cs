using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Admin
{
    public class AdminBillOptionViewModel
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

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public Status Status { get; set; }

        public List<string> NumberHelper { get; set; }
    }
}
