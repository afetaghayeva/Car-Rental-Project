using Core.DataAccess.EntityFramework;
using RecapProject.DataAccess.Abstract;
using RecapProject.DataAccess.Concrete.EntityFramework.Context;
using RecapProject.Entities.Concrete;

namespace RecapProject.DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal:EfEntityRepositoryBase<Brand,CarContext>,IBrandDal
    {
    }
}
