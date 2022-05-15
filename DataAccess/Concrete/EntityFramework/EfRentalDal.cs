using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,DataDbContext>,IRentalDal
    {
        public void Add(Rental rental)
        {
            // if a car is already rented (if the last result of a car's return date is null then it means it's already currently rented)
            // then I wont allow renting it
            using (DataDbContext context = new DataDbContext())
            {
                var lastRentalOfSelectedCar = context.Rentals.SingleOrDefault(r=>r.CarId== rental.CarId && r.ReturnDate == null);

                if (lastRentalOfSelectedCar == null)
                {
                    context.Set<Rental>().Add(rental);
                    context.SaveChanges();
                }
                else
                {

                    throw new Exception("Car is currently rented");
                }
            }
        }
    }
}
