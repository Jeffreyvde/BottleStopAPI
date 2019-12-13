using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Beverage
    {
        public Beverage()
        {
            AvailableBeverage = new HashSet<AvailableBeverage>();
            BottleModel = new HashSet<BottleModel>();
            Favorite = new HashSet<Favorite>();
            MixCombination = new HashSet<MixCombination>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int BeverageId { get; set; }
        public string BeverageName { get; set; }
        public string BeverageImage { get; set; }
        public float CostPerMl { get; set; }

        public virtual ICollection<AvailableBeverage> AvailableBeverage { get; set; }
        public virtual ICollection<BottleModel> BottleModel { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
        public virtual ICollection<MixCombination> MixCombination { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
