using HomeCare.Data.Entities;
using HomeCare.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCare.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            if (_context.AppRoles.Count() == 0)
            {
                List<AppRole> roles = new List<AppRole>()
                {
                    new AppRole() {Name = "Admin", Description = "Administrator"},
                    new AppRole() {Name = "Staff", Description = "Staff"},
                    new AppRole() {Name = "Customer", Description = "Customer",
                        AppCustomers = new List<AppCustomer>()
                        {
                            new AppCustomer() {Id = "customer@gmail.com", UserName = "Customer", FullName = "Customer", Email = "customer@gmail.com",
                                               PhoneNumber = "111111", Password = "1111111", BirthDay = new DateTime(1992,6,18), Avatar = "/customer-side/images/customers/cus.png",
                                               Address = "156 Nguyen Van Linh", CancelBillNumber = 0, Status = Status.Active}
                        }
                    },
                    new AppRole() {Name = "Helper", Description = "Helper",
                        AppHelpers = new List<AppHelper>()
                        {
                            new AppHelper() {Id = "helper@gmail.com", UserName = "Helper", FullName = "Helper", Email = "helper@gmail.com",
                                             PhoneNumber = "222222", Password = "2222222", IDcard = "201944888", BirthDay = new DateTime(1976,5,14),
                                             Address = "350 Le Duan", CancelBillNumber = 0, Paymoney = 500000, Status = Status.Active}
                        }
                    }
                };

                _context.AppRoles.AddRange(roles);

                _context.SaveChanges();
            }


            if (_context.AppAdmins.Count() == 0)
            {
                AppAdmin admin = new AppAdmin()
                {
                    Id = "admin@gmail.com",
                    UserName = "BTARIES",
                    FullName = "BaThien Tran",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0905777777",
                    Password = "7777777",
                    BirthDay = new DateTime(1990, 4, 12),
                    Avatar = "/admin-side/images/adminstaffs/admin.png",
                    Address = "12 Le Dai Hanh",
                    Status = Status.Active,                   
                };

                _context.AppAdmins.Add(admin);

                var roleIdlist = from a in _context.AppRoles
                                 where a.Name.Contains("Admin")
                                 select a.Id;

                foreach (Guid roleId in roleIdlist )
                {
                    _context.AppAdminModRoles.Add(new AppAdminModRole()
                    {
                        RoleId = roleId,
                        AdminModId = "admin@gmail.com"
                    });
                }

                _context.SaveChanges();
            }


            if(_context.Functions.Count() == 0)
            {
                List<Function> functions = new List<Function>()
                {
                    new Function() {Id = "ACCOUNTSYSTEM", Name = "Account System",ParentId = null, SortOrder = 1, Status = Status.Active, URL = "/", IconCss = "fa-users"},
                    new Function() {Id = "BILLMANAGEMENT", Name = "Bill Management",ParentId = null, SortOrder = 2, Status = Status.Active, URL = "/", IconCss = "fa-list-alt"},
                    new Function() {Id = "EVALUATE", Name = "Evaluate",ParentId = null, SortOrder = 3, Status = Status.Active, URL = "/", IconCss = "fa-star"},


                    new Function() {Id = "ADMINSTAFF", Name = "Admin Staff",ParentId = "ACCOUNTSYSTEM", SortOrder = 1, Status = Status.Active, URL = "/admin/adminstaff/index", IconCss = "fa-user"},
                    new Function() {Id = "CUSTOMER", Name = "Customer",ParentId = "ACCOUNTSYSTEM", SortOrder = 2, Status = Status.Active, URL = "/admin/customer/index", IconCss = "fa-user"},
                    new Function() {Id = "HELPER", Name = "Helper",ParentId = "ACCOUNTSYSTEM", SortOrder = 3, Status = Status.Active, URL = "/admin/helper/index", IconCss = "fa-user"},
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "ACCOUNTSYSTEM", SortOrder = 4, Status = Status.Active, URL = "/admin/role/index", IconCss = "fa-sitemap"},
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "ACCOUNTSYSTEM", SortOrder = 5, Status = Status.Active, URL = "/admin/function/index", IconCss = "fa-share-alt-square"},


                    new Function() {Id = "BILL", Name = "Bill",ParentId = "BILLMANAGEMENT", SortOrder = 1, Status = Status.Active, URL = "/admin/bill/index", IconCss = "fa-list-alt"},
                    new Function() {Id = "BILLCANCELNUMBER", Name = "BillCancelNumber",ParentId = "BILLMANAGEMENT", SortOrder = 2, Status = Status.Active, URL = "/admin/billcancelnumber/index", IconCss = "fa-list-alt"},
                    new Function() {Id = "BILLOPTION", Name = "Bill Option",ParentId = "BILLMANAGEMENT", SortOrder = 3, Status = Status.Active, URL = "/admin/billoption/index", IconCss = "fa-list-alt"},
                    new Function() {Id = "HELPERNUMBER", Name = "Helper Number",ParentId = "BILLMANAGEMENT", SortOrder = 4, Status = Status.Active, URL = "/admin/helpernumber/index", IconCss = "fa-list-alt"},
                    new Function() {Id = "NOTIFICATION", Name = "Notification",ParentId = "BILLMANAGEMENT", SortOrder = 5, Status = Status.Active, URL = "/admin/notification/index", IconCss = "fa-list-alt"},
                    new Function() {Id = "PAYMENTMETHOD", Name = "Paymentmethod",ParentId = "BILLMANAGEMENT", SortOrder = 6, Status = Status.Active, URL = "/admin/paymentmethod/index", IconCss = "fa-list-alt"},


                    new Function() {Id = "REVIEW", Name = "Review",ParentId = "EVALUATE", SortOrder = 1, Status = Status.Active, URL = "/admin/review/index", IconCss = "fa-star"}
                };

                _context.Functions.AddRange(functions);

                _context.SaveChanges();
            }


            if(_context.PaymentMethods.Count() == 0)
            {
                List<PaymentMethod> pm = new List<PaymentMethod>()
                {
                    new PaymentMethod() {Name = "Cash", Description = "Cash"},
                    new PaymentMethod() {Name = "Visa", Description = "Visa"},
                    new PaymentMethod() {Name = "MasterCard", Description = "MasterCard"},
                    new PaymentMethod() {Name = "PayPal", Description = "PayPal"},
                    new PaymentMethod() {Name = "Momo", Description = "Momo"}
                };

                _context.PaymentMethods.AddRange(pm);

                _context.SaveChanges();
            }


            if (_context.HelperNumbers.Count() == 0)
            {
                List<HelperNumber> hpn = new List<HelperNumber>()
                {
                    new HelperNumber() {Amount = 1},
                    new HelperNumber() {Amount = 2},
                    new HelperNumber() {Amount = 3}
                };

                _context.HelperNumbers.AddRange(hpn);

                _context.SaveChanges();
            }


            if (_context.BillOptions.Count() == 0)
            {                

                List<BillOption> bio = new List<BillOption>()
                {
                    new BillOption() {Workinghours = "2h", Acreage = 55, Rooms = 2, Price = 120000, Status = Status.Active,
                        BillOptionHelperNumbers = new List<BillOptionHelperNumber>()
                        {
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 1).Id}
                        }
                    },
                    new BillOption() {Workinghours = "3h", Acreage = 85, Rooms = 3, Price = 150000, Status = Status.Active,
                        BillOptionHelperNumbers = new List<BillOptionHelperNumber>()
                        {
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 1).Id},
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 2).Id}
                        }
                    },
                    new BillOption() {Workinghours = "4h", Acreage = 105, Rooms = 4, Price = 190000, Status = Status.Active,
                        BillOptionHelperNumbers = new List<BillOptionHelperNumber>()
                        {
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 2).Id},
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 3).Id}                            
                        }
                    },
                    new BillOption() {Workinghours = "5h", Acreage = 125, Rooms = 5, Price = 225000, Status = Status.Active,
                        BillOptionHelperNumbers = new List<BillOptionHelperNumber>()
                        {                            
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 2).Id},
                            new BillOptionHelperNumber() {HelperNumberId = _context.HelperNumbers.SingleOrDefault(x => x.Amount == 3).Id}
                        }
                    }
                };

                _context.BillOptions.AddRange(bio);

                _context.SaveChanges();
            }
            
           
            if (_context.Notifications.Count() == 0)
            {
                List<Notification> notifications = new List<Notification>()
                {
                    new Notification()
                    {
                        Id = "CUSTOMER",
                        Name = "Customer Notification",
                        Title = "Note when canceling work",
                        Content = "When you cancel the bill more than four times, you cannot order bills within a week"
                    },
                    new Notification()
                    {
                        Id = "HELPER",
                        Name = "Helper Notification",
                        Title = "Note when canceling work",
                        Content = "When you voluntarily cancel the bill more than three times, you cannot receive bills within a week. " +
                                  "In case, you cancel the bill because customer cancel it, you will not be penalized."
                    }
                };

                _context.Notifications.AddRange(notifications);

                _context.SaveChanges();
            }


            if (_context.BillCancelNumbers.Count() == 0)
            {
                List<BillCancelNumber> billCancelNumbers = new List<BillCancelNumber>()
                {
                    new BillCancelNumber() {Id = "CUSTOMER", Number = 4},
                    new BillCancelNumber() {Id = "HELPER", Number = 3 }
                };

                _context.BillCancelNumbers.AddRange(billCancelNumbers);

                _context.SaveChanges();
            }
        }
    }
}
