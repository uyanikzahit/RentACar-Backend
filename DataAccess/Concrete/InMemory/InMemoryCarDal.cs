using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {
        //List<Car> _cars;
        //public InMemoryCarDal()
        //{
        //    _cars = new List<Car>
        //    {
        //        new Car {CarId=1, CategoryId=1,BrandId=1,ColorId=1,BrandName="BMW M5",DailyPrice=300,Description="Konforlu",ModelYear=2023},
        //        new Car {CarId=2, CategoryId=1,BrandId=1,ColorId=1,BrandName="BMW İ8",DailyPrice=600,Description="Hızlı",ModelYear=2023},
        //        new Car {CarId=3, CategoryId=1,BrandId=2,ColorId=1,BrandName="MERCEDES AMG",DailyPrice=300,Description="Konforlu",ModelYear=2023},
        //        new Car {CarId=4, CategoryId=2,BrandId=2,ColorId=1,BrandName="MERCEDES CLA",DailyPrice=600,Description="Konforlu",ModelYear=2023},
        //        new Car {CarId=5, CategoryId=2,BrandId=2,ColorId=1,BrandName="MERCEDES G200",DailyPrice=900,Description="Konforlu",ModelYear=2023}
        //    };
        //}
        //public void Add(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Delete(Car car)
        //{
        //    Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        //    _cars.Remove(carToDelete);
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAllByCategory(int categoryId)
        //{
        //    return _cars.Where(c => c.CategoryId == categoryId).ToList();
        //}

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        //    carToUpdate.CategoryId = car.CategoryId;
        //    carToUpdate.BrandId = car.BrandId;
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.BrandName = car.BrandName;
        //    carToUpdate.DailyPrice = car.DailyPrice;
        //    carToUpdate.Description = car.Description;
        //    carToUpdate.ModelYear = car.ModelYear;
            
        //}
    }
}
