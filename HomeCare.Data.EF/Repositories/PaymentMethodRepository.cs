using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class PaymentMethodRepository : EFRepository<PaymentMethod, int>, IPaymentMethodRepository
    {
        private readonly AppDbContext _context;

        public PaymentMethodRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
