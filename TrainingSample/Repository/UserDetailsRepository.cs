using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using TrainingSample.Entities;
using TrainingSample.EntityFramework;

namespace TrainingSample.Repository
{
    public class UserDetailsRepository : IUserDetails
    {
        public void Delete(int id)
        {
            using (var us = new TraineeEntities())
            {
                var viewModel = us.UserDetails.Where(x => x.UserId == id).FirstOrDefault();
                var viewModel1 = us.CarDetails.Where(x => x.UserId == id).ToList();
                viewModel.IsActive = false;
                //viewModel.IsActive = true;
                us.Entry(viewModel).State = EntityState.Modified;
                if (viewModel1.Count() > 0)
                    us.CarDetails.RemoveRange(viewModel1);

                us.SaveChanges();
            }
        }

        public EditViewModel GetEditDetails(int Id)
        {
            using (var us = new TraineeEntities())
            {
                var viewModel = us.UserDetails.Where(x => x.UserId == Id).FirstOrDefault();
                var cardetails = us.CarDetails.Where(x => x.UserId == Id).Select(y => new CarDetailsInfo
                {
                    Id = y.Id,
                    CarNumberPlate = y.CarLicense
                }).ToList();

                var userDetails = new EditViewModel
                {
                    UserId = viewModel.UserId,
                    UserEmail = viewModel.UserEmail,
                    FullName = viewModel.FullName,
                    CivilIdNumber = viewModel.CivilIdNumber
                };


                userDetails.CarDetails.AddRange(cardetails);


                return userDetails;

            }


        }

        public void GetEditDetail(EditViewModel insert)
        {
            using (var us = new TraineeEntities())
            {
                var viewModel = us.UserDetails.Where(x => x.UserId == insert.UserId).FirstOrDefault();
                var viewModel1 = us.CarDetails.Where(x => x.UserId == insert.UserId).ToList();

                viewModel.FullName = insert.FullName;
                viewModel.UserEmail = insert.UserEmail;
                viewModel.CivilIdNumber = insert.CivilIdNumber;

                us.Entry(viewModel).State = EntityState.Modified;

                foreach (var car in insert.CarDetails)
                {
                    var userCar = viewModel1.Where(x => x.Id == car.Id).FirstOrDefault();

                    userCar.CarLicense = car.CarNumberPlate;

                    us.Entry(userCar).State = EntityState.Modified;
                }

                us.SaveChanges();

            }


        }

        public void GetInsertDetail(UserDetails insert)
        {
            using (var dbContext = new TraineeEntities())
            {


                var user = new UserDetail()
                {
                    FullName = insert.FullName,
                    UserEmail = insert.UserEmail,
                    PasswordHash = insert.PasswordHash,
                    CivilIdNumber = insert.CivilIdNumber,

                    DOB = insert.DOB,
                    MobileNo = insert.MobileNo,
                    Address = insert.Address,
                    //RoleId = insert.RoleId,

                    ProfilePic = insert.ProfilePic,



                    CreatedDate = insert.CreatedDate,
                    ModifiedDate = insert.ModifiedDate,
                    IsNotificationActive = insert.IsNotificationActive,
                    IsActive = insert.IsActive,
                    DeviceId = insert.DeviceId,
                    DeviceType = insert.DeviceType,
                    FcmToken = insert.FcmToken,
                    verify = insert.verify,
                    VerifiedBy = insert.VerifiedBy,
                    Area = insert.Area,
                    Block = insert.Block,
                    Street = insert.Street,
                    Housing = insert.Housing,
                    Floor = insert.Floor,
                    NewPass = insert.NewPass,
                    ConPass = insert.ConPass,
                    Jadda = insert.Jadda,
                    Reason = insert.Reason,
                    ActivatedBy = insert.ActivatedBy,
                    ActivatedDate = insert.ActivatedDate


                };

                var car = new CarDetail()
                {
                    CarLicense = insert.CarLicense,
                    UserId = insert.UserId

                };
                dbContext.UserDetails.Add(user);
                dbContext.CarDetails.Add(car);
                dbContext.SaveChanges();
            }
        }



       /* public IEnumerable<UserDetails> GetUserDetails()
        {
            using (var dbContext = new TraineeEntities())
            {
                List<UserDetail> userDetails = dbContext.UserDetails.ToList();
                List<CarDetail> carDetails = dbContext.CarDetails.ToList();
                List<UserDetails> userViewModels = new List<UserDetails>();
                foreach (var user in userDetails)
                {

                    var data = new UserDetails
                    {

                        UserId = user.UserId,
                        FullName = user.FullName,
                        UserEmail = user.UserEmail,
                        CivilIdNumber = user.CivilIdNumber,


                    };

                    var cardetails = string.Join(",", carDetails.Where(x => x.UserId == user.UserId).Select(y => y.CarLicense).ToList());

                    data.CarLicense = cardetails;


                    userViewModels.Add(data);

                }
                userViewModels = userViewModels.Where(x => x.CarLicense != "").ToList();

                return userViewModels;




            }



        }*/
    }
}