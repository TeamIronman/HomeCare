using HomeCare.Application.Common.Admin;
using HomeCare.Application.Interfaces;
using HomeCare.Data.IRepositories;
using HomeCare.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HomeCare.Utilities.Dtos;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Data.Entities;

namespace HomeCare.Application.Implementation
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppAdminModRepository _appAdminModRepository;
        private readonly IAppAdminModRoleRepository _appAdminModRoleRepository;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork,
            IAppAdminModRepository appAdminModRepository, IAppAdminModRoleRepository appAdminModRoleRepository)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _appAdminModRepository = appAdminModRepository;
            _appAdminModRoleRepository = appAdminModRoleRepository;
        }


        public List<string> GetRoleNameBySession(AdminModLogin session)
        {
            var admod = _appAdminModRepository.FindAll();

            var admodrole = _appAdminModRoleRepository.FindAll();

            var role = _roleRepository.FindAll();

            var query = from a in admod
                        join b in admodrole on a.Id equals b.AdminModId
                        join c in role on b.RoleId equals c.Id
                        where a.Id == session.Id
                        select c.Name;

            return query.ToList();
        }


        public PagedResult<AppRoleViewModel> GetRolePaging(string keyword, int page, int pageSize)
        {
            int totalRow;
            List<AppRoleViewModel> data = new List<AppRoleViewModel>();

            IQueryable<AppRole> query = _roleRepository.FindAll();

            if(!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Equals(keyword));
            }

            if(query.Any())
            {
                totalRow = query.Count();

                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                foreach(AppRole ar in query)
                {
                    AppRoleViewModel vm = new AppRoleViewModel()
                    {
                        Id = ar.Id,
                        Name = ar.Name,
                        Description = ar.Description
                    };

                    data.Add(vm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }

            PagedResult<AppRoleViewModel> paginationSet = new PagedResult<AppRoleViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }


        public AppRoleViewModel GetById(Guid id)
        {
            AppRole role = _roleRepository.FindById(id);

            AppRoleViewModel vm = new AppRoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };

            return vm;
        }


        public int AddRole(AppRoleViewModel vm)
        {
            AppRole duplicaterole = _roleRepository.FindSingle(x => x.Name.Equals(vm.Name));

            if(duplicaterole == null)
            {
                AppRole model = new AppRole()
                {
                    Name = vm.Name,
                    Description = vm.Description
                };

                _roleRepository.Add(model);

                _unitOfWork.Commit();

                return 1;
            }
            else
            {
                return 0; // duplicate role's name
            }
        }


        public int UpdateRole(AppRoleViewModel vm)
        {
            AppRole SpecifiedRole = _roleRepository.FindById(Guid.Parse(vm.Id.ToString()));

            if(SpecifiedRole.Name == vm.Name)
            {
                return 2; // No need to update
            }
            else
            {
                IQueryable<AppRole> RestofRole = _roleRepository.FindAll().Except(_roleRepository.FindAll(x => x.Id == vm.Id));

                AppRole SPRole = RestofRole.SingleOrDefault(x => x.Name == vm.Name);

                if(SPRole != null)
                {
                    return 0; // duplicate role's name
                }
                else
                {
                    SpecifiedRole.Name = vm.Name;
                    SpecifiedRole.Description = vm.Description;

                    _roleRepository.Update(SpecifiedRole);

                    _unitOfWork.Commit();

                    return 1;
                }
            }
        }


        public void DeleteRole(Guid Id)
        {
            _roleRepository.Remove(Id);

            _unitOfWork.Commit();
        }
    }
}
