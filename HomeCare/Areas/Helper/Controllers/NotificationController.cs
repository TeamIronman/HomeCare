using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Areas.Helper.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetNotification(string Password)
        {
            var result = _notificationService.GetNotificationforHe(Password);

            if (result.Id != null)
            {
                return new OkObjectResult(new GenericResult(1, result));
            }
            else
            {
                return new OkObjectResult(new GenericResult(0, "Incorrect Password"));
            }
        }
    }
}