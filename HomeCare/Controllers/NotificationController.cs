using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeCare.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet]
        public IActionResult GetNotification()
        {
            var result = _notificationService.GetNotificationforCu();

            return new OkObjectResult(result);
        }
    }
}