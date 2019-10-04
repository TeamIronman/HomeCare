using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCare.Application.Implementation
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }


        public async Task<List<FunctionViewModel>> GetAllAsync()
        {
            var vm = _functionRepository.FindAll()
                      .Select(x => new FunctionViewModel()
                      {
                          Id = x.Id,
                          Name = x.Name,
                          URL = x.URL,
                          ParentId = x.ParentId,
                          IconCss = x.IconCss,
                          SortOrder = x.SortOrder,
                          Status = x.Status
                      });

            return await vm.ToListAsync();
        }
    }
}
