using FluentValidation;
using RecapProject.Entities.Concrete;

namespace RecapProject.Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice ).GreaterThan(0);
        }
    }
}
