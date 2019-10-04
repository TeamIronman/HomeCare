using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Helper.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IBillService _billService;


        public HomeController(IBillService billService)
        {
            _billService = billService;
        }

        public IActionResult Index(string keyword, int page = 1, int pageSize = 7)
        {
            ViewData["BodyClass"] = "blog_fullwidth_page";

            var model = _billService.GetBillForHelper(keyword, page, pageSize);

            return View(model);
        }
    }
}