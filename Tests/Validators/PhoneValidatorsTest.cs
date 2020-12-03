using Models.Validators;
using System.ComponentModel;
using Xunit;
using Models;
using FluentValidation;
using FluentValidation.TestHelper;
using FluentAssertions;

namespace Tests.Validators
{
    public class PhoneValidatorsTest
    {
        private readonly PhoneValidators validator;

        public PhoneValidatorsTest()
        {
            validator = new PhoneValidators();
        }

        [Fact]
        [Description("Should validate phone number")]
        public void ShouldValidatePhoneNumber()
        {
            var phone = new Phones() { Id = 1, Number = 99999999 };

            var result = validator.TestValidate(phone);

            result.ShouldNotHaveValidationErrorFor(r => r.Number);
        }

        [Fact]
        [Description("Should invalidate phone number")]
        public void ShouldInvalidatePhoneNumber()
        {
            var phone = new Phones() { Id = 1, Number = 41 };

            var result = validator.TestValidate(phone);

            result.ShouldHaveValidationErrorFor(r => r.Number).WithErrorMessage("Invalid number");
        }
    }
}
