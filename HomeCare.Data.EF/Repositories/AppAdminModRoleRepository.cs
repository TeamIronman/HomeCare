using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class AppAdminModRoleRepository : EFRepository<AppAdminModRole, int>, IAppAdminModRoleRepository
    {
        private readonly AppDbContext _context;

        public AppAdminModRoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
