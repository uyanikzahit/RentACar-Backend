using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        IColorService _colorService;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        public IResult Add(Color color)
        {
            if (color.Name.Length >= 3)
            {
                _colorDal.Add(color);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetColorById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        public IResult Remove(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }


        private IResult CheckIfCarNameExists(string colorName)
        {
            var result = _colorDal.GetAll(c => c.Name == colorName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


        //Renk kontrolünü sorgulayan kural(15).
        private IResult CheckIfColorLimitExceded()
        {
            var result = _colorService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult();

            }
            return new SuccessResult();
        }
    }
}
