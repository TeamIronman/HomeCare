using HomeCare.Application.Common;
using HomeCare.Application.Common.Admin;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Data.Enums;
using HomeCare.Data.IRepositories;
using HomeCare.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCare.Application.Implementation
{
    public class AppAdminModService : IAppAdminModService
    {
        private readonly IAppAdminModRepository _appAdminModRepository;
        private readonly IHttpContextAccessor _accessor;

        public AppAdminModService(IAppAdminModRepository appAdminModRepository, IHttpContextAccessor accessor)
        {
            _appAdminModRepository = appAdminModRepository;
            _accessor = accessor;
        }

        public int AdModLogin(AdModLoginViewModel vm)
        {
            var result = _appAdminModRepository.FindSingle(x => x.UserName == vm.UserName);

            if (result == null)
            {
                return 0; // Incorrect UserName
            }
            else
            {
                if (result.Password == vm.Password)
                {
                    if (result.Status == Status.Active)
                    {
                        var session = new AdminModLogin()
                        {
                            Id = result.Id,
                            UserName = result.UserName
                        };

                        var httpContext = _accessor.HttpContext;

                        httpContext.Session.Set(CommonConstants.ADMIN_MOD_SESSION, session);

                        return 1;
                    }
                    else
                    {
                        return -2; // Account is Locked
                    }
                }
                else
                {
                    return -1; // Incorrect Password
                }
            }
        }

        public AdminModLayoutViewModel GetAdMod(string id)
        {
            var admod = _appAdminModRepository.FindById(id);

            var vm = new AdminModLayoutViewModel()
            {
                Id = admod.Id,
                UserName = admod.UserName,
                FullName = admod.FullName,
                Avatar = admod.Avatar
            };

            return vm;
        }
    }
}
