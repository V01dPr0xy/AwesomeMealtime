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

        public void Init() {
			LoadPantry();
			LoadRecipeBook();
		}
		void LoadRecipeBook()
		{
			IFormatter recipeFormatter = new BinaryFormatter();
			Stream recipeStream;
			try
			{
				recipeStream = new FileStream("MyRecipes.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
				Book = (RecipeBook)recipeFormatter.Deserialize(recipeStream);
				recipeStream.Close();
			}
			catch
			{
				Console.WriteLine("No prior recipes found.");
			}
		}
		void LoadPantry()
		{
			IFormatter pantryFormatter = new BinaryFormatter();
			Stream pantryStream;
			try
			{
				pantryStream = new FileStream("MyPantry.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
				Current_Pantry = (Pantry)pantryFormatter.Deserialize(pantryStream);
				pantryStream.Close();
			}
			catch
			{
				Console.WriteLine("No prior foods found.");
			}
		}

		//void RecipeSelect() { }
    }
}
