using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeCare.Application.ViewModels.Admin
{
    public class AdminBillViewModel
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
        public string Workinghours { get; set; }   

        [Required]
        public int Acreage { get; set; }               

        [Required]
        public int Rooms { get; set; }                 

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

        public string PaymentMethodName { get; set; }

        public BillStatus BillStatus { get; set; }

        public Status Status { get; set; }               
        
        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string HelperId { get; set; }

        public bool? Firstcheck { get; set; }

        public bool? Secondcheck { get; set; }

        public bool? Thirdcheck { get; set; }

        public bool? Cancel { get; set; }

    }
}
