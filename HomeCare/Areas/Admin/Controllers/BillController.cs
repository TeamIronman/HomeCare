using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Admin.Controllers
{
    public class BillController : BaseController
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, string workdate, int page, int pageSize)
        {
            var viewmodel = _billService.GetBillForAdmin(keyword, workdate, page, pageSize);

            return new OkObjectResult(viewmodel);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var vm = _billService.GetByIdForAdmin(id);

            return new OkObjectResult(vm);
        }


        [HttpPost]
        public IActionResult SaveEntity(AdminBillViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _billService.SaveBill(vm);

                return new OkObjectResult(new ResultEmpty());
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }


        [HttpPost]
        public IActionResult DeleteBill(int id)
        {
            if (ModelState.IsValid)
            {
                _billService.AdDeleteBill(id);

                return new OkObjectResult(new ResultEmpty());
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }
    }
}