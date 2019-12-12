using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class Balance
    {
        public Balance()
        {
            BalanceTransaction = new HashSet<BalanceTransaction>();
        }

        public int BalanceId { get; set; }
        public float Balance1 { get; set; }

        public virtual ICollection<BalanceTransaction> BalanceTransaction { get; set; }
    }
}
