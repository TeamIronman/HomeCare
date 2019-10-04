using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class BillRepository : EFRepository<Bill, int>, IBillRepository
    {
        private readonly AppDbContext _context;

        public BillRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
