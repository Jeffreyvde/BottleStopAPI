using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class MixCombination
    {
        public int MixCombinationId { get; set; }
        public int BeverageId { get; set; }
        public int BeverageRecpieId { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual BeverageRecipe BeverageRecpie { get; set; }
    }
}
