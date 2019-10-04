using HomeCare.Application.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCare.Application.Interfaces
{
    public interface IFunctionService
    {
        Task<List<FunctionViewModel>> GetAllAsync();
    }
}
