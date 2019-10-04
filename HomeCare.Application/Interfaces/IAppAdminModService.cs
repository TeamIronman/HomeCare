using HomeCare.Application.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCare.Application.Interfaces
{
    public interface IAppAdminModService
    {
        int AdModLogin(AdModLoginViewModel vm);

        AdminModLayoutViewModel GetAdMod(string id);
    }
}
