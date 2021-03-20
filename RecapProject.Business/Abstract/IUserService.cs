using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using RecapProject.Entities.Concrete;

namespace RecapProject.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
