using HomeCare.Application.ViewModels.Admin;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IPaymentMethodService
    {
        List<PaymentMethodViewModel> GetAllPaymentMethod();


        // get all payment method for admin payment method page
        PagedResult<AdminPaymentMethodViewModel> GetAllPaging(string keyword, int page, int pageSize);


        // get paymentmethod by id for admin edit
        AdminPaymentMethodViewModel GetById(int id);


        // admin add paymentmethod 
        int AddPaymentMethod(AdminPaymentMethodViewModel vm);


        // admin update paymentmethod
        int UpdatePaymentMethod(AdminPaymentMethodViewModel vm);


        // admin delete payment method
        void DeletePaymentMethod(int id);
    }
}
