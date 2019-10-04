using HomeCare.Application.ViewModels.Admin;
using HomeCare.Application.ViewModels.Customer;
using HomeCare.Application.ViewModels.Helper;
using HomeCare.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IBillService
    {
        // lấy bill để tải ra trang chủ của Customer
        PagedResult<CustomerBillDetailViewModel> GetBillForCustomer(string keyword, int page, int pageSize);

        // lấy bill để Customer edit
        CustomerBillViewModel GetByIdForCuEdit(int id);

        // lấy bill để Customer view
        CustomerBillDetailViewModel GetByIdForCuView(int id);

        // lấy billoption để Customer chọn lúc add bill
        List<CustomerBillOptionViewModel> GetBillOption();

        // Customer xóa bill
        void Delete(int id);

        // Customer add bill
        int Add(CustomerBillViewModel billvm, int helpernumberId);

        // Customer edit bill
        int Update(CustomerBillViewModel billvm);

        // Customer get bill status trước khi edit bill
        int GetBillStatus(int id);

        // chuyểm bill status từ 1 về 0 trong trường hợp customer chọn edit bill nhưng bấm cancel
        void ChangeBillStatus(int id);


        // lấy bill để tải ra trang chủ của Helper
        PagedResult<HelperBillViewModel> GetBillForHelper(string keyword, int page, int pageSize);

        // lấy bill ra để helper xem chi tiết trước khi nhận
        HelperBillViewModel GetBillForHelper(int id);


        // Get bill list for admin view, edit, delete
        PagedResult<AdminBillViewModel> GetBillForAdmin(string keyword, string workdate, int page, int pageSize);


        // Get specified Bill for Admin view or edit
        AdminBillViewModel GetByIdForAdmin(int id);


        // Admin Save Edited Bill
        void SaveBill(AdminBillViewModel vm);


        // Admin delete bill
        void AdDeleteBill(int id);


        // Get Bill option for admin bill option page
        PagedResult<AdminBillOptionViewModel> GetBillOptionForAdmin(string keyword, int page, int pageSize);


        // Get Specified Bill Option for Admin Edit
        AdminBillOptionViewModel GetBillOptionByIdForAdmin(int id);


        // Admin add bill option
        int AddBillOption(AdminBillOptionViewModel vm);


        // Admin update bill option
        int UpdateBillOption(AdminBillOptionViewModel vm);


        // Admin delete bill option
        void DeleteBillOption(int id);
    }
}
