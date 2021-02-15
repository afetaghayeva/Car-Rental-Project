using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using RecapProject.DataAccess.Abstract;
using RecapProject.DataAccess.Concrete.EntityFramework.Context;
using RecapProject.Entities.Concrete;
using RecapProject.Entities.DTOs;

namespace RecapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,CarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using CarContext context=new CarContext();
            var result = from c in context.Cars
                join co in context.Colors
                    on c.ColorId equals co.Id
                join b in context.Brands
                    on c.BrandId equals b.Id
                select new CarDetailDto()
                {
                    DailyPrice = c.DailyPrice, BrandName = b.BrandName, CarName = c.CarName,
                    ColorName = co.ColorName
                };
            return result.ToList();
        }
    }
}
