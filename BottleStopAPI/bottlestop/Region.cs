using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Region
    {
        public Region()
        {
            Country = new HashSet<Country>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Country> Country { get; set; }
    }
}
