using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class BalanceTransaction
    {
        public int BalanceTransactionId { get; set; }
        public int UserId { get; set; }
        public int Change { get; set; }

        public virtual User User { get; set; }
    }
}
