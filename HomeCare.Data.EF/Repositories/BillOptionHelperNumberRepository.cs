using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class BillOptionHelperNumberRepository : EFRepository<BillOptionHelperNumber, int>, IBillOptionHelperNumberRepository
    {
        private readonly AppDbContext _context;

        public BillOptionHelperNumberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
