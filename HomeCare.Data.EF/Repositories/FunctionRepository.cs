using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
    {
        private readonly AppDbContext _context;

        public FunctionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
