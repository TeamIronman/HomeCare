using HomeCare.Application.ViewModels.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IHelperCheckService
    {
        void BillAccept(int id);

        int CheckSingle(HeCheckViewModel vm);

        void BillCancel(int id);
    }
}
