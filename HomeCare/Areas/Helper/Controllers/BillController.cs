using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Application.ViewModels.Helper;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Helper.Controllers
{
    public class BillController : BaseController
    {
        private readonly IBillService _billService;
        private readonly IHelperCheckService _helperCheckService;

        public BillController(IBillService billService, IHelperCheckService helperCheckService)
        {
            _billService = billService;
            _helperCheckService = helperCheckService;
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _billService.GetBillForHelper(id);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetBillStatus(int id)
        {
            var result = _billService.GetBillStatus(id);
            return new OkObjectResult(new GenericResult(result, "BillStatus"));
        }


        [HttpPost]
        public IActionResult AcceptBill(int id)
        {
            _helperCheckService.BillAccept(id);

            return new OkObjectResult(new ResultEmpty());
        }


        [HttpPost]
        public IActionResult SingleCheck(HeCheckViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = _helperCheckService.CheckSingle(vm);

                if (result == 0)
                {
                    return new OkObjectResult(new GenericResult(0, "Incorrect password"));
                }
                if (result == -1)
                {
                    return new OkObjectResult(new GenericResult(-1, "Wrong checking time"));
                }
                if (result == -2)
                {
                    return new OkObjectResult(new GenericResult(-2, "You don't check enough"));
                }
                if (result == 1)
                {
                    return new OkObjectResult(new GenericResult(1, "First checking successful"));
                }
                if (result == 2)
                {
                    return new OkObjectResult(new GenericResult(2, "Second checking successful"));
                }
                if (result == 3)
                {
                    return new OkObjectResult(new GenericResult(3, "You have completed the bill"));
                }
            }

            return new BadRequestObjectResult(new GenericResult(6, vm));
        }


        [HttpPost]
        public IActionResult CancelBill(int id)
        {
            if (ModelState.IsValid)
            {
                _helperCheckService.BillCancel(id);
                
                return new OkObjectResult(new GenericResult("Cancel the bill successfully"));
                
            }

            return new BadRequestObjectResult(new EmptyResult());
        }
    }
}