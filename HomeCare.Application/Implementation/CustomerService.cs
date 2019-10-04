using AutoMapper;
using HomeCare.Application.Common;
using HomeCare.Application.Common.Customer;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Data.Entities;
using HomeCare.Data.Enums;
using HomeCare.Data.IRepositories;
using HomeCare.Infrastructure.Interfaces;
using HomeCare.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Utilities.Dtos;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HomeCare.Application.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        private readonly IRoleRepository _roleRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomerService(ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork, IHttpContextAccessor accessor,
            IRoleRepository roleRepository, IHostingEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _accessor = accessor;
            _roleRepository = roleRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public int CuLogin(CuLoginViewModel CuVM)
        {
            var result = _customerRepository.FindSingle(x => x.UserName == CuVM.UserName);

            if (result == null)
            {
                return 0; // Incorrect username
            }
            else
            {
                if (result.Password == CuVM.Password)
                {
                    if (result.Status == Status.Active)
                    {
                        var customersession = new CustomerLogin()
                        {
                            Id = result.Id,
                            UserName = result.UserName
                        };

                        var httpContext = _accessor.HttpContext;

                        httpContext.Session.Set(CommonConstants.CUSTOMER_SESSION, customersession);

                        return 1;
                    }
                    else
                    {
                        return -2; // Account is locked
                    }
                }
                else
                {
                    return -1; // Incorrect password
                }
                    
            }
        }

        public int CuRegister(CuRegisterViewModel CuVM)
        {
            var result = _customerRepository.FindAll(x => x.UserName == CuVM.UserName || x.Email == CuVM.Email);

            if (!result.Any())
            {
                var role = _roleRepository.FindSingle(x => x.Name.Equals("Customer"));

                var customer = new AppCustomer()
                {
                    Id = CuVM.Email,
                    UserName = CuVM.UserName,
                    FullName = CuVM.FullName,
                    Email = CuVM.Email,
                    PhoneNumber = CuVM.PhoneNumber,
                    Password = CuVM.Password,
                    Address = CuVM.Address,
                    CancelBillNumber = 0,
                    Status = Status.Active,
                    RoleId = role.Id
                };

                _customerRepository.Add(customer);

                _unitOfWork.Commit();

                var customersession = new CustomerLogin()
                {
                    Id = CuVM.Email,
                    UserName = CuVM.UserName
                };

                var httpContext = _accessor.HttpContext;

                httpContext.Session.Set(CommonConstants.CUSTOMER_SESSION, customersession);

                return 1; // Successfully Registered
            }
            else
            {
                return 0; // UserName or Email already exits
            }
        }


        public CustomerViewModel GetByUserNameCu (string usernamecu)
        {
            return Mapper.Map<AppCustomer, CustomerViewModel>(_customerRepository.FindSingle(x => x.UserName == usernamecu));
        }

        public int GetCuBillCancel()
        {
            var httpContext = _accessor.HttpContext;
            var customersession = httpContext.Session.Get<CustomerLogin>(CommonConstants.CUSTOMER_SESSION);

            var customer = _customerRepository.FindById(customersession.Id);

            return customer.CancelBillNumber;
        }


        public PagedResult<AdCustomerViewModel> GetAllPaging(string keyword, string birthday, int page, int pageSize)
        {
            int totalRow;
            List<AdCustomerViewModel> data = new List<AdCustomerViewModel>();

            var query = _customerRepository.FindAll();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.UserName.Contains(keyword) || x.FullName.Contains(keyword)
                                      || x.Email.Equals(keyword) || x.PhoneNumber.Equals(keyword) || x.Address.Equals(keyword));
            }


            if (!string.IsNullOrEmpty(birthday))
            {
                var NoBirthDay = _customerRepository.FindAll(x => x.BirthDay == null);

                query = query.Except(NoBirthDay);

                query = query.Where(x => ((DateTime)x.BirthDay).ToString("MM/dd/yyyy").Equals(birthday));
            }


            if (query.Any())
            {
                totalRow = query.Count();

                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                foreach (AppCustomer customer in query)
                {
                    var vm = new AdCustomerViewModel()
                    {
                        Id = customer.Id,
                        UserName = customer.UserName,
                        FullName = customer.FullName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        BirthDay = customer.BirthDay != null ? ((DateTime)customer.BirthDay).ToString("MM/dd/yyyy") : "",
                        Address = customer.Address,
                        Status = customer.Status
                    };

                    data.Add(vm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }

            var paginationSet = new PagedResult<AdCustomerViewModel>()
            {
                Results = data,
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };

            return paginationSet;
        }



        public AdCustomerViewModel GetById(string id)
        {
            var model = _customerRepository.FindById(id);

            var vm = new AdCustomerViewModel()
            {
                Id = model.Id,
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                BirthDay = model.BirthDay != null ? ((DateTime)model.BirthDay).ToString("MM/dd/yyyy") : "",
                Address = model.Address,
                CancelBillNumber = model.CancelBillNumber,
                Status = model.Status,
                DateCreated = model.DateCreated.ToString("MM/dd/yyyy"),
                DateModified = model.DateModified != null ? ((DateTime)model.DateModified).ToString("MM/dd/yyyy") : ""
            };

            return vm;
        }



        public int SaveCustomer(AdCustomerViewModel vm)
        {
            var specifiedcustomer = _customerRepository.FindAll(x => x.Id == vm.Id);

            var othercustomer = _customerRepository.FindAll().Except(specifiedcustomer);

            var username = othercustomer.Where(x => x.UserName == vm.UserName);

            if (username.Any())
            {
                return 0; // Duplicate UserName
            }
            else
            {
                var email = othercustomer.Where(x => x.Email == vm.Email);

                if (email.Any())
                {
                    return -1; // Duplicate Email
                }
                else
                {
                    var customer = _customerRepository.FindById(vm.Id);

                    customer.UserName = vm.UserName;
                    customer.FullName = vm.FullName;
                    customer.Email = vm.Email;
                    customer.PhoneNumber = vm.PhoneNumber;
                    customer.BirthDay = DateTime.ParseExact(vm.BirthDay, "MM/dd/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                    customer.Address = vm.Address;
                    customer.CancelBillNumber = vm.CancelBillNumber;
                    customer.Status = vm.Status;

                    _customerRepository.Update(customer);

                    _unitOfWork.Commit();

                    return 1;
                }
            }
        }



        public void DeleteCustomer(string id)
        {
            string username = _customerRepository.FindById(id).UserName;

            _customerRepository.Remove(id);

            _unitOfWork.Commit();

            var imageFolder = $@"\customer-side\images\" + username;

            string folder = _hostingEnvironment.WebRootPath + imageFolder;

            if (Directory.Exists(folder))
            {
                Directory.Delete(folder,true);
            }
        }



        public string GetAvatarPath(string customerId)
        {
            return _customerRepository.FindById(customerId).Avatar;
        }


        public string GetCuUserName(string customerId)
        {
            return _customerRepository.FindById(customerId).UserName;
        }


        public void AddAvatarPath(string customerId, string path)
        {
            var customer = _customerRepository.FindById(customerId);

            customer.Avatar = path;

            _customerRepository.Update(customer);

            _unitOfWork.Commit();
        }


        public void CheckAvatar(string customerId)
        {
            var avatarpath = _customerRepository.FindById(customerId).Avatar;

            if (avatarpath != null)
            {
                var changeslash = avatarpath.Replace(@"/", @"\");

                var fullpath = _hostingEnvironment.WebRootPath + changeslash;

                File.Delete(fullpath);
            }
        }
    }
}
