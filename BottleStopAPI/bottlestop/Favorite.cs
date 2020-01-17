using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int BeverageId { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual User User { get; set; }
    }
}
