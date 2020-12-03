using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Validators
{
    public class PhoneValidators : AbstractValidator<Phones>
    {
        public PhoneValidators()
        {
            RuleFor(p => p.Number)
                .Must(ValidateNumber)
                .WithMessage("Invalid number");
        }

        private bool ValidateNumber(int number)
        {
            return number.ToString().Length > 7 && number.ToString().Length <= 9;
        }
    }
}
