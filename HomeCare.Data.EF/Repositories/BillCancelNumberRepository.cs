using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class BillCancelNumberRepository : EFRepository<BillCancelNumber, string>, IBillCancelNumberRepository
    {
        private readonly AppDbContext _context;

        public BillCancelNumberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
