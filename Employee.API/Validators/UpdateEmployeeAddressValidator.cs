using Application.DTO.Update;
using FluentValidation;

namespace API.Validators
{
    public class UpdateEmployeeAddressValidator : AbstractValidator<UpdateEmployeeAddressDto>
    {
        public UpdateEmployeeAddressValidator()
        {
            RuleFor(e => e).NotNull();
            RuleFor(e => e.City).NotNull().NotEmpty();
            RuleFor(e => e.Country).NotNull().NotEmpty();
            RuleFor(e => e.PostCode).NotNull().NotEmpty();
            RuleFor(e => e.State).NotNull().NotEmpty();
            RuleFor(e => e.Street).NotNull().NotEmpty();
            RuleFor(e => e.StreetNumber).NotNull().NotEmpty();
        }
    }
}
