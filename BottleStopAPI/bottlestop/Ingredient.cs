using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            Pump = new HashSet<Pump>();
            Recipe = new HashSet<Recipe>();
        }

        public int IngredientId { get; set; }
        public string MixName { get; set; }

        public virtual ICollection<Pump> Pump { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
