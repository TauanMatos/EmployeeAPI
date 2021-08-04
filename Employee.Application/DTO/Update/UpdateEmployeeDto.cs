using Application.DTO.Update;

namespace Application.DTO
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UpdateEmployeeAddressDto EmployeeAddress { get; set; }
    }
}
