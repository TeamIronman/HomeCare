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
    public class BillOptionController : BaseController
    {
        private readonly IBillService _billService;

        public BillOptionController(IBillService billService)
        {
            _billService = billService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var result = _billService.GetBillOptionForAdmin(keyword, page, pageSize);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _billService.GetBillOptionByIdForAdmin(id);

            return new OkObjectResult(result);
        }


        [HttpPost]
        public IActionResult SaveEntity(AdminBillOptionViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    var result = _billService.AddBillOption(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    else
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate acreage and rooms"));
                    }
                }
                else
                {
                    var result = _billService.UpdateBillOption(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save successfully"));
                    }
                    else
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate acreage and rooms"));
                    }
                }
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _billService.DeleteBillOption(id);

            return new OkObjectResult(new ResultEmpty());
        }
    }
}