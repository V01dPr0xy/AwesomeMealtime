using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AwesomeMealtime.Models
{
    public class Recipe
        //Assigned to Bryan
    {
        public string Name { get; set; }
        public string Dish_Description { get; set; }
        public string Warning_Message { get; set; }
        public List<string> Directions { get; set; }
        public TimeSpan CookTime { get; set; }
        public TimeSpan PrepTime { get; set; }
        public Difficulty Recipe_Difficulty { get; set; }
        public bool Warning { get; set; }
        public Image MyProperty { get; set; }
        
        public enum Difficulty
        {

        }
    }
}
