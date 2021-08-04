using Application.DTO;
using FluentValidation;

namespace API.Validators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(e => e).NotNull();
            RuleFor(e => e.FirstName).NotNull().NotEmpty();
            RuleFor(e => e.LastName).NotNull().NotEmpty();
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.Phone).NotNull().NotEmpty();
            RuleFor(e => e.EmployeeAddress).NotNull().SetValidator(new UpdateEmployeeAddressValidator());
        }
    }
}
