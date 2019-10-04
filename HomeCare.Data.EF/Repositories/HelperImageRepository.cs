using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class HelperImageRepository : EFRepository<HelperImage, int>, IHelperImageRepository
    {
        private readonly AppDbContext _context;

        public HelperImageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
