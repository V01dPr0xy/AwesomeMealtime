using AwesomeMealtime.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AwesomeMealtime.UI_Interface_Items
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        Recipe recipe = new Recipe();
        public RecipeWindow()
        {
            InitializeComponent();
        }

        private void RemoveIngredient(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Warning_Checked(object sender, RoutedEventArgs e)
        {
            recipe.Warning = true;
        }

        private void Warning_Unchecked(object sender, RoutedEventArgs e)
        {
            recipe.Warning = false;
        }

        private void AddIngredient(object sender, RoutedEventArgs e)
        {

        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            
        }
        private void AddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select a picture";
            open.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (open.ShowDialog() == true)
            {
                Img.Source = new BitmapImage(new Uri(open.FileName));
            }
        }
    }
}
