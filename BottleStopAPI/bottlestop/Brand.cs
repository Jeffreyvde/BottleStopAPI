using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Brand
    {
        public Brand()
        {
            Beverage = new HashSet<Beverage>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Beverage> Beverage { get; set; }
    }
}
