using System.Collections.Generic;
using Core.DataAccess;
using RecapProject.Entities.Concrete;
using RecapProject.Entities.DTOs;

namespace RecapProject.DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
