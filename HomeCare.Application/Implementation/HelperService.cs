using HomeCare.Application.Common;
using HomeCare.Application.Common.Helper;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Application.ViewModels.Helper;
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
using HomeCare.Data.Entities;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HomeCare.Application.Implementation
{
    public class HelperService : IHelperService
    {

        private readonly IHelperRepository _helperRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHelperNumberRepository _helperNumberRepository;
        private readonly IBillOptionHelperNumberRepository _billOptionHelperNumberRepository;
        private readonly IBillOptionRepository _billOptionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHelperImageRepository _helperImageRepository;

        public HelperService(IHelperRepository helperRepository, IUnitOfWork unitOfWork,
            IHttpContextAccessor accessor, IHelperNumberRepository helperNumberRepository,
            IBillOptionHelperNumberRepository billOptionHelperNumberRepository,
            IBillOptionRepository billOptionRepository, IRoleRepository roleRepository,
            IHostingEnvironment hostingEnvironment, IHelperImageRepository helperImageRepository)
        {
            _helperRepository = helperRepository;
            _unitOfWork = unitOfWork;
            _accessor = accessor;
            _helperNumberRepository = helperNumberRepository;
            _billOptionHelperNumberRepository = billOptionHelperNumberRepository;
            _billOptionRepository = billOptionRepository;
            _roleRepository = roleRepository;
            _hostingEnvironment = hostingEnvironment;
            _helperImageRepository = helperImageRepository;
        }


        public int HeLogin(HeLoginViewModel HeVM)
        {
            var result = _helperRepository.FindSingle(x => x.UserName == HeVM.UserName);

            if (result == null)
            {
                return 0; // Incorrect username
            }
            else
            {
                if (result.Password == HeVM.Password)
                {
                    if (result.Status == Status.Active)
                    {
                        var helpersession = new HelperLogin()
                        {
                            Id = result.Id,
                            UserName = result.UserName
                        };

                        var httpContext = _accessor.HttpContext;

                        httpContext.Session.Set(CommonConstants.HELPER_SESSION, helpersession);

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



        public HelperViewModel GetHelperById(string id)
        {
            var helper = _helperRepository.FindById(id);

            var vm = new HelperViewModel()
            {
                Id = helper.Id,                
                FullName = helper.FullName,
                Email = helper.Email,
                PhoneNumber = helper.PhoneNumber,
                BirthDay = helper.BirthDay.ToString("MM/dd/yyyy"),
                Address = helper.Address,                
            };

            return vm;
        }


        public List<CuHelperNumberViewModel> GetHeNumber(int id)
        {
            var billoption = _billOptionRepository.FindAll();

            var helpernumber = _helperNumberRepository.FindAll();

            var billoptionhelpernumber = _billOptionHelperNumberRepository.FindAll();


            var query = from bio in billoption
                        join biohenu in billoptionhelpernumber on bio.Id equals biohenu.BillOptionId
                        join henu in helpernumber on biohenu.HelperNumberId equals henu.Id
                        where bio.Id == id
                        select new CuHelperNumberViewModel()
                        {
                            Id = henu.Id,
                            Amount = henu.Amount
                        };


            return query.ToList();
        }


        public HelperCorrespondingBillViewModel GetHelperForBill(string helperId)
        {
            var helper = _helperRepository.FindById(helperId);

            var helpervm = new HelperCorrespondingBillViewModel()
            {
                Id = helper.Id,
                UserName = helper.UserName,
                FullName = helper.FullName,
                Email = helper.Email,
                PhoneNumber = helper.PhoneNumber,
                IDcard = helper.IDcard,
                BirthDay = helper.BirthDay.ToString("MM/dd/yyyy"),
                Address = helper.Address,
                CancelBillNumber = helper.CancelBillNumber,
                Paymoney = helper.Paymoney,
                Status = helper.Status,
                DateCreated = helper.DateCreated.ToString("MM/dd/yyyy"),
                DateModified = helper.DateModified != null ? ((DateTime)helper.DateModified).ToString("MM/dd/yyyy") : "",
            };

            return helpervm;
        }


        public PagedResult<CuHelperNumberViewModel> GetAllHelperNumber(int? keyword, int page, int pageSize)
        {
            int totalRow;
            List<CuHelperNumberViewModel> data = new List<CuHelperNumberViewModel>();

            var query = _helperNumberRepository.FindAll();

            if(keyword != null)
            {
                query = query.Where(x => x.Amount == keyword);
            }

            if(query.Any())
            {
                totalRow = query.Count();

                query = query.Skip((page - 1) * pageSize).Take(pageSize);
                        

                foreach(HelperNumber henu in query)
                {
                    var vm = new CuHelperNumberViewModel()
                    {
                        Id = henu.Id,
                        Amount = henu.Amount
                    };

                    data.Add(vm);
                }

            }
            else
            {
                totalRow = 0;
                data = null;
            }


            var paginationresult = new PagedResult<CuHelperNumberViewModel>()
            {
                Results = data,
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };

            return paginationresult;
        }


        public CuHelperNumberViewModel GetHelperNumberById(int id)
        {
            var helpernumber = _helperNumberRepository.FindById(id);

            var vm = new CuHelperNumberViewModel()
            {
                Id = helpernumber.Id,
                Amount = helpernumber.Amount
            };

            return vm;
        }


        public int AddHelperNumber(CuHelperNumberViewModel viewmodel)
        {
            var helpernumber = _helperNumberRepository.FindSingle(x => x.Amount == viewmodel.Amount);
            
            if (helpernumber == null)
            {
                var model = new HelperNumber()
                {
                    Amount = viewmodel.Amount
                };

                _helperNumberRepository.Add(model);

                _unitOfWork.Commit();

                return 1;
            }
            else
            {
                return 0; // amount value is already exits
            }
        }


        public int UpdateHelperNumber(CuHelperNumberViewModel viewmodel)
        {
            var helpernumber = _helperNumberRepository.FindById(viewmodel.Id);

            if (helpernumber.Amount == viewmodel.Amount)
            {
                return 2; // same amount value, No update needed
            }
            else
            {
                var helpernumberamount = _helperNumberRepository.FindSingle(x => x.Amount == viewmodel.Amount);

                if (helpernumberamount != null)
                {
                    return 0; // amount value is already exits
                }
                else
                {
                    helpernumber.Amount = viewmodel.Amount;

                    _helperNumberRepository.Update(helpernumber);

                    _unitOfWork.Commit();

                    return 1;   // Update successfully
                }
            }
        }


        public void Delete(int id)
        {
            _helperNumberRepository.Remove(id);

            _unitOfWork.Commit();
        }



        public List<CuHelperNumberViewModel> GetAllForBIOPage()
        {
            var vm = _helperNumberRepository.FindAll()
                      .Select(x => new CuHelperNumberViewModel()
                      {
                          Id = x.Id,
                          Amount = x.Amount
                      }).ToList();

            return vm;
        }



        public PagedResult<AdHelperViewModel> GetAllPaging(string keyword, string birthday, int page, int pageSize)
        {
            int totalRow;
            List<AdHelperViewModel> data = new List<AdHelperViewModel>();

            var query = _helperRepository.FindAll();

            if(!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.FullName.Contains(keyword) || x.Email.Equals(keyword) || x.IDcard.Equals(keyword)
                                       || x.PhoneNumber.Equals(keyword) || x.Address.Contains(keyword) 
                                       || x.CancelBillNumber.ToString().Equals(keyword));
            }

            if (!string.IsNullOrEmpty(birthday))
            {
                query = query.Where(x => x.BirthDay.ToString("MM/dd/yyyy").Equals(birthday));
            }


            if (query.Any())
            {
                totalRow = query.Count();

                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                foreach (AppHelper helper in query)
                {
                    var vm = new AdHelperViewModel()
                    {
                        Id = helper.Id,
                        FullName = helper.FullName,
                        Email = helper.Email,
                        PhoneNumber = helper.PhoneNumber,
                        IDcard = helper.IDcard,
                        Address = helper.Address,
                        Paymoney = helper.Paymoney,
                        Status = helper.Status
                    };

                    data.Add(vm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }


            var paginationSet = new PagedResult<AdHelperViewModel>()
            {
                Results = data,
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };

            return paginationSet;
        }



        public string GetUserName(string helperId)
        {
            string username = _helperRepository.FindById(helperId).UserName;

            return username;
        }


        public AdHelperViewModel GetHelperByIdForAd(string id)
        {
            var helper = _helperRepository.FindById(id);

            var vm = new AdHelperViewModel()
            {
                Id = helper.Id,
                UserName = helper.UserName,
                FullName = helper.FullName,
                Email = helper.Email,
                PhoneNumber = helper.PhoneNumber,
                Password = helper.Password,
                IDcard = helper.IDcard,
                BirthDay = helper.BirthDay.ToString("MM/dd/yyyy"),
                Address = helper.Address,
                CancelBillNumber = helper.CancelBillNumber,
                Paymoney = helper.Paymoney,
                Status = helper.Status,
                DateCreated = helper.DateCreated.ToString("MM/dd/yyyy"),
                DateModified = helper.DateModified != null ? ((DateTime)helper.DateModified).ToString("MM/dd/yyyy") : ""
            };

            return vm;
        }


        public int AddHelper(AdHelperViewModel vm)
        {
            var roleid = _roleRepository.FindSingle(x => x.Name.Equals("Helper")).Id;

            var username = _helperRepository.FindSingle(x => x.UserName == vm.UserName);

            if (username == null)
            {
                var email = _helperRepository.FindSingle(x => x.Email == vm.Email);

                if (email == null)
                {
                    var idcard = _helperRepository.FindSingle(x => x.IDcard == vm.IDcard);

                    if (idcard == null)
                    {
                        

                        var model = new AppHelper()
                        {
                            Id = vm.Email,
                            UserName = vm.UserName,
                            FullName = vm.FullName,
                            Email = vm.Email,
                            PhoneNumber = vm.PhoneNumber,
                            Password = Encryptor.MD5Hash(vm.Password),
                            IDcard = vm.IDcard,
                            BirthDay = DateTime.ParseExact(vm.BirthDay, "MM/dd/yyyy", CultureInfo.GetCultureInfo("vi-VN")),
                            Address = vm.Address,
                            CancelBillNumber = vm.CancelBillNumber,
                            Paymoney = vm.Paymoney,
                            Status = vm.Status,
                            RoleId = roleid
                        };

                        _helperRepository.Add(model);

                        _unitOfWork.Commit();

                        return 1;
                    }
                    else
                    {
                        return -2; // Duplicate IDcard
                    }
                }
                else
                {
                    return -1; // Duplicate Email
                }
            }
            else
            {
                return 0; // Duplicate UserName
            }
        }



        public int UpdateHelper(AdHelperViewModel vm)
        {
            var specifiedhelper = _helperRepository.FindAll(x => x.Id == vm.Id);

            var othershelper = _helperRepository.FindAll().Except(specifiedhelper);

            var username = othershelper.Where(x => x.UserName == vm.UserName);

            if (username.Any())
            {
                return 0; // Duplicate UserName
            }
            else
            {
                var email = othershelper.Where(x => x.Email == vm.Email);

                if (email.Any())
                {
                    return -1; // Duplicate Email
                }
                else
                {
                    var idcard = othershelper.Where(x => x.IDcard == vm.IDcard);

                    if (idcard.Any())
                    {
                        return -2; // Duplicate IDcard
                    }
                    else
                    {
                        var Helper = _helperRepository.FindById(vm.Id);

                        string pass;

                        if (Helper.Password != vm.Password)
                        {
                            pass = Encryptor.MD5Hash(vm.Password);
                        }
                        else
                        {
                            pass = vm.Password;
                        }

                        Helper.UserName = vm.UserName;
                        Helper.FullName = vm.FullName;
                        Helper.Email = vm.Email;
                        Helper.PhoneNumber = vm.PhoneNumber;
                        Helper.Password = pass;
                        Helper.IDcard = vm.IDcard;
                        Helper.BirthDay = DateTime.ParseExact(vm.BirthDay, "MM/dd/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                        Helper.Address = vm.Address;
                        Helper.CancelBillNumber = vm.CancelBillNumber;
                        Helper.Paymoney = vm.Paymoney;
                        Helper.Status = vm.Status;

                        _helperRepository.Update(Helper);

                        _unitOfWork.Commit();

                        return 1;
                    }
                }
            }
        }



        public void DeleteHelper(string id)
        {
            string username = _helperRepository.FindById(id).UserName;

            var imageFolder = $@"\helper-side\images\" + username;

            string folder = _hostingEnvironment.WebRootPath + imageFolder;

            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }

            var helperimages = _helperImageRepository.FindAll(x => x.HelperId == id).ToList();

            _helperImageRepository.RemoveMultiple(helperimages);

            _helperRepository.Remove(id);

            _unitOfWork.Commit();
        }
    }
}
