using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Controllers
{
    public class HelperController : BaseController
    {

        private readonly IHelperService _helperService;


        public HelperController(IHelperService helperService)
        {
            _helperService = helperService;
        }

        [HttpGet]
        public IActionResult GetById(string id)
        {
            var result = _helperService.GetHelperById(id);

            return new OkObjectResult(result);
        }


        [HttpGet]
        public IActionResult GetHelperNumber(int id)
        {
            var result = _helperService.GetHeNumber(id);

            return new OkObjectResult(result);
        }
    }
}