using HomeCare.Application.ViewModels;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCare.Models
{
    public class HomeViewModel
    {
        public PagedResult<CustomerBillDetailViewModel> customerBillDetailViewModels { get; set; }

        public BillCancelNumberViewModel billCancelNumberViewModel { get; set; }

        public int NumberCancelBill { get; set; }
    }
}
