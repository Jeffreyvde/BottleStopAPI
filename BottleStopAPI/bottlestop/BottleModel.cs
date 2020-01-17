using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class BottleModel
    {
        public int BottleModelId { get; set; }
        public string BottleId { get; set; }
        public int? CetegoryId { get; set; }
        public int? BeverageId { get; set; }
        public int BottleSizeMl { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Bottle Bottle { get; set; }
        public virtual Category Cetegory { get; set; }
    }
}
