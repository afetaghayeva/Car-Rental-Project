using System;
using FluentValidation.Resources;
using RecapProject.Business.Concrete;
using RecapProject.Business.Constants;
using RecapProject.DataAccess.Concrete.EntityFramework;
using RecapProject.Entities.Concrete;
using RecapProject.Entities.DTOs;

namespace RecapProject.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager();

            //ColorManager();

            //BrandManager();

            //CarDetailDto();

            //UserManager();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate =new DateTime(2022,2,3),
                ReturnDate = new DateTime(2021,2,3)
            });

            Console.WriteLine(result.Message);

        }


        //private static void UserManager()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User
        //    {
        //        Email = "afetagayeva.2003@gmail.com",
        //        FirstName = "Afet",
        //        LastName = "Agayeva",
        //        Password = "2554880rr"
        //    });
        //    var result = userManager.GetAll();
        //    foreach (var user in result.Data)
        //    {
        //        Console.WriteLine(user.Email);
        //    }
        //}

        private static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var carDetailDto in result.Data)
                {
                    Console.WriteLine(carDetailDto.CarName + "/" + carDetailDto.BrandName + "/" + carDetailDto.ColorName + "/" +
                                      carDetailDto.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);

            }

        }

        private static void BrandManager()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand
            {
                BrandName = "Volvo"
            });
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.Id, brand.BrandName);
            }
        }

        private static void ColorManager()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color()
            {
                Id = 5,
                ColorName = "Yellow"
            });
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.Id, color.ColorName);
            }
        }

        private static void CarManager()
        {
            try
            {
                CarManager carManager = new CarManager(new EfCarDal());
                carManager.Update(new Car
                {
                    Id = 1,
                    BrandId = 2,
                    ColorId = 3,
                    DailyPrice = 1000,
                    CarName = "Toyota",
                    ModelYear = 2009,
                    Description = "Toyota car"
                });
                var result = carManager.GetAll();
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} {1}", car.CarName, car.DailyPrice);
                }
            }
            catch
            {
                Console.WriteLine("Please enter the values ​​correctly");
            }
        }
    }
}
