using HomeCare.Application.Common;
using HomeCare.Application.Common.Admin;
using HomeCare.Application.Interfaces;
using HomeCare.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCare.Areas.Admin.Components
{
    public class MenuProfileViewComponent : ViewComponent
    {
        private readonly IAppAdminModService _appAdminModService;

        public MenuProfileViewComponent(IAppAdminModService appAdminModService)
        {
            _appAdminModService = appAdminModService;
        }


        public IViewComponentResult Invoke()
        {
            var session = HttpContext.Session.Get<AdminModLogin>(CommonConstants.ADMIN_MOD_SESSION);

            var result = _appAdminModService.GetAdMod(session.Id);

            return View(result);
        }

    }
}
