using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using RecapProject.DataAccess.Abstract;
using RecapProject.DataAccess.Concrete.EntityFramework.Context;
using RecapProject.Entities.Concrete;

namespace RecapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarContext>,ICustomerDal
    {
    }
}
