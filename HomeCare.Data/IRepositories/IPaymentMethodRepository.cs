using HomeCare.Data.Entities;
using HomeCare.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.IRepositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod, int>
    {
    }
}
