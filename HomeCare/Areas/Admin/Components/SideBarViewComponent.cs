using HomeCare.Application.Common;
using HomeCare.Application.Common.Admin;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCare.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IFunctionService _functionService;
        private readonly IAppAdminModService _appAdminModService;
        private readonly IRoleService _roleService;

        public SideBarViewComponent(IFunctionService functionService, IAppAdminModService appAdminModService,
            IRoleService roleService)
        {
            _functionService = functionService;
            _appAdminModService = appAdminModService;
            _roleService = roleService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<FunctionViewModel> functions;
            var session = HttpContext.Session.Get<AdminModLogin>(CommonConstants.ADMIN_MOD_SESSION);

            List<string> rolename = _roleService.GetRoleNameBySession(session);

            if (rolename.Contains(CommonConstants.Admin))
            {
                functions = await _functionService.GetAllAsync();
            }
            else
            {
                functions = new List<FunctionViewModel>();
            }

            return View(functions);
        }
    }
}
