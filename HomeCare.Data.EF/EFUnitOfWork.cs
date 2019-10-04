using HomeCare.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;

        public EFUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
