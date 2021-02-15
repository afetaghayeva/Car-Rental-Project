using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using RecapProject.Business.Abstract;
using RecapProject.Business.Constants;
using RecapProject.Business.Utilities;
using RecapProject.Business.ValidationRules.FluentValidation;
using RecapProject.DataAccess.Abstract;
using RecapProject.Entities.Concrete;
using RecapProject.Entities.DTOs;

namespace RecapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IResult Add(Car car)
        {
            ValidationTool.FluentValidate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdd);
        }

        public IResult Update(Car car)
        {
            ValidationTool.FluentValidate(new CarValidator(), car);
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),"Listed");
        }
    }
}
