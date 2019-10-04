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
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var result = _roleService.GetRolePaging(keyword, page, pageSize);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            AppRoleViewModel vm = _roleService.GetById(id);

            return new OkObjectResult(vm);
        }


        [HttpPost]
        public IActionResult SaveEntity(AppRoleViewModel vm)
        {
            if(ModelState.IsValid)
            {
                if (!vm.Id.HasValue)
                {
                    int result = _roleService.AddRole(vm);

                    if(result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    if(result == 0)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate Role's name"));
                    }
                }
                else
                {
                    int result = _roleService.UpdateRole(vm);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    if (result == 0)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate Role's name"));
                    }
                    if(result == 2)
                    {
                        return new OkObjectResult(new GenericResult(result, "No need to update"));
                    }
                }
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }

        [HttpPost]
        public IActionResult Delete(Guid Id)
        {
            _roleService.DeleteRole(Id);

            return new OkObjectResult(new ResultEmpty());
        }
    }
}