using Application.DTO;
using FluentValidation;

namespace API.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(e => e).NotNull();
            RuleFor(e => e.FirstName).NotNull().NotEmpty();
            RuleFor(e => e.LastName).NotNull().NotEmpty();
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.Phone).NotNull().NotEmpty();
            RuleFor(e => e.EmployeeAddress).NotNull().SetValidator(new CreateEmployeeAddressValidator());
        }
    }
}
