using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class User
    {
        public User()
        {
            BalanceTransaction = new HashSet<BalanceTransaction>();
            Favorite = new HashSet<Favorite>();
            Order = new HashSet<Order>();
            UserBottle = new HashSet<UserBottle>();
        }

        public int UserId { get; set; }
        public int AddressId { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Verified { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<BalanceTransaction> BalanceTransaction { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<UserBottle> UserBottle { get; set; }
    }
}
