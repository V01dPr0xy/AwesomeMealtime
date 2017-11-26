using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AwesomeMealtime.Models;
using System.Windows;

namespace AwesomeMealtime.UI_Interface_Items
{
    class RecipeBTN
    {
        public Recipe recipe;
        public Button button;


        public RecipeBTN(Recipe r)
        {
            recipe = r;

            button = new Button()
            {
                Content = recipe.Name
            };
            button.Click += Click;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            string toPrint = "";

            MessageBox.Show(toPrint, recipe.Name);
        }
    }
}
