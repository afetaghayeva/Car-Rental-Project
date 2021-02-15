using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using RecapProject.Entities.Concrete;

namespace RecapProject.DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
    }
}
