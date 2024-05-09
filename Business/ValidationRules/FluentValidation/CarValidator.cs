using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
			RuleFor(c => c.DailyPrice).NotEmpty();
			RuleFor(p => p.Name).MinimumLength(2).WithMessage("Araba ismi 2 herfden cox olmalidir");
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Gunluk fiyat 0-dan buyuk olmalidir");
        }
    }
}
