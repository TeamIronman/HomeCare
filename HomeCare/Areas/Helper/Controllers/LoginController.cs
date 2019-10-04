using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Common;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Helper;
using HomeCare.Utilities.Constants;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Helper.Controllers
{
    [Area("Helper")]
    public class LoginController : Controller
    {
        private readonly IHelperService _helperService;

        public LoginController(IHelperService helperService)
        {
            _helperService = helperService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(HeLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Encryptor.MD5Hash(model.Password);

                var result = _helperService.HeLogin(model);

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
            HttpContext.Session.Remove(CommonConstants.HELPER_SESSION);
            return Redirect("/Helper/Login/Index");
        }
    }
}