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

            var result = carManager.GetCarDetailDtos();
            foreach (var car in result)
            {
                Console.WriteLine($"{car.CarName} | {car.BrandName} | {car.ColorName} | {car.DailyPrice}");
            }
        }
    }
}
