using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeCare.Models;
using HomeCare.Application.Interfaces;

namespace HomeCare.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBillService _billService;
        private readonly IBillCancelNumberService _billCancelNumberService;
        private readonly ICustomerService _customerService;

        public HomeController(IBillService billService, IBillCancelNumberService billCancelNumberService,
                              ICustomerService customerService)
        {
            _billService = billService;
            _billCancelNumberService = billCancelNumberService;
            _customerService = customerService;
        }

        public IActionResult Index(string keyword, int page = 1, int pageSize = 7)
        {
            ViewData["BodyClass"] = "blog_fullwidth_page";

            var homevm = new HomeViewModel();

            homevm.customerBillDetailViewModels = _billService.GetBillForCustomer(keyword, page, pageSize);

            homevm.billCancelNumberViewModel = _billCancelNumberService.GetCuBillCancelNumber();

            homevm.NumberCancelBill = _customerService.GetCuBillCancel();

            return View(homevm);
        }

        
    }
}
