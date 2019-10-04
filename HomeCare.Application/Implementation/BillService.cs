using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Data.IRepositories;
using HomeCare.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using HomeCare.Application.Common.Customer;
using HomeCare.Utilities.Constants;
using HomeCare.Application.Common;
using HomeCare.Data.Enums;
using AutoMapper.QueryableExtensions;
using HomeCare.Utilities.Dtos;
using HomeCare.Data.Entities;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Application.Common.Helper;
using HomeCare.Application.ViewModels.Helper;
using System.Globalization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Application.Implementation
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBillOptionRepository _billOptionRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IHelperNumberRepository _helperNumberRepository;
        private readonly IHelperRepository _helperRepository;
        private readonly IBillCancelNumberRepository _billCancelNumberRepository;
        private readonly IHelperCheckRepository _helperCheckRepository;
        private readonly IBillOptionHelperNumberRepository _billOptionHelperNumberRepository;

        public BillService(IBillRepository billRepository, IUnitOfWork unitOfWork,
            IHttpContextAccessor accessor, ICustomerRepository customerRepository,
            IBillOptionRepository billOptionRepository, IPaymentMethodRepository paymentMethodRepository,
            IHelperNumberRepository helperNumberRepository, IHelperRepository helperRepository,
            IBillCancelNumberRepository billCancelNumberRepository, IHelperCheckRepository helperCheckRepository,
            IBillOptionHelperNumberRepository billOptionHelperNumberRepository)
        {
            _billRepository = billRepository;
            _unitOfWork = unitOfWork;
            _accessor = accessor;
            _customerRepository = customerRepository;
            _billOptionRepository = billOptionRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _helperNumberRepository = helperNumberRepository;
            _helperRepository = helperRepository;
            _billCancelNumberRepository = billCancelNumberRepository;
            _helperCheckRepository = helperCheckRepository;
            _billOptionHelperNumberRepository = billOptionHelperNumberRepository;
        }

        public int Add(CustomerBillViewModel billvm, int helpernumberId)
        {
            var httpContext = _accessor.HttpContext;
            var customersession = httpContext.Session.Get<CustomerLogin>(CommonConstants.CUSTOMER_SESSION);


            var customer = _customerRepository.FindById(customersession.Id);


            if (!customer.FullName.Contains(billvm.CustomerName))
            {
                return 0;
            }
            else if (!customer.Address.Equals(billvm.CustomerAddress))
            {
                return -1;
            }
            else if (!customer.PhoneNumber.Equals(billvm.CustomerMobile))
            {
                return -2;
            }
            else if (!customer.Email.Equals(billvm.CustomerEmail))
            {
                return -3;
            }
            else
            {
                var henuamount = _helperNumberRepository.FindById(helpernumberId).Amount;


                for (int i = 1; i <= henuamount; i++)
                {
                    var bill = new Bill()
                    {
                        Workplace = billvm.Workplace,
                        Apartmentnumber = billvm.Apartmentnumber,
                        Workday = DateTime.ParseExact(billvm.Workday, "MM/dd/yyyy", CultureInfo.GetCultureInfo("vi-VN")),
                        Starttime = billvm.Starttime,
                        Description = billvm.Description,
                        CustomerName = billvm.CustomerName,
                        CustomerAddress = billvm.CustomerAddress,
                        CustomerMobile = billvm.CustomerMobile,
                        CustomerEmail = billvm.CustomerEmail,
                        BillStatus = BillStatus.New,
                        Status = Status.Active,
                        SortOrder = 1,
                        BillOptionId = billvm.BillOptionId,
                        PaymentMethodId = billvm.PaymentMethodId,
                        CustomerId = customersession.Id
                    };


                    _billRepository.Add(bill);

                }

                _unitOfWork.Commit();

                return 1;
            }
        }


        // được dùng lúc customer bấm edit bill nhưng không edit 
        public void ChangeBillStatus(int id)
        {
            var bill = _billRepository.FindById(id);

            bill.BillStatus = BillStatus.New;
            bill.SortOrder = 1;

            _billRepository.Update(bill);

            _unitOfWork.Commit();
        }


        public void Delete(int id)
        {
            var bill = _billRepository.FindById(id);

            bill.BillStatus = BillStatus.Cancelled;
            bill.SortOrder = 6;

            _billRepository.Update(bill);


            var httpContext = _accessor.HttpContext;
            var customersession = httpContext.Session.Get<CustomerLogin>(CommonConstants.CUSTOMER_SESSION);


            var customer = _customerRepository.FindById(customersession.Id);

            customer.CancelBillNumber = customer.CancelBillNumber + 1;  // Đếm số lần hủy của customer

            _customerRepository.Update(customer);

            _unitOfWork.Commit();
        }


        public PagedResult<CustomerBillDetailViewModel> GetBillForCustomer(string keyword, int page, int pageSize)
        {
            int totalRow;
            List<CustomerBillDetailViewModel> data = new List<CustomerBillDetailViewModel>();

            var httpContext = _accessor.HttpContext;
            var customersession = httpContext.Session.Get<CustomerLogin>(CommonConstants.CUSTOMER_SESSION);   // Lấy ID của khách hàng đặt bill

            var query = _billRepository.FindAll(x => x.CustomerId == customersession.Id && x.Status == Status.Active);


            query = query.Where(x => x.BillStatus == BillStatus.New || x.BillStatus == BillStatus.Inprocess
                                     || x.BillStatus == BillStatus.Completed);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Workplace.Contains(keyword) || x.Apartmentnumber.Contains(keyword));
            }


            if (query.Any())
            {
                totalRow = query.Count();

                query = query.OrderBy(x => x.SortOrder).Skip((page - 1) * pageSize)
                    .Take(pageSize);


                foreach (Bill bill in query)
                {
                    var billoption = _billOptionRepository.FindById(bill.BillOptionId);

                    var payment = _paymentMethodRepository.FindById(bill.PaymentMethodId);

                    var cubilldetailviewmodel = new CustomerBillDetailViewModel()
                    {
                        Id = bill.Id,
                        Workplace = bill.Workplace,
                        Apartmentnumber = bill.Apartmentnumber,
                        Workday = bill.Workday.ToString("MM/dd/yyyy"),
                        Starttime = bill.Starttime,
                        Workinghours = billoption.Workinghours,
                        Acreage = billoption.Acreage,
                        Rooms = billoption.Rooms,
                        Price = billoption.Price,
                        Description = bill.Description,
                        CustomerName = bill.CustomerName,
                        CustomerAddress = bill.CustomerAddress,
                        CustomerMobile = bill.CustomerMobile,
                        CustomerEmail = bill.CustomerEmail,
                        BillStatus = bill.BillStatus,
                        PaymentMethodName = payment.Name,
                        HelperId = bill.HelperId
                    };

                    data.Add(cubilldetailviewmodel);
                }

            }
            else
            {
                totalRow = 0;
                data = null;
            }

            var paginationSet = new PagedResult<CustomerBillDetailViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }


        public PagedResult<HelperBillViewModel> GetBillForHelper(string keyword, int page, int pageSize)
        {
            int totalRow;
            List<HelperBillViewModel> data = new List<HelperBillViewModel>();

            var query = _billRepository.FindAll(x => x.BillStatus == BillStatus.New && x.Status == Status.Active);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Workplace.Contains(keyword) || x.Apartmentnumber.Contains(keyword));
            }


            if (query.Any())
            {
                totalRow = query.Count();

                query = query.OrderBy(x => x.SortOrder).Skip((page - 1) * pageSize)
                    .Take(pageSize);


                foreach (Bill bill in query)
                {
                    var billoption = _billOptionRepository.FindById(bill.BillOptionId);

                    var payment = _paymentMethodRepository.FindById(bill.PaymentMethodId);

                    var billvm = new HelperBillViewModel()
                    {
                        Id = bill.Id,
                        Workplace = bill.Workplace,
                        Apartmentnumber = bill.Apartmentnumber,
                        Workday = bill.Workday.ToString("MM/dd/yyyy"),
                        Starttime = bill.Starttime,
                        Workinghours = billoption.Workinghours,
                        Acreage = billoption.Acreage,
                        Rooms = billoption.Rooms,
                        Price = billoption.Price,
                        Description = bill.Description,
                        CustomerName = bill.CustomerName,
                        CustomerAddress = bill.CustomerAddress,
                        CustomerMobile = bill.CustomerMobile,
                        CustomerEmail = bill.CustomerEmail,
                        BillStatus = bill.BillStatus,
                        PaymentMethodName = payment.Name
                    };

                    data.Add(billvm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }

            var paginationSet = new PagedResult<HelperBillViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }


        public int GetBillStatus(int id)
        {
            var bill = _billRepository.FindById(id);

            return (int)bill.BillStatus;
        }


        public CustomerBillViewModel GetByIdForCuEdit(int id)
        {
            var bill = _billRepository.FindById(id);

            bill.BillStatus = BillStatus.IsChanging;
            bill.SortOrder = 2;

            _billRepository.Update(bill);

            _unitOfWork.Commit();


            var billvm = new CustomerBillViewModel()
            {
                Id = bill.Id,
                Workplace = bill.Workplace,
                Apartmentnumber = bill.Apartmentnumber,
                Workday = bill.Workday.ToString("MM/dd/yyyy"),
                Starttime = bill.Starttime,
                Description = bill.Description,
                CustomerName = bill.CustomerName,
                CustomerAddress = bill.CustomerAddress,
                CustomerMobile = bill.CustomerMobile,
                CustomerEmail = bill.CustomerEmail,
            };

            return billvm;
        }


        public List<CustomerBillOptionViewModel> GetBillOption()
        {
            var billoption = _billOptionRepository.FindAll();

            List<CustomerBillOptionViewModel> billoptionvm = new List<CustomerBillOptionViewModel>();

            foreach (BillOption billopt in billoption)
            {
                var vm = new CustomerBillOptionViewModel()
                {
                    Id = billopt.Id,
                    Workinghours = billopt.Workinghours,
                    Acreage = billopt.Acreage,
                    Rooms = billopt.Rooms,
                    Price = billopt.Price
                };

                billoptionvm.Add(vm);
            }

            return billoptionvm;
        }


        public CustomerBillDetailViewModel GetByIdForCuView(int id)
        {
            var bill = _billRepository.FindById(id);


            var billoption = _billOptionRepository.FindById(bill.BillOptionId);


            var payment = _paymentMethodRepository.FindById(bill.PaymentMethodId);


            var billvm = new CustomerBillDetailViewModel()
            {
                Id = bill.Id,
                Workplace = bill.Workplace,
                Apartmentnumber = bill.Apartmentnumber,
                Workday = bill.Workday.ToString("MM/dd/yyyy"),
                Starttime = bill.Starttime,
                Workinghours = billoption.Workinghours,
                Acreage = billoption.Acreage,
                Rooms = billoption.Rooms,
                Price = billoption.Price,
                Description = bill.Description,
                CustomerName = bill.CustomerName,
                CustomerAddress = bill.CustomerAddress,
                CustomerMobile = bill.CustomerMobile,
                CustomerEmail = bill.CustomerEmail,
                PaymentMethodName = payment.Name,
            };


            return billvm;
        }

        public int Update(CustomerBillViewModel billvm)
        {
            var bill = _billRepository.FindById(billvm.Id);


            bill.Workday = DateTime.ParseExact(billvm.Workday, "MM/dd/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
            bill.Starttime = billvm.Starttime;
            bill.BillStatus = BillStatus.New;
            bill.SortOrder = 1;


            _billRepository.Update(bill);

            _unitOfWork.Commit();

            return 1;
        }


        public HelperBillViewModel GetBillForHelper(int id)
        {
            var bill = _billRepository.FindById(id);

            var billoption = _billOptionRepository.FindById(bill.BillOptionId);

            var payment = _paymentMethodRepository.FindById(bill.PaymentMethodId);


            var httpContext = _accessor.HttpContext;
            var helpersession = httpContext.Session.Get<HelperLogin>(CommonConstants.HELPER_SESSION);


            var helper = _helperRepository.FindById(helpersession.Id);

            int billcancel = _billCancelNumberRepository.FindById("HELPER").Number;

            bool? allow;

            if (helper.CancelBillNumber <= billcancel)
            {
                allow = true;   // cho phép helper nhận bill
            }
            else
            {
                allow = false;  // ko cho phép helper nhận bill
            }

            var billvm = new HelperBillViewModel()
            {
                Id = bill.Id,
                Workplace = bill.Workplace,
                Apartmentnumber = bill.Apartmentnumber,
                Workday = bill.Workday.ToString("MM/dd/yyyy"),
                Starttime = bill.Starttime,
                Workinghours = billoption.Workinghours,
                Acreage = billoption.Acreage,
                Rooms = billoption.Rooms,
                Price = billoption.Price,
                Description = bill.Description,
                CustomerName = bill.CustomerName,
                CustomerAddress = bill.CustomerAddress,
                CustomerMobile = bill.CustomerMobile,
                CustomerEmail = bill.CustomerEmail,
                PaymentMethodName = payment.Name,
                AcceptBill = allow
            };

            return billvm;
        }



        public PagedResult<AdminBillViewModel> GetBillForAdmin(string keyword, string workdate, int page, int pageSize)
        {
            int totalRow;
            List<AdminBillViewModel> data = new List<AdminBillViewModel>();

            var query = _billRepository.FindAll(x => x.BillStatus == BillStatus.New || x.BillStatus == BillStatus.Inprocess
                                                  || x.BillStatus == BillStatus.Incomplete || x.BillStatus == BillStatus.Completed
                                                  || x.BillStatus == BillStatus.Cancelled);


            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Workplace.Contains(keyword) || x.Apartmentnumber.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(workdate))
            {
                query = query.Where(x => x.Workday.ToString("MM/dd/yyyy").Equals(workdate));
            }

            if (query.Any())
            {
                totalRow = query.Count();

                query = query.OrderBy(x => x.SortOrder).Skip((page - 1) * pageSize).Take(pageSize);

                foreach (Bill bill in query)
                {
                    var billvm = new AdminBillViewModel()
                    {
                        Id = bill.Id,
                        Workplace = bill.Workplace,
                        Apartmentnumber = bill.Apartmentnumber,
                        Workday = bill.Workday.ToString("MM/dd/yyyy"),
                        Starttime = bill.Starttime,
                        BillStatus = bill.BillStatus,
                        Status = bill.Status,
                        HelperId = bill.HelperId,
                    };

                    data.Add(billvm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }

            var paginationSet = new PagedResult<AdminBillViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }



        public AdminBillViewModel GetByIdForAdmin(int id)
        {
            var bill = _billRepository.FindById(id);

            var billoption = _billOptionRepository.FindById(bill.BillOptionId);

            var payment = _paymentMethodRepository.FindById(bill.PaymentMethodId);


            HelperCheck checkbill = new HelperCheck();

            if (bill.BillStatus == BillStatus.Inprocess || bill.BillStatus == BillStatus.Incomplete
                || bill.BillStatus == BillStatus.Completed)
            {
                checkbill = _helperCheckRepository.FindSingle(x => x.BillId == bill.Id);
            }
            else if (bill.BillStatus == BillStatus.Cancelled && bill.HelperId != null)
            {
                checkbill = _helperCheckRepository.FindSingle(x => x.BillId == bill.Id);
            }


            var billvm = new AdminBillViewModel()
            {
                Id = bill.Id,
                Workplace = bill.Workplace,
                Apartmentnumber = bill.Apartmentnumber,
                Workday = bill.Workday.ToString("MM/dd/yyyy"),
                Starttime = bill.Starttime,
                Workinghours = billoption.Workinghours,
                Acreage = billoption.Acreage,
                Rooms = billoption.Rooms,
                Price = billoption.Price,
                Description = bill.Description,
                CustomerName = bill.CustomerName,
                CustomerAddress = bill.CustomerAddress,
                CustomerMobile = bill.CustomerMobile,
                CustomerEmail = bill.CustomerEmail,
                PaymentMethodName = payment.Name,
                BillStatus = bill.BillStatus,
                Status = bill.Status,
                DateCreated = bill.DateCreated.ToString("MM/dd/yyyy"),
                DateModified = bill.DateModified != null ? ((DateTime)bill.DateModified).ToString("MM/dd/yyyy") : "",
                Firstcheck = checkbill.Firstcheck,
                Secondcheck = checkbill.Secondcheck,
                Thirdcheck = checkbill.Thirdcheck,
                Cancel = checkbill.Cancel
            };

            return billvm;
        }



        public void SaveBill(AdminBillViewModel vm)
        {
            var bill = _billRepository.FindById(vm.Id);

            bill.Workplace = vm.Workplace;
            bill.Apartmentnumber = vm.Apartmentnumber;
            bill.Workday = DateTime.ParseExact(vm.Workday, "MM/dd/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
            bill.Starttime = vm.Starttime;
            bill.Description = vm.Description;
            bill.Status = vm.Status;

            _billRepository.Update(bill);

            _unitOfWork.Commit();

        }



        public void AdDeleteBill(int id)
        {
            _billRepository.Remove(id);

            var helpercheck = _helperCheckRepository.FindSingle(x => x.BillId == id);

            if (helpercheck != null)
            {
                _helperCheckRepository.Remove(helpercheck);
            }

            _unitOfWork.Commit();
        }



        public PagedResult<AdminBillOptionViewModel> GetBillOptionForAdmin(string keyword, int page, int pageSize)
        {
            int totalRow;
            List<AdminBillOptionViewModel> data = new List<AdminBillOptionViewModel>();

            var query = _billOptionRepository.FindAll();


            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Acreage == int.Parse(keyword) || x.Rooms == int.Parse(keyword)
                                    || x.Price == int.Parse(keyword));
            }


            if (query.Any())
            {
                totalRow = query.Count();

                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                foreach (BillOption billoption in query)
                {
                    var vm = new AdminBillOptionViewModel()
                    {
                        Id = billoption.Id,
                        Workinghours = billoption.Workinghours,
                        Acreage = billoption.Acreage,
                        Rooms = billoption.Rooms,
                        Price = billoption.Price,
                        Status = billoption.Status
                    };

                    data.Add(vm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }


            var PaginationSet = new PagedResult<AdminBillOptionViewModel>()
            {
                Results = data,
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };


            return PaginationSet;
        }



        public AdminBillOptionViewModel GetBillOptionByIdForAdmin(int id)
        {
            var billoption = _billOptionRepository.FindById(id);

            // Trong bản BillOptionHelperNumber, lấy ra List HelperNumberId có BillOptionId tương ứng bằng với tham số id truyền vào
            var amounthelpernumberid = _billOptionHelperNumberRepository.FindAll(x => x.BillOptionId == id)
                                          .Select(x => x.HelperNumberId).ToList();

            List<string> amounthenuidstring = new List<string>();

            // chuyển list vừa lấy sang kiểu string
            foreach (int amount in amounthelpernumberid)
            {
                amounthenuidstring.Add(Convert.ToString(amount));
            }

            var vm = new AdminBillOptionViewModel()
            {
                Id = billoption.Id,
                Workinghours = billoption.Workinghours,
                Acreage = billoption.Acreage,
                Rooms = billoption.Rooms,
                Price = billoption.Price,
                DateCreated = billoption.DateCreated.ToString("MM/dd/yyyy"),
                DateModified = billoption.DateModified != null ? ((DateTime)billoption.DateModified).ToString("MM/dd/yyyy") : "",
                Status = billoption.Status,
                NumberHelper = amounthenuidstring
            };

            return vm;
        }



        public int AddBillOption(AdminBillOptionViewModel vm)
        {
            var billacreage = _billOptionRepository.FindAll(x => x.Acreage == vm.Acreage);

            if (!billacreage.Any())
            {
                var billoption = new BillOption()
                {
                    Workinghours = vm.Workinghours,
                    Acreage = vm.Acreage,
                    Rooms = vm.Rooms,
                    Price = vm.Price,
                    Status = vm.Status,                    
                };

                // get id of rercently added bill option record
                int billoptionid = _billOptionRepository.RecentlyAddedId(billoption);

                foreach (string nuheid in vm.NumberHelper)
                {
                    var biohenu = new BillOptionHelperNumber()
                    {
                        BillOptionId = billoptionid,
                        HelperNumberId = int.Parse(nuheid)
                    };

                    _billOptionHelperNumberRepository.Add(biohenu);
                }

                _unitOfWork.Commit();

                return 1;
            }
            else
            {
                var sameroom = billacreage.Where(x => x.Rooms == vm.Rooms);

                if (sameroom.Any())
                {
                    return 0; // duplicate Acreage and rooms
                }
                else
                {
                    var billoption = new BillOption()
                    {
                        Workinghours = vm.Workinghours,
                        Acreage = vm.Acreage,
                        Rooms = vm.Rooms,
                        Price = vm.Price,
                        Status = vm.Status,
                    };

                    // get id of rercently added bill option record
                    int billoptionid = _billOptionRepository.RecentlyAddedId(billoption);

                    foreach (string nuheid in vm.NumberHelper)
                    {
                        var biohenu = new BillOptionHelperNumber()
                        {
                            BillOptionId = billoptionid,
                            HelperNumberId = int.Parse(nuheid)
                        };

                        _billOptionHelperNumberRepository.Add(biohenu);
                    }

                    _unitOfWork.Commit();

                    return 1;
                }
            }
            
        }


        public int UpdateBillOption(AdminBillOptionViewModel vm)
        {
            var acreage = _billOptionRepository.FindAll(x => x.Acreage == vm.Acreage);

            if (!acreage.Any())
            {
                var billoption = _billOptionRepository.FindById(vm.Id);

                billoption.Workinghours = vm.Workinghours;
                billoption.Acreage = vm.Acreage;
                billoption.Rooms = vm.Rooms;
                billoption.Price = vm.Price;
                billoption.Status = vm.Status;

                _billOptionRepository.Update(billoption);

                var biohenu = _billOptionHelperNumberRepository.FindAll(x => x.BillOptionId == billoption.Id).ToList();

                _billOptionHelperNumberRepository.RemoveMultiple(biohenu);

                foreach (string nuheid in vm.NumberHelper)
                {
                    var billoptionhelpernumber = new BillOptionHelperNumber()
                    {
                        BillOptionId = billoption.Id,
                        HelperNumberId = int.Parse(nuheid)
                    };

                    _billOptionHelperNumberRepository.Add(billoptionhelpernumber);
                }

                _unitOfWork.Commit();

                return 1;
            }
            else
            {
                var room = acreage.SingleOrDefault(x => x.Rooms == vm.Rooms);

                if (room != null)
                {
                    if (room.Id == vm.Id)
                    {
                        room.Workinghours = vm.Workinghours;
                        room.Acreage = vm.Acreage;
                        room.Rooms = vm.Rooms;
                        room.Price = vm.Price;
                        room.Status = vm.Status;

                        _billOptionRepository.Update(room);

                        var biohenu = _billOptionHelperNumberRepository.FindAll(x => x.BillOptionId == room.Id).ToList();

                        _billOptionHelperNumberRepository.RemoveMultiple(biohenu);

                        foreach (string nuheid in vm.NumberHelper)
                        {
                            var billoptionhelpernumber = new BillOptionHelperNumber()
                            {
                                BillOptionId = room.Id,
                                HelperNumberId = int.Parse(nuheid)
                            };

                            _billOptionHelperNumberRepository.Add(billoptionhelpernumber);
                        }

                        _unitOfWork.Commit();

                        return 1;
                    }
                    else
                    {
                        return 0; // duplicate Acreage and rooms
                    }                    
                }
                else
                {
                    var billoption = _billOptionRepository.FindById(vm.Id);

                    billoption.Workinghours = vm.Workinghours;
                    billoption.Acreage = vm.Acreage;
                    billoption.Rooms = vm.Rooms;
                    billoption.Price = vm.Price;
                    billoption.Status = vm.Status;

                    _billOptionRepository.Update(billoption);

                    var biohenu = _billOptionHelperNumberRepository.FindAll(x => x.BillOptionId == billoption.Id).ToList();

                    _billOptionHelperNumberRepository.RemoveMultiple(biohenu);

                    foreach (string nuheid in vm.NumberHelper)
                    {
                        var billoptionhelpernumber = new BillOptionHelperNumber()
                        {
                            BillOptionId = billoption.Id,
                            HelperNumberId = int.Parse(nuheid)
                        };

                        _billOptionHelperNumberRepository.Add(billoptionhelpernumber);
                    }

                    _unitOfWork.Commit();

                    return 1;
                }
            }
        }



        public void DeleteBillOption(int id)
        {
            _billOptionRepository.Remove(id);

            var billoptionhelpernumber = _billOptionHelperNumberRepository.FindAll(x => x.BillOptionId == id).ToList();

            _billOptionHelperNumberRepository.RemoveMultiple(billoptionhelpernumber);

            _unitOfWork.Commit();
        }
    }
}
