using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AwesomeMealtime.Models
{
	[Serializable]
	public class Recipe
	//Assigned to Bryan Dorman
	{
		private string name;
        private string descript;
		private string instruct;
        private ObservableCollection<Ingredient> ingredients;
		private Image image;
		private TimeSpan cook;
		private TimeSpan prep;
		private Difficulty difficulty;
		private bool isDangerous;

		public string Name { get { return name; } set { name = value; FieldChanged(); } }
        public string Dish_Description { get { return descript; } set { descript = value; FieldChanged(); } }
        public string Directions { get { return instruct; } set { instruct = value; FieldChanged(); } }
		public ObservableCollection<Ingredient> Ingredients { get {return ingredients; } set {ingredients = value; } }
        public TimeSpan CookTime { get { return cook; } set { cook = value; FieldChanged(); } }
        public TimeSpan PrepTime { get { return prep; } set { prep = value; FieldChanged(); } }
        public Difficulty Recipe_Difficulty { get { return difficulty; } set { difficulty = value; FieldChanged(); } }
        public bool Warning { get { return isDangerous; } set { isDangerous = value; FieldChanged(); } }
        public Image MealPicture { get { return image; } set { image = value; FieldChanged(); } }

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
			Ingredients = new ObservableCollection<Ingredient>();
			cook = new TimeSpan();
			prep = new TimeSpan();
			image = new Image();

			difficulty = Difficulty.NA;
		}

		[Serializable]
		public enum Difficulty
        {
			simple, easy, medium, intense, hard, NA
        }
    }
}
