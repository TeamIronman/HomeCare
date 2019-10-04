using HomeCare.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IBillCancelNumberService
    {
        BillCancelNumberViewModel GetCuBillCancelNumber(); 
    }
}
