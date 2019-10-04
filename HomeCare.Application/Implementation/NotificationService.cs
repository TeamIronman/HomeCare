using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using HomeCare.Application.Common.Helper;
using HomeCare.Utilities.Constants;
using HomeCare.Application.Common;

namespace HomeCare.Application.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHelperRepository _helperRepository;

        public NotificationService(INotificationRepository notificationRepository,
            IHttpContextAccessor accessor, IHelperRepository helperRepository)
        {
            _notificationRepository = notificationRepository;
            _accessor = accessor;
            _helperRepository = helperRepository;
        }

        public NotificationViewModel GetNotificationforCu()
        {
            var notification = _notificationRepository.FindById("CUSTOMER");

            var vm = new NotificationViewModel()
            {
                Id = notification.Id,
                Name = notification.Name,
                Title = notification.Title,
                Content = notification.Content
            };

            return vm;
        }


        public NotificationViewModel GetNotificationforHe(string Password)
        {
            var httpContext = _accessor.HttpContext;
            var helpersession = httpContext.Session.Get<HelperLogin>(CommonConstants.HELPER_SESSION);   // Lấy thông tin của helper nhận bill

            var helper = _helperRepository.FindById(helpersession.Id);   // Tìm helper trong DB

            Password = Encryptor.MD5Hash(Password);

            var vm = new NotificationViewModel();

            if (helper.Password == Password)
            {
                var notification = _notificationRepository.FindById("HELPER");

                vm.Id = notification.Id;
                vm.Name = notification.Name;
                vm.Title = notification.Title;
                vm.Content = notification.Content;

                return vm;

            }
            else
            {
                vm.Id = null;
                vm.Name = null;
                vm.Title = null;
                vm.Content = null;

                return vm;
            }
          
            
        }
    }
}
