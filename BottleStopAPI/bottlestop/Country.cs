using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
        }

        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public string CountryName { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
