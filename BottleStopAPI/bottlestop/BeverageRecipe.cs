using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class BeverageRecipe
    {
        public BeverageRecipe()
        {
            MixCombination = new HashSet<MixCombination>();
        }

        public int BeverageRecipeId { get; set; }
        public string MixName { get; set; }
        public float FillRatio { get; set; }

        public virtual ICollection<MixCombination> MixCombination { get; set; }
    }
}
