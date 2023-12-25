using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                on c.BrandId equals b.Id
                             join cl in context.Colors
                                on c.ColorId equals cl.Id
                             where c.BrandId == brandId && c.ColorId == colorId
                             select new CarDetailDto()
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 ImagePath = (from ci in context.Images where c.Id == ci.CarId select ci.ImagePath).FirstOrDefault()!
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.Id
                             join co in context.Colors
                                 on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = c.BrandId,
                                 BrandName = b.Name,
                                 ColorId = c.ColorId,
                                 ColorName = co.Name,
                                 //MinFindexScore = c.MinFindexScore,
                                 CarName = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from ci in context.Images where c.Id == ci.CarId select ci.ImagePath).FirstOrDefault()!
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

            }
        }
      
    }
}
