using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Beverage
    {
        public Beverage()
        {
            BeveragePrice = new HashSet<BeveragePrice>();
            BottleModel = new HashSet<BottleModel>();
            Favorite = new HashSet<Favorite>();
            MachineAvailability = new HashSet<MachineAvailability>();
            OrderDetail = new HashSet<OrderDetail>();
            Recipe = new HashSet<Recipe>();
        }

        public int BeverageId { get; set; }
        public int? BrandId { get; set; }
        public int? BeverageTypeId { get; set; }
        public string BeverageName { get; set; }
        public string BeverageImage { get; set; }

        public virtual BeverageType BeverageType { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<BeveragePrice> BeveragePrice { get; set; }
        public virtual ICollection<BottleModel> BottleModel { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
        public virtual ICollection<MachineAvailability> MachineAvailability { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
