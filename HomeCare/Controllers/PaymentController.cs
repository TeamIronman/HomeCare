using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public IActionResult GetPaymentMethod()
        {
            var result = _paymentMethodService.GetAllPaymentMethod();

            return new OkObjectResult(result);
        }
    }
}