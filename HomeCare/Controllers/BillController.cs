using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HomeCare.Controllers
{
    public class BillController : BaseController
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _billService.GetByIdForCuEdit(id);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetBilltoView(int id)
        {
            var result = _billService.GetByIdForCuView(id);

            return new OkObjectResult(result);
        }

        
        [HttpGet]
        public IActionResult GetBillOption()
        {
            var result = _billService.GetBillOption();

            return new OkObjectResult(result);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _billService.Delete(id);

                return new OkObjectResult(new ResultEmpty());
            }
        }


        [HttpPost]
        public IActionResult SaveEntity(CustomerBillViewModel billvm, int henumberId)
        {
            if (ModelState.IsValid)           
            {
                if (billvm.Id == 0)
                {
                    var result = _billService.Add(billvm, henumberId);

                    if (result == 0)
                    {
                        return new OkObjectResult(new GenericResult(0, "Incorrect CustomerName"));
                    }
                    if (result == -1)
                    {
                        return new OkObjectResult(new GenericResult(-1, "Incorrect CustomerAddress"));
                    }
                    if (result == -2)
                    {
                        return new OkObjectResult(new GenericResult(-2, "Incorrect CustomerMobile"));
                    }
                    if (result == -3)
                    {
                        return new OkObjectResult(new GenericResult(-3, "Incorrect CustomerEmail"));
                    }
                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(1, "Adding bill successful"));
                    }
                }
                else
                {

                    var result = _billService.Update(billvm);
                                       
                    return new OkObjectResult(new GenericResult(result, "Updating bill successful"));
                    
                }
            }

            return new BadRequestObjectResult(new GenericResult(6, billvm));
        }


        [HttpGet]
        public IActionResult GetBillStatus(int id)
        {
            var result = _billService.GetBillStatus(id);
            return new OkObjectResult(new GenericResult(result, "BillStatus"));
        }


        [HttpGet]
        public IActionResult ChangeBillStatus(int id)
        {
            _billService.ChangeBillStatus(id);

            return new OkObjectResult(new ResultEmpty());
        }
    }
}