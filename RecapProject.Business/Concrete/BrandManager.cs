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
    public class BrandManager:IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandAdd);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDelete);
        }
    }
}
