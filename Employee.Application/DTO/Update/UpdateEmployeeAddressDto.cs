using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Update
{
    public class UpdateEmployeeAddressDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
