using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Common;
using HomeCare.Application.Common.Customer;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Constants;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomerService _customerService;

        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(CuLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Encryptor.MD5Hash(model.Password);
                var result = _customerService.CuLogin(model);

                if (result == 0)
                {
                    return new OkObjectResult(new GenericResult(0, "Incorrect UserName"));
                }
                else
                {
                    if (result == 1)
                    {                        
                        return new OkObjectResult(new GenericResult(1, "Logged in successfully"));
                    }
                    if (result == -1)
                    {
                        return new OkObjectResult(new GenericResult(-1, "Incorrect Password"));
                    }
                    if (result == -2)
                    {
                        return new OkObjectResult(new GenericResult(-2, "Account is locked"));
                    }
                }
            }

            return new BadRequestObjectResult(new GenericResult(6, model));
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CommonConstants.CUSTOMER_SESSION);
            return Redirect("/Login/Index");
        }
    }
}