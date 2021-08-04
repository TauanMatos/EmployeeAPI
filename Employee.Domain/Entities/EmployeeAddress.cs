using Domain.Entities.Base;

namespace Domain.Entities
{
    public class EmployeeAddress : BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public virtual int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
