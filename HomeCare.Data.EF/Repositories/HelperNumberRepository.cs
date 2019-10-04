using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class HelperNumberRepository : EFRepository<HelperNumber, int>, IHelperNumberRepository
    {
        private readonly AppDbContext _context;

        public HelperNumberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
