using HomeCare.Application.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Interfaces
{
    public interface IHelperImageService
    {

        // admin add image path to helperimages table
        void AddImage(string helperId, string path);


        // admin get helperimages using specified helperid
        List<AdHelperImageViewModel> GetHelpImageByHeId(string helperId);


        // admin delete helper's image
        void DeleteImage(int ImageId, string ImagePath);
    }
}
