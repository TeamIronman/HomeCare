using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels;
using HomeCare.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Implementation
{
    public class BillCancelNumberService : IBillCancelNumberService
    {
        private readonly IBillCancelNumberRepository _billCancelNumberRepository;

        public BillCancelNumberService(IBillCancelNumberRepository billCancelNumberRepository)
        {
            _billCancelNumberRepository = billCancelNumberRepository;
        }

        public BillCancelNumberViewModel GetCuBillCancelNumber()
        {
            var billcancel = _billCancelNumberRepository.FindById("CUSTOMER");

            var billcancelvm = new BillCancelNumberViewModel()
            {
                Id = billcancel.Id,
                Number = billcancel.Number
            };

            return billcancelvm;
        }
    }
}
