using Application.DTO;
using FluentValidation;

namespace API.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e).NotNull();
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.FirstName).NotNull().NotEmpty();
            RuleFor(e => e.LastName).NotNull().NotEmpty();
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.Phone).NotNull().NotEmpty();
            RuleFor(e => e.EmployeeAddress).NotNull().SetValidator(new EmployeeAddressValidator());
        }
    }
}
