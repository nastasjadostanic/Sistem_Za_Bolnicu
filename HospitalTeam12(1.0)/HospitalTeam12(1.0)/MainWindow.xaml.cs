using System;
using System.IO;
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
using System.Collections;

using MainPackage.Model;

namespace HospitalTeam12
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            File.CreateText("TEMP2.txt").Close();
            File.CreateText("TEMP.txt").Close();
            File.CreateText("TEMP3.txt").Close();
        }



        private void Click_Doctor(object sender, RoutedEventArgs e)
        {
            Model.DoctorPage win = new Model.DoctorPage();
            win.Show();
        }

        private void Click_Manager(object sender, RoutedEventArgs e)
        {
            Model.ManagerPage win = new Model.ManagerPage();
            win.Show();
        }

        private void Click_Secretar(object sender, RoutedEventArgs e)
        {
            Model.SecretarPage win = new Model.SecretarPage();
            win.Show();
        }

        private void Click_Patient(object sender, RoutedEventArgs e)
        {
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");
          
            if (pp.isDisabled == false)
            {
                Model.PatientPage win = new Model.PatientPage();
                win.Show();
            }
            else MessageBox.Show("Your account is susspended due to too many canceled examinations in short period of time", "", MessageBoxButton.OK, MessageBoxImage.Error); ;
        }
    }
}
    