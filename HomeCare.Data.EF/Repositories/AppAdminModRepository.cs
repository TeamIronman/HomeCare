using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class AppAdminModRepository : EFRepository<AppAdmin, string>, IAppAdminModRepository
    {
        private readonly AppDbContext _context;
        
        public AppAdminModRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
