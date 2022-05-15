using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  CarTest();
            // UserTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, RentDate = new DateTime(2022, 02, 02), ReturnDate = new DateTime(2022, 03, 02) });
            rentalManager.Add(new Rental { CarId = 4, CustomerId = 3, RentDate = new DateTime(2022, 04, 02), ReturnDate = new DateTime(2022, 05, 02) });

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(new User
            {
                FirstName = "Johnny",
                LastName = "Bravo",
                Email = "JohnnyBravo@thisisadraftwebsite.com",
                Password = "123456"
            });
            userManager.Add(new User
            {
                FirstName = "Captain",
                LastName = "Jack",
                Email = "CaptainJack@thisisadraftwebsite.com",
                Password = "6587821a."
            });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetailDtos();
            foreach (var car in result.Data)
            {
                Console.WriteLine($"{car.CarName} | {car.BrandName} | {car.ColorName} | {car.DailyPrice}");
            }
        }
    }
}
