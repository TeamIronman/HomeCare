using HomeCare.Application.Common;
using HomeCare.Application.Common.Helper;
using HomeCare.Application.Interfaces;
using HomeCare.Application.ViewModels.Helper;
using HomeCare.Data.Entities;
using HomeCare.Data.Enums;
using HomeCare.Data.IRepositories;
using HomeCare.Infrastructure.Interfaces;
using HomeCare.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Application.Implementation
{
    public class HelperCheckService : IHelperCheckService
    {
        private readonly IHelperCheckRepository _helperCheckRepository;
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHelperRepository _helperRepository;
        private readonly IBillOptionRepository _billOptionRepository;

        public HelperCheckService(IHelperCheckRepository helperCheckRepository, IBillRepository billRepository, 
            IUnitOfWork unitOfWork, IHttpContextAccessor accessor, IHelperRepository helperRepository,
            IBillOptionRepository billOptionRepository)
        {
            _helperCheckRepository = helperCheckRepository;
            _billRepository = billRepository;
            _unitOfWork = unitOfWork;
            _accessor = accessor;
            _helperRepository = helperRepository;
            _billOptionRepository = billOptionRepository;
        }

        public void BillAccept(int id)
        {
            var bill = _billRepository.FindById(id);

            var httpContext = _accessor.HttpContext;
            var helpersession = httpContext.Session.Get<HelperLogin>(CommonConstants.HELPER_SESSION);   // Lấy thông tin của helper nhận bill

            bill.HelperId = helpersession.Id;              // cập nhật helperid cho bill đã có helper nhận
            bill.BillStatus = BillStatus.Inprocess;        // chuyển billstatus sang đã có helper nhận
            bill.SortOrder = 3;                            // cập nhật thứ tự sắp xếp

            _billRepository.Update(bill);


            var check = new HelperCheck()                  // tạo thông tin để helper check khi nhận bill  (bắt buộc)
            {                                              // thông tin này tương ứng với bill mà helper nhận
                BillId = bill.Id
            };

            _helperCheckRepository.Add(check);

            _unitOfWork.Commit();

        }
        

        public int CheckSingle(HeCheckViewModel vm)
        {
            var httpContext = _accessor.HttpContext;
            var helpersession = httpContext.Session.Get<HelperLogin>(CommonConstants.HELPER_SESSION);   // Lấy thông tin của helper nhận bill

            var helper = _helperRepository.FindById(helpersession.Id);   // Tìm helper trong DB

            vm.Password = Encryptor.MD5Hash(vm.Password);

            if (helper.Password == vm.Password)
            {
                var helpercheckbill = _helperCheckRepository.FindSingle(x => x.BillId == vm.Id);   //Tìm bản ghi trong bảng HelperCheck có BillId == vm.id

                var bill = _billRepository.FindById(vm.Id);    //Lấy ra bill mà helper đang check

                var billoption = _billOptionRepository.FindById(bill.BillOptionId);

                DateTime CT = DateTime.Now;

                var currenthour = CT.Hour;                  // Lấy ra giờ hiện tại
                var currentminute = CT.Minute;              // Lấy ra phút hiện tại

                var currenttime = currenthour + (double)currentminute / 60;      // chuyển giờ hiện tại ra số thực


                string[] ST = bill.Starttime.Split(' ');    // StartTime là chuỗi string dạng hh:mm AM(hoặc PM), tách riêng phần hh:mm và AM(hoặc PM) vào 2 phần tử của mảng ST


                double starttime;

                if (ST[1].Equals("AM"))
                {
                    string[] StartTime = ST[0].Split(':');

                    starttime = int.Parse(StartTime[0]) + double.Parse(StartTime[1]) / 60;          // chuyển thời gian bắt đầu làm ra số thực
                }
                else
                {
                    string[] StartTime = ST[0].Split(':');

                    starttime = int.Parse(StartTime[0]) + 12 + double.Parse(StartTime[1]) / 60;     // chuyển thời gian bắt đầu làm ra số thực
                }

                

                string[] WH = billoption.Workinghours.Split('h');  // WorkingHour là có dạng 1h hoặc 2h , tách riêng số và chữ h vào 2 phần tử của mảng WH


                var workinghour = int.Parse(WH[0]);   // chuyển thời gian làm việc ra số thực


                // check đầu chỉ có hiệu lực trong vòng 5 phút đầu làm việc
                bool firstcheckcondition = currenttime >= starttime && currenttime <= (starttime + (double)5 / 60);     


                // check thứ 2 chỉ có hiệu lực trong vòng 5 phút tính từ lúc giữa giờ làm việc
                bool secondcheckcondition = currenttime >= (starttime + (double)workinghour / 2) && currenttime <= (starttime + (double)workinghour / 2 + (double)5 / 60);


                // check thứ 3 chỉ có hiệu lực trong vòng 5 phút tính từ lúc hết giờ làm việc
                bool thirdcheckcondition = currenttime >= (starttime + workinghour) && currenttime <= (starttime + workinghour + (double)5 / 60);


                if (firstcheckcondition && vm.HPCheck == true)    
                {
                    helpercheckbill.Firstcheck = true;

                    _helperCheckRepository.Update(helpercheckbill);

                    _unitOfWork.Commit();

                    return 1;
                }
                else if (secondcheckcondition && vm.HPCheck == true)
                {
                    helpercheckbill.Secondcheck = true;

                    _helperCheckRepository.Update(helpercheckbill);

                    _unitOfWork.Commit();

                    return 2;
                }
                else if (thirdcheckcondition && vm.HPCheck == true)
                {
                    helpercheckbill.Thirdcheck = true;

                    _helperCheckRepository.Update(helpercheckbill);

                    _unitOfWork.Commit();

                    if (helpercheckbill.Firstcheck == true && helpercheckbill.Secondcheck == true)
                    {
                        bill.BillStatus = BillStatus.Completed;
                        bill.SortOrder = 4;

                        _billRepository.Update(bill);

                        _unitOfWork.Commit();

                        return 3;
                    }
                    else
                    {
                        bill.BillStatus = BillStatus.Incomplete;
                        bill.SortOrder = 5;

                        _billRepository.Update(bill);

                        _unitOfWork.Commit();

                        return -2;
                    }

                    
                }
                else
                {
                    return -1; //wrong check time
                }
            }
            else
            {
                return 0; //Incorrect password
            }
        }



        public void BillCancel(int id)
        {
            var httpContext = _accessor.HttpContext;
            var helpersession = httpContext.Session.Get<HelperLogin>(CommonConstants.HELPER_SESSION);   // Lấy thông tin của helper nhận bill

            var helper = _helperRepository.FindById(helpersession.Id);   // Tìm helper trong DB

            var bill = _billRepository.FindById(id);


            if (bill.BillStatus == BillStatus.Cancelled)
            {
                
                //Tìm bản ghi trong bảng HelperCheck có BillId == vm.id
                var helpercheckbill = _helperCheckRepository.FindSingle(x => x.BillId == id);

                // Khách hàng hủy bill
                helpercheckbill.Cancel = true;

                _helperCheckRepository.Update(helpercheckbill);

                _unitOfWork.Commit();                
               
            }            
            else
            {
                
                bill.BillStatus = BillStatus.New;
                bill.SortOrder = 1;
                bill.HelperId = null;

                _billRepository.Update(bill);

                _unitOfWork.Commit();


                //Tìm bản ghi trong bảng HelperCheck có BillId == vm.id
                var helpercheckbill = _helperCheckRepository.FindSingle(x => x.BillId == bill.Id);

                _helperCheckRepository.Remove(helpercheckbill);

                helper.CancelBillNumber = helper.CancelBillNumber + 1;

                _helperRepository.Update(helper);

                _unitOfWork.Commit();                
                
            }
            
        }
    }
}
