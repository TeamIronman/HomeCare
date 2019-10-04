using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class BillOptionRepository : EFRepository<BillOption, int>, IBillOptionRepository
    {
        private readonly AppDbContext _context;

        public BillOptionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int RecentlyAddedId(BillOption model)
        {
            _context.Add(model);

            _context.SaveChanges();

            return model.Id;
        }
    }
}
