using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMealtime.Models
{
    public class Driver
    {
        public RecipeBook Book { get; set; }
        public Pantry Current_Pantry { get; set; }


        void Init() { }
        void LoadRecipeBook() { }
        void LoadPantry() { }
        void RecipeSelect() { }
    }
}
