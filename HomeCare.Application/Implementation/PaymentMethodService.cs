using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HomeCare.Utilities.Dtos;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Data.Entities;
using HomeCare.Infrastructure.Interfaces;

namespace HomeCare.Application.Implementation
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository,
            IUnitOfWork unitOfWork)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _unitOfWork = unitOfWork;
        }

        public List<PaymentMethodViewModel> GetAllPaymentMethod()
        {
            var vm = _paymentMethodRepository.FindAll()
                      .Select(x => new PaymentMethodViewModel()
                      {
                          Id = x.Id,
                          Name = x.Name
                      }).ToList();

            return vm;
        }


        public PagedResult<AdminPaymentMethodViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            int totalRow;
            List<AdminPaymentMethodViewModel> data = new List<AdminPaymentMethodViewModel>();

            var query = _paymentMethodRepository.FindAll();

            if(!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }

            if (query.Any())
            {
                totalRow = query.Count();

                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                foreach(PaymentMethod pm in query)
                {
                    var vm = new AdminPaymentMethodViewModel()
                    {
                        Id = pm.Id,
                        Name = pm.Name,
                        Description = pm.Description
                    };

                    data.Add(vm);
                }
            }
            else
            {
                totalRow = 0;
                data = null;
            }

            var paginationSet = new PagedResult<AdminPaymentMethodViewModel>()
            {
                Results = data,
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };

            return paginationSet;
        }


        public AdminPaymentMethodViewModel GetById(int id)
        {
            var paymentmethod = _paymentMethodRepository.FindById(id);

            var vm = new AdminPaymentMethodViewModel()
            {
                Id = paymentmethod.Id,
                Name = paymentmethod.Name,
                Description = paymentmethod.Description
            };

            return vm;
        }



        public int AddPaymentMethod(AdminPaymentMethodViewModel vm)
        {
            var pm = _paymentMethodRepository.FindAll(x => x.Name == vm.Name);

            if (pm.Any())
            {
                return 0; // duplicate PaymentMethod Name
            }
            else
            {
                var paymentmethod = new PaymentMethod()
                {
                    Name = vm.Name,
                    Description = vm.Description
                };

                _paymentMethodRepository.Add(paymentmethod);

                _unitOfWork.Commit();

                return 1;
            }
        }



        public int UpdatePaymentMethod(AdminPaymentMethodViewModel vm)
        {
            var pm = _paymentMethodRepository.FindAll(x => x.Name == vm.Name);

            if (pm.Any())
            {
                var paymentmethod = pm.SingleOrDefault(x => x.Id == vm.Id);

                if (paymentmethod != null)
                {
                    return 2; // No update needed
                }
                else
                {
                    return 0; // duplicate PaymentMethod Name
                }
            }
            else
            {
                var paymentmethod = _paymentMethodRepository.FindById(vm.Id);

                paymentmethod.Name = vm.Name;
                paymentmethod.Description = vm.Description;

                _paymentMethodRepository.Update(paymentmethod);

                _unitOfWork.Commit();

                return 1;
            }
        }



        public void DeletePaymentMethod(int id)
        {
            _paymentMethodRepository.Remove(id);

            _unitOfWork.Commit();
        }
    }
}
