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

namespace DataPersistance_One.Models
{
    /// <summary>
    /// Interaction logic for CreateEditEmail.xaml
    /// </summary>
    public partial class CreateEditEmail : Window
    {
        public Email email;
        public CreateEditEmail(Email e)
        {
            email = e;
            InitializeComponent();

            if (email.emailAdress != null)
            {
                tb_Address.Text = email.emailAdress;
            }

            Label work = new Label()
            { Content = "Work" };

            Label personal = new Label()
            { Content = "Personal" };

            cb_Type.Items.Add(work);
            cb_Type.Items.Add(personal);

            cb_Type.SelectedIndex = (int)e.type;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            email.emailAdress = tb_Address.Text;
            email.type = (emailType)cb_Type.SelectedIndex;
            this.Close();
        }

        private void btn_Undo_Click(object sender, RoutedEventArgs e)
        {
            if (email.emailAdress != null)
            {
                tb_Address.Text = email.emailAdress;
            }

            cb_Type.SelectedIndex = (int)email.type;
        }
        
    }
}
