using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Address
    {
        public Address()
        {
            User = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
        public string Additional { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
