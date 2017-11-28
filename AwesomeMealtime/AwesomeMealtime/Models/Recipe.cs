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
	{
		private string name;
		private string descript;
		private string warning;
		private List<string> instruction;
		private TimeSpan cook;
		private TimeSpan prep;
		private Difficulty difficulty;
		private bool isDangerous;
		private Image image;

		public string Name { get { return name; } set { name = value; FieldChanged(); } }
        public string Dish_Description { get { return descript; } set { descript = value; FieldChanged(); } }
		public string Warning_Message { get { return warning; } set { warning = value; FieldChanged(); } }
		public List<string> Directions { get { return instruction; } set { instruction = value; FieldChanged(); } }
		public TimeSpan CookTime { get { return cook; } set { cook = value; FieldChanged(); } }
		public TimeSpan PrepTime { get { return prep; } set { prep = value; FieldChanged(); } }
		public Difficulty Recipe_Difficulty { get { return difficulty; } set { difficulty = value; FieldChanged(); } }
		public bool HasWarning { get { return isDangerous; } set { isDangerous = value; FieldChanged(); } }
		public Image DishImage { get { return image; } set { image = value; FieldChanged(); } }

		public Recipe()
		{
			instruction = new List<string>();
			cook = new TimeSpan();
			prep = new TimeSpan();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void FieldChanged([CallerMemberName] string field = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(field));
			}
		}

		public void AddDirection(string edit, string reference, bool beforeAfter)
		{
			int index = Directions.IndexOf(reference);

			if(beforeAfter)
			{
				Directions.Insert(index, edit);
			}
			else
			{
				Directions.Insert(index + 1, edit);
			}
		}
		public void AddDirection(string edit, int index)
		{
			Directions.Insert(index, edit);
		}
		public void SubDirection(int index)
		{
			Directions.RemoveAt(index);
		}
		public void SubDirection(string edit)
		{
			Directions.Remove(edit);
		}

		public enum Difficulty
        {
			simple, easy, medium, intense, hard
        }
    }
}
