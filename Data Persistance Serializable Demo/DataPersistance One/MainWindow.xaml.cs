using System;
using System.Collections.Generic;
using System.Windows;
using DataPersistance_One.Models;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataPersistance_One
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> Contacts;
        string CurrentFile;
        public MainWindow()
        {
            InitializeComponent();

            Contacts = new List<Contact>();

            Closing += OnWindowClosing; //don't remove this
        }
        private void AddContact(Contact c)
        {
            Contacts.Add(c);
            UC_Contact usercontrol = new UC_Contact(c);
            tryIt.Children.Add(usercontrol);
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void RefreshContactList()
        {
            tryIt.Children.Clear();
            foreach(Contact c in Contacts)
            {
                UC_Contact usercontrol = new UC_Contact(c);
                tryIt.Children.Add(usercontrol);
            }
        }

        private void btn_NewContact_Click(object sender, RoutedEventArgs e)
        {
            CreateEditContact newContact = new CreateEditContact(new Contact());
            newContact.ShowDialog();

            AddContact(newContact.contact);
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            RemoveContactDialog remove = new RemoveContactDialog(Contacts, this);
            remove.ShowDialog();

            RefreshContactList();
        }

        public void RemoveContactAt(int i)
        {
            if(i >= 0 && i < Contacts.Count)
                Contacts.RemoveAt(i);
        }

        private string SfilePicker()
        {
            string toReturn = "";
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog()
            {
                DefaultExt = ".bin",
                Filter = "Binary Files (*.bin)|*.bin|All files (*.*)|*.*"
            };

            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            {
                toReturn = dlg.FileName;
            }
            return toReturn;
        }
        private string OfilePicker()
        {
            string toReturn = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = ".bin",
                Filter = "Binary Files (*.bin)|*.bin|All files (*.*)|*.*"
            };

            Nullable<bool> result = dlg.ShowDialog();            
            if (result == true)
            {
                toReturn = dlg.FileName;
            }
            return toReturn;
        }

        private void AppOpen_Click(object sender, RoutedEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            string file = OfilePicker();
            if (file == "")
                return;

            Stream stream = new FileStream(file,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            List<Contact> interList = new List<Contact>();
            while (stream.Position < stream.Length)
            {
                Contact obj = (Contact)formatter.Deserialize(stream);
                interList.Add(obj);
            }
            stream.Close();

            Contacts = interList;
            RefreshContactList();

            CurrentFile = file;
        }

        private void AppSave_Click(object sender, RoutedEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();

            string file;

            if (CurrentFile == null)
            {
                file = SfilePicker();
                if (file == "")
                    return;
                CurrentFile = file;
            }
            else
            {
                file = CurrentFile;
            }

            Stream stream = new FileStream(file,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);

            foreach (Contact c in Contacts)
            {
                formatter.Serialize(stream, c);
            }
            stream.Close();

            CurrentFile = file;
        }

        private void AppSaveAs_Click(object sender, RoutedEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();

            string file = SfilePicker();
            if (file == "")
                return;

            Stream stream = new FileStream(file,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);

            foreach (Contact c in Contacts)
            {
                formatter.Serialize(stream, c);
            }
            stream.Close();

            CurrentFile = file;
        }
    }
}
