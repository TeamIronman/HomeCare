using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Admin.Controllers
{
    public class HelpernumberController : BaseController
    {
        private readonly IHelperService _helperService;

        public HelpernumberController(IHelperService helperService)
        {
            _helperService = helperService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllPaging(int? keyword, int page, int pageSize)
        {
            var model = _helperService.GetAllHelperNumber(keyword, page, pageSize);

            return new OkObjectResult(model);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _helperService.GetHelperNumberById(id);

            return new OkObjectResult(model);
        }


        [HttpPost]
        public IActionResult SaveEntity(CuHelperNumberViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    var result = _helperService.AddHelperNumber(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    else
                    {
                        return new OkObjectResult(new GenericResult(result, "Amount value is already exits"));
                    }
                }
                else
                {
                    var result = _helperService.UpdateHelperNumber(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    if (result == 2)
                    {
                        return new OkObjectResult(new GenericResult(result, "Same amount value, No update needed"));
                    }
                    if (result == 0)
                    {
                        return new OkObjectResult(new GenericResult(result, "Amount value is already exits"));
                    }
                }
            }

            return new BadRequestObjectResult(new GenericResult(6, viewmodel));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _helperService.Delete(id);

            return new OkObjectResult(new ResultEmpty());
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _helperService.GetAllForBIOPage();

            return new OkObjectResult(result);
        }
    }
}