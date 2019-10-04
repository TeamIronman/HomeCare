using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class HelperCheckRepository : EFRepository<HelperCheck, int>, IHelperCheckRepository
    {
        private readonly AppDbContext _context;

        public HelperCheckRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
