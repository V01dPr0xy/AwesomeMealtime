using AwesomeMealtime.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AwesomeMealtime.Models.Ingredient;

namespace AwesomeMealtime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Ingredient ing1_ = new Ingredient
            {
                Name = "Carrot",
                Quantities = new List<Quantity>() { new Quantity() { Qty = 5.0d, Msmt = Measurements._ } },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2020, month:7, day:19),
                        Dates = new List<Quantity>() { new Quantity() { Qty = 5.0d, Msmt = Measurements._ } }
                    }
                }
            };

        }
    }
}
