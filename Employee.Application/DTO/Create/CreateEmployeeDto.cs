namespace Application.DTO
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CreateEmployeeAddressDto EmployeeAddress { get; set; }
    }
}
