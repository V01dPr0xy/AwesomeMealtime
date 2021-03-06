﻿using System;
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
			Book = new RecipeBook();
			Current_Pantry = new Pantry();

			LoadPantry();
			LoadRecipeBook();
		}
		public void Close()
		{
			SavePantry();
			SaveRecipe();
		}

		void LoadRecipeBook()
		{
			BinaryFormatter recipeFormatter = new BinaryFormatter();
			FileStream recipeStream;
			try
			{
				recipeStream = new FileStream("MyRecipe.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
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
			BinaryFormatter pantryFormatter = new BinaryFormatter();
			FileStream pantryStream;
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
        
        void SavePantry()
        {
            if (Current_Pantry != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();

				FileStream fs2 = new FileStream("MyPantry.bin", FileMode.Append, FileAccess.Write, FileShare.None);

                try
                {
                    formatter.Serialize(fs2, Current_Pantry);
                }
                catch (SerializationException b)
                {
                    Console.WriteLine("My Pantry Failed to Serialize " + b.Message);
                    throw;
                }
                finally
                {
                    fs2.Close();
                }
            }
        }
		void SaveRecipe()
        {

            if (Book != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
				FileStream fs = new FileStream("MyRecipe.bin", FileMode.Append, FileAccess.Write, FileShare.None);

                try
                {
					formatter.Serialize(fs, Book);
                }
                catch (SerializationException a)
                {
                    Console.WriteLine("My Recipe Failed to Serialize." + a.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
        
    }
}
