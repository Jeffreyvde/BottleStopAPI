using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Balance
    {
        public Balance()
        {
            BalanceTransaction = new HashSet<BalanceTransaction>();
        }

        public int BalanceId { get; set; }
        public float BalanceAmount { get; set; }

        public virtual ICollection<BalanceTransaction> BalanceTransaction { get; set; }
    }
}
