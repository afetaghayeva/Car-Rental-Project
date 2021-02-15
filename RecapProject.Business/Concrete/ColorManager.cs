using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using RecapProject.Business.Abstract;
using RecapProject.Business.Constants;
using RecapProject.DataAccess.Abstract;
using RecapProject.Entities.Concrete;

namespace RecapProject.Business.Concrete
{
    public class ColorManager:IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorAdd);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdate);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDelete);
        }
    }
}
