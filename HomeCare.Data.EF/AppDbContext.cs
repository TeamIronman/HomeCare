using HomeCare.Data.Entities;
using HomeCare.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeCare.Data.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<AppAdmin> AppAdmins { get; set; }

        public DbSet<AppAdminModRole> AppAdminModRoles { get; set; }

        public DbSet<AppCustomer> AppCustomers { get; set; }

        public DbSet<AppHelper> AppHelpers { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<BillCancelNumber> BillCancelNumbers { get; set; }

        public DbSet<BillOption> BillOptions { get; set; }

        public DbSet<BillOptionHelperNumber> BillOptionHelperNumbers { get; set; }

        public DbSet<Function> Functions { get; set; }

        public DbSet<HelperCheck> HelperChecks { get; set; }

        public DbSet<HelperImage> HelperImages { get; set; }

        public DbSet<HelperNumber> HelperNumbers { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Review> Reviews { get; set; }


        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);


            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;

                    }
                    else
                    {
                        changedOrAddedItem.DateModified = DateTime.Now;

                    }
                }
            }
            return base.SaveChanges();
        }
    }


    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
