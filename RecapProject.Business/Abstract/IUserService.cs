using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using RecapProject.Entities.Concrete;

namespace RecapProject.Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<List<User>> GetAll();
    }
}
