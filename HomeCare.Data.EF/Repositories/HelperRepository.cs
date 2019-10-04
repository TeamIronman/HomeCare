using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class HelperRepository : EFRepository<AppHelper, string>, IHelperRepository
    {
        private readonly AppDbContext _context;

        public HelperRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
