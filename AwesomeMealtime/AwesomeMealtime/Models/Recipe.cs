using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AwesomeMealtime.Models
{
	public class Recipe : INotifyPropertyChanged
	//Assigned to Bryan Dorman
	{
		private string name;
		private string descript;
		private string warning;
		private Image image;
		private TimeSpan cook;
		private TimeSpan prep;
		private Difficulty difficulty;
		private bool isDangerous;

		public string Name { get{return name;} set { name = value; } }
        public string Dish_Description { get; set; }
        public string Warning_Message { get; set; }
        public List<string> Directions { get; set; }
		public List<Ingredient> Ingredients { get; set; }
        public TimeSpan CookTime { get; set; }
        public TimeSpan PrepTime { get; set; }
        public Difficulty Recipe_Difficulty { get; set; }
        public bool Warning { get; set; }
        public Image MealPicture { get; set; }

		protected void FieldChanged([CallerMemberName] string field = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(field));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public Recipe()
		{
			Directions = new List<string>();
			Ingredients = new List<Ingredient>();
			cook = new TimeSpan();
			prep = new TimeSpan();
			image = new Image();

			difficulty = Difficulty.NA;
		}


		public enum Difficulty
        {
			simple, easy, medium, intense, hard, NA
        }
    }
}
