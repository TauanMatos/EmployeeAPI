using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual EmployeeAddress EmployeeAddress { get; set; }

    }
}
