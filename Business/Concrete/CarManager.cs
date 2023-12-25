using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        //Farkli ortamlara geciste kolaylik saglamasi icin burada bir referans tutucu blogu olusturuyoruz.              
        //Bu bugun Sql yarin MySql baska bir gunde PostgreSql referansi tutabilir.

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //Business codes
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 2000)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarByBrandAndColor(brandId, colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            /*if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }*/
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsId(int carId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(c => c.CarId == carId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, "");
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdWithDetails(int brandId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(c => c.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, "");
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorIdWithDetails(int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(c => c.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, "");
            }
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

    }
}
