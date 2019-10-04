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
    public class HelperController : BaseController
    {
        private readonly IHelperService _helperService;


        public HelperController(IHelperService helperService)
        {
            _helperService = helperService;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetHelperforBill(string helperId)
        {
            var result = _helperService.GetHelperForBill(helperId);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, string birthday, int page, int pageSize)
        {
            var result = _helperService.GetAllPaging(keyword, birthday, page, pageSize);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetById(string id)
        {
            var result = _helperService.GetHelperByIdForAd(id);

            return new OkObjectResult(result);
        }


        [HttpPost]
        public IActionResult SaveEntity(AdHelperViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(viewmodel.Id))
                {
                    var result = _helperService.AddHelper(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    if (result == 0)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate UserName"));
                    }
                    if (result == -1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate Email"));
                    }
                    if (result == -2)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate IDcard"));
                    }
                }
                else
                {
                    var result = _helperService.UpdateHelper(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    if (result == 0)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate UserName"));
                    }
                    if (result == -1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate Email"));
                    }
                    if (result == -2)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate IDcard"));
                    }
                }
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }


        [HttpPost]
        public IActionResult Delete(string id)
        {
            _helperService.DeleteHelper(id);

            return new OkObjectResult(new ResultEmpty());
        }
    }
}