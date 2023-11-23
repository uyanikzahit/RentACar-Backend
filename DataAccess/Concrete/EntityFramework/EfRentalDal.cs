using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars
                       on rent.CarId equals car.Id
                             join customer in context.Customers
                                 on rent.CustomerId equals customer.Id
                             join user in context.Users
                                 on customer.Id equals user.Id
                             join brand in context.Brands
                                 on car.BrandId equals brand.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rent.RentalId,
                                 CarId = car.Id,
                                 ModelFullName = $"{brand.Name} {car.Name}",
                                 CustomerId = customer.Id,
                                 CustomerFullName = $"{user.FirstName} {user.LastName}",
                                 ReturnDate = rent.ReturnDate,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rent.RentDate                         
                                 
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
