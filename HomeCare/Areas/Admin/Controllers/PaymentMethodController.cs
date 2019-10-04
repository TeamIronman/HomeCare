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
    public class PaymentMethodController : BaseController
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var result = _paymentMethodService.GetAllPaging(keyword, page, pageSize);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _paymentMethodService.GetById(id);

            return new OkObjectResult(result);
        }


        [HttpPost]
        public IActionResult SaveEntity(AdminPaymentMethodViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (viewmodel.Id == 0)
                {
                    var result = _paymentMethodService.AddPaymentMethod(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save Successfully"));
                    }
                    else
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate PaymentMethod Name"));
                    }
                }
                else
                {
                    var result = _paymentMethodService.UpdatePaymentMethod(viewmodel);

                    if (result == 1)
                    {
                        return new OkObjectResult(new GenericResult(result, "Save Successfully"));
                    }
                    if (result == 2)
                    {
                        return new OkObjectResult(new GenericResult(result, "No update needed"));
                    }
                    if (result == 0)
                    {
                        return new OkObjectResult(new GenericResult(result, "Duplicate PaymentMethod Name"));
                    }
                }
            }

            return new BadRequestObjectResult(new ResultEmpty());
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _paymentMethodService.DeletePaymentMethod(id);

            return new OkObjectResult(new ResultEmpty());
        }
    }
}