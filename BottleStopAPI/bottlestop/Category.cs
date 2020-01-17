using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Category
    {
        public Category()
        {
            BottleModel = new HashSet<BottleModel>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<BottleModel> BottleModel { get; set; }
    }
}
