using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //List<Car> _cars = new List<Car>
        //{
        //    new Car { Id = 1, BrandId = 1 ,ColorId=4,DailyPrice=500,Description="Mercedes Jeep 4x4 110 HP",ModelYear=2022},
        //    new Car { Id = 2, BrandId = 1 ,ColorId=2,DailyPrice=350,Description="Mercedes Benz 2x4 90 HP",ModelYear=2018},
        //    new Car { Id = 3, BrandId = 2 ,ColorId=2,DailyPrice=250,Description="Toyota Auris 2x4 75 HP",ModelYear=2015},
        //    new Car { Id = 4, BrandId = 3 ,ColorId=3,DailyPrice=450,Description="Audi Jeep 4x4 110 HP",ModelYear=2022},
        //    new Car { Id = 5, BrandId = 4 ,ColorId=4,DailyPrice=700,Description="Porsche 2x4 150 HP",ModelYear=2022}
        //};

        //public void Add(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Delete(Car car)
        //{
        //    Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
        //    _cars.Remove(carToDelete);
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars.ToList();
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Car GetById(int id)
        //{
        //    return _cars.SingleOrDefault(c=>c.Id == id);
        //}

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
        //    carToUpdate.Id = car.Id;
        //    carToUpdate.BrandId = car.BrandId; 
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.Description = car.Description;
        //    carToUpdate.DailyPrice = car.DailyPrice;
        //    carToUpdate.ModelYear = car.ModelYear;
        //}
        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
