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
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            _userDal.Update(user);
            return new SuccessResult(Messages.UserAdd);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
    }
}
