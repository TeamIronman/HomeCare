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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;


        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, string birthday, int page, int pageSize)
        {
            var result = _customerService.GetAllPaging(keyword, birthday, page, pageSize);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetById(string id)
        {
            var result = _customerService.GetById(id);

            return new OkObjectResult(result);
        }


        [HttpPost]
        public IActionResult SaveEntity(AdCustomerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var result = _customerService.SaveCustomer(viewmodel);

                if (result == 0)
                {
                    return new OkObjectResult(new GenericResult(result, "Duplicate UserName"));
                }
                if (result == -1)
                {
                    return new OkObjectResult(new GenericResult(result, "Duplicate Email"));
                }
                if (result == 1)
                {
                    return new OkObjectResult(new GenericResult(result, "Save successfully"));
                }
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }


        [HttpPost]
        public IActionResult Delete(string id)
        {
            _customerService.DeleteCustomer(id);

            return new OkObjectResult(new ResultEmpty());
        }
    }
}