using HomeCare.Application.ViewModels.Admin;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface ICustomerService
    {
        int CuLogin(CuLoginViewModel CuVM);

        int CuRegister(CuRegisterViewModel CuVM);

        CustomerViewModel GetByUserNameCu(string usernamecu);

        int GetCuBillCancel();


        // Get all Customer Information for admin view in Customer Management Page
        PagedResult<AdCustomerViewModel> GetAllPaging(string keyword, string birthday, int page, int pageSize);


        // Get Specified Customer by Id for Admin Edit
        AdCustomerViewModel GetById(string id);


        // save customer's information after edit
        int SaveCustomer(AdCustomerViewModel vm);


        // Admin delete Customer
        void DeleteCustomer(string id);


        // Get customer's avatar path for admin
        string GetAvatarPath(string customerId);


        // Get customer's username for saving avatar
        string GetCuUserName(string customerId);


        // add avatar's path to DB for customer
        void AddAvatarPath(string customerId, string path);


        // if customer has old avatar, so delete it to add new avatar
        // if customer doesn't have avatar yet, add new avatar
        void CheckAvatar(string customerId);
    }
}
