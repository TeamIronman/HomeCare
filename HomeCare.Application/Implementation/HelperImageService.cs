using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Admin;
using HomeCare.Data.Entities;
using HomeCare.Data.IRepositories;
using HomeCare.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeCare.Application.Implementation
{
    public class HelperImageService : IHelperImageService
    {
        private readonly IHelperImageRepository _helperImageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HelperImageService(IHelperImageRepository helperImageRepository, IUnitOfWork unitOfWork,
            IHostingEnvironment hostingEnvironment)
        {
            _helperImageRepository = helperImageRepository;
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public void AddImage(string helperId, string path)
        {
            var helperimage = new HelperImage()
            {
                HelperId = helperId,
                Path = path,
            };

            _helperImageRepository.Add(helperimage);

            _unitOfWork.Commit();
        }


        public List<AdHelperImageViewModel> GetHelpImageByHeId(string helperId)
        {
            var vm = _helperImageRepository.FindAll(x => x.HelperId == helperId)
                      .Select(x => new AdHelperImageViewModel() {
                          Id = x.Id,
                          HelperId = x.HelperId,
                          Path = x.Path,
                          Caption = x.Caption
                      }).ToList();

            return vm;
        }


        public void DeleteImage(int ImageId, string ImagePath)
        {
            _helperImageRepository.Remove(ImageId);

            _unitOfWork.Commit();

            var changeslash = ImagePath.Replace(@"/", @"\");

            var fullpath = _hostingEnvironment.WebRootPath + changeslash;

            File.Delete(fullpath);
        }
    }
}
