using HomeCare.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface INotificationService
    {
        NotificationViewModel GetNotificationforCu();

        NotificationViewModel GetNotificationforHe(string Password);
    }
}
