using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class CustomerRepository : EFRepository<AppCustomer, string>, ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
