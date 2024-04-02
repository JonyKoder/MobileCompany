using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCompany.Models.Models
{
    public class Abonent
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
    }
}
