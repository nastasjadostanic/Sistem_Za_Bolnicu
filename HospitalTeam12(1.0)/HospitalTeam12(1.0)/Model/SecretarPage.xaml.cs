using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainPackage.Model;

namespace HospitalTeam12.Model
{

    public partial class SecretarPage : Window
    {
        public SecretarPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            Model.SearchThePatient win = new Model.SearchThePatient();
            win.Show();

        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            Model.CreateThePatient win = new Model.CreateThePatient();
            win.Show();

        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Model.EditThePatient win = new Model.EditThePatient();
            win.Show();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Model.DeleteThePatient win = new Model.DeleteThePatient();
            win.Show();
        }
    }
}
