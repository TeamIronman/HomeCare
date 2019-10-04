using HomeCare.Application.Common.Admin;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IRoleService
    {
        List<string> GetRoleNameBySession(AdminModLogin session);

        PagedResult<AppRoleViewModel> GetRolePaging(string keyword, int page, int pageSize);

        AppRoleViewModel GetById(Guid id);

        int AddRole(AppRoleViewModel vm);

        int UpdateRole(AppRoleViewModel vm);

        void DeleteRole(Guid Id);
    }
}
