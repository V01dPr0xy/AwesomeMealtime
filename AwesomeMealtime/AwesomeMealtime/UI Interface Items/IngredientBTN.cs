using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using AwesomeMealtime.Models;

namespace AwesomeMealtime.UI_Interface_Items
{
    public class IngredientBTN
    {
        public Ingredient ingredient;
        public Button button;

        public IngredientBTN(Ingredient i)
        {
            ingredient = i;

            button = new Button()
            {
                Content = ingredient.Name + "     :     " + getIndexQuantityString(0)
            };
            button.Click += Click;
        }

        private string getIndexQuantityString(int i)
        {
            string toReturn = "";

            toReturn += ingredient.Quantities[i].Qty;
            toReturn += " ";
            if (ingredient.Quantities[i].Msmt == Ingredient.Measurements._)
            {
                toReturn += ingredient.Name;
                toReturn += "s";
            }
            else
            {
                toReturn += ingredient.Quantities[0].Msmt;
            }

            return toReturn;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Wnd_Ingredient IngredientInterface = new Wnd_Ingredient(this,ingredient);
            IngredientInterface.Show();
        }

        public void MakeChanges()
        {
            button.Content = ingredient.Name + "     :     " + getIndexQuantityString(0);
        }
    }
}
