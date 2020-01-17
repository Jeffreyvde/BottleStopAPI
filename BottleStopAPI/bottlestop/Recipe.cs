using System;
using System.Collections.Generic;

namespace BottleStopAPI.BottleStop
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public int BeverageId { get; set; }
        public int IngredientId { get; set; }
        public float Ratio { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
