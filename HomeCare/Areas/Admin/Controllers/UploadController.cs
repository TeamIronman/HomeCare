using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HomeCare.Application.Interfaces;
using HomeCare.Utilities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using HomeCare.Application.ViewModels.Admin;

namespace HomeCare.Areas.Admin.Controllers
{
    public class UploadController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHelperService _helperService;
        private readonly IHelperImageService _helperImageService;
        private readonly ICustomerService _customerService;

        public UploadController(IHostingEnvironment hostingEnvironment, IHelperService helperService,
            IHelperImageService helperImageService, ICustomerService customerService)
        {
            _hostingEnvironment = hostingEnvironment;
            _helperService = helperService;
            _helperImageService = helperImageService;
            _customerService = customerService;
        }


        [HttpPost]
        public IActionResult UploadHelperImages()
        {
            DateTime now = DateTime.Now;
            var images = Request.Form.Files;                                                    // get images that is sent to server
            var numbers = Request.Form.SingleOrDefault(x => x.Key.Equals("NumberOfImages"));    // get number of images sent to server
            var helper = Request.Form.LastOrDefault();                                          // get HelperId correspond with images
            if (images.Count == 0)
            {
                return new BadRequestObjectResult(images);
            }
            else
            {
                int imagesnumber = int.Parse(numbers.Value);
                string helperId = helper.Value.ToString();

                string username = _helperService.GetUserName(helperId);

                for (int i = 0; i < imagesnumber; i++)
                {
                    var file = images[i];
                    var filename = ContentDispositionHeaderValue
                                        .Parse(file.ContentDisposition)
                                        .FileName
                                        .Trim('"');

                    var imageFolder = $@"\helper-side\images\" + username;

                    string folder = _hostingEnvironment.WebRootPath + imageFolder;

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string filePath = Path.Combine(folder, filename);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    string fullpath = Path.Combine(imageFolder, filename).Replace(@"\", @"/");

                    _helperImageService.AddImage(helperId, fullpath);
                }
                

                return new OkObjectResult(new ResultEmpty());
            }
        }


        [HttpGet]
        public IActionResult GetById(string helperId)
        {
            var result = _helperImageService.GetHelpImageByHeId(helperId);

            return new OkObjectResult(result);
        }


        [HttpPost]
        public IActionResult Delete(int ImageId, string ImagePath)
        {
            _helperImageService.DeleteImage(ImageId, ImagePath);

            return new OkObjectResult(new ResultEmpty());
        }


        [HttpGet]
        public IActionResult GetCuAvatarById(string customerId)
        {
            var result = _customerService.GetAvatarPath(customerId);

            return new OkObjectResult(new GenericResult(result, "AvatarPath"));
        }


        [HttpPost]
        public IActionResult UploadCustomerAvatar()
        {
            DateTime now = DateTime.Now;
            var avatar = Request.Form.Files;                         // Get Customer's avatar that is sent to server
            var customer = Request.Form.LastOrDefault();             // Get Customer's Id

            if (avatar.Count == 0)
            {
                return new BadRequestObjectResult(avatar);
            }
            else
            {
                string customerId = customer.Value.ToString();

                string username = _customerService.GetCuUserName(customerId);        // Customer's username

                _customerService.CheckAvatar(customerId);

                var file = avatar[0];
                var filename = ContentDispositionHeaderValue
                                    .Parse(file.ContentDisposition)
                                    .FileName
                                    .Trim('"');

                var imageFolder = $@"\customer-side\images\" + username;

                string folder = _hostingEnvironment.WebRootPath + imageFolder;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filePath = Path.Combine(folder, filename);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                string fullpath = Path.Combine(imageFolder, filename).Replace(@"\", @"/");

                _customerService.AddAvatarPath(customerId, fullpath);

                return new OkObjectResult(new ResultEmpty());
            }
        }
    }
}