using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Common;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;

        public AccountController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(CuRegisterViewModel curevm)
        {
            if (ModelState.IsValid)
            {
                curevm.Password = Encryptor.MD5Hash(curevm.Password);

                var result = _customerService.CuRegister(curevm);

                if (result == 1)
                {
                    return new OkObjectResult(new GenericResult(1, "Successfully Registered"));
                }
                if (result == 0)
                {
                    return new OkObjectResult(new GenericResult(0, "UserName or Email already exits"));
                }                
            }

            return new BadRequestObjectResult(new GenericResult(6, curevm));
        }
    }
}