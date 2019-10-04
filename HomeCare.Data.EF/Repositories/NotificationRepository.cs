using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HomeCare.Data.EF.Repositories
{
    public class NotificationRepository : EFRepository<Notification, string>, INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
