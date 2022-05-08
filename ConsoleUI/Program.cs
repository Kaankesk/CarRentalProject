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
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 375,
                Description = "Great For Outdoor Activities",
                ModelYear = 2008
            });

            var result = carManager.GetAll();
            foreach (var car in result)
            {
                Console.WriteLine($"** {car.BrandId} is {car.DailyPrice}$, its model year is {car.ModelYear}");
                Console.WriteLine("************************");
            }
        }
    }
}
