using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMealtime.Models
{
    public class Driver
    {
        public RecipeBook Book { get; set; }
        public Pantry Current_Pantry { get; set; }

        void Init() { }
		void LoadRecipeBook()
		{
			IFormatter recipeFormatter = new BinaryFormatter();
			Stream recipeStream = new FileStream("MyRecipes.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
			Book = (RecipeBook)recipeFormatter.Deserialize(recipeStream);
			recipeStream.Close();
		}
		void LoadPantry()
		{
			IFormatter pantryFormatter = new BinaryFormatter();
			Stream pantryStream = new FileStream("MyPantry.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
			Current_Pantry = (Pantry)pantryFormatter.Deserialize(pantryStream);
			pantryStream.Close();
		}

		void RecipeSelect() { }
    }
}
