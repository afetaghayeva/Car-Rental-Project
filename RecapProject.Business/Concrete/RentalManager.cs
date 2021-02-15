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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==default)
            {
                return new ErrorResult(Messages.CarRentedError);
            }

            if (rental.ReturnDate<rental.RentDate)
            {
                return new ErrorResult(Messages.RentTimeError);
            }

            if (rental.ReturnDate>=DateTime.Now && rental.RentDate>=DateTime.Now)
            {
                return new ErrorResult(Messages.RentAndReturnTimeError);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdd);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
