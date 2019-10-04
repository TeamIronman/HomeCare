using HomeCare.Application.ViewModels.Admin;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Application.ViewModels.Helper;
using HomeCare.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IHelperService
    {
        // Helper Login
        int HeLogin(HeLoginViewModel HeVM);

        // Get Specified Helper accepted bill for customer view
        HelperViewModel GetHelperById(string id);

        // Get HelperNumber corresponding bill option for customer choose
        List<CuHelperNumberViewModel> GetHeNumber(int id);

        // get helper corresponding bill for admin view
        HelperCorrespondingBillViewModel GetHelperForBill(string helperId);

        // get all helpernumber for admin page
        PagedResult<CuHelperNumberViewModel> GetAllHelperNumber(int? keyword, int page, int pageSize);

        // get specified HelperNumber for admin edit 
        CuHelperNumberViewModel GetHelperNumberById(int id);

        // admin save helpernumber after creating 
        int AddHelperNumber(CuHelperNumberViewModel viewmodel);

        // admin update helpernumber after edit
        int UpdateHelperNumber(CuHelperNumberViewModel viewmodel);

        // admin delete helpernumber
        void Delete(int id);

        // Get all helpernumber for admin bill option page
        List<CuHelperNumberViewModel> GetAllForBIOPage();


        // Get all Helper for admin 
        PagedResult<AdHelperViewModel> GetAllPaging(string keyword, string birthday, int page, int pageSize);


        // Get Helper's Username for storing images
        string GetUserName(string helperId);


        // Get Helper by Id for Admin edit
        AdHelperViewModel GetHelperByIdForAd(string id);


        // Admin add helper
        int AddHelper(AdHelperViewModel vm);


        // Admin update helper
        int UpdateHelper(AdHelperViewModel vm);


        // Admin delete helper
        void DeleteHelper(string id);
    }
}
