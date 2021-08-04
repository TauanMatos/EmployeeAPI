using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class EmployeeAddressDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
