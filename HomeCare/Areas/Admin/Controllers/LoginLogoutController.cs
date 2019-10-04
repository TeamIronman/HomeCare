using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Common;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Utilities.Constants;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginLogoutController : Controller
    {
        private readonly IAppAdminModService _appAdminModService;

        public LoginLogoutController(IAppAdminModService appAdminModService)
        {
            _appAdminModService = appAdminModService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(AdModLoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Password = Encryptor.MD5Hash(vm.Password);

                var result = _appAdminModService.AdModLogin(vm);

                if (result == 0)
                {
                    return new OkObjectResult(new GenericResult(result, "Incorrect UserName"));
                }
                if (result == 1)
                {
                    return new OkObjectResult(new GenericResult(result, "Logged in successfully"));
                }
                if (result == -1)
                {
                    return new OkObjectResult(new GenericResult(result, "Incorrect Password"));
                }
                if (result == -2)
                {
                    return new OkObjectResult(new GenericResult(result, "Account is locked"));
                }
            }

            return new BadRequestObjectResult(new GenericResult(6, vm));
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CommonConstants.ADMIN_MOD_SESSION);

            return Redirect("/Admin/LoginLogout/Index");
        }
    }
}