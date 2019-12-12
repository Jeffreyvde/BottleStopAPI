using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BeverageId { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Order Order { get; set; }
    }
}
