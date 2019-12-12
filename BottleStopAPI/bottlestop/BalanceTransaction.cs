using System;
using System.Collections.Generic;

namespace BottleStopAPI.bottlestop
{
    public partial class BalanceTransaction
    {
        public int BalanceTransactionId { get; set; }
        public int BalanceId { get; set; }
        public int UserId { get; set; }
        public int Change { get; set; }

        public virtual Balance Balance { get; set; }
        public virtual User User { get; set; }
    }
}
