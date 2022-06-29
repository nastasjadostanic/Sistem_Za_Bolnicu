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

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for ChooseRenovation.xaml
    /// </summary>
    public partial class ChooseRenovation : Window
    {
        public ChooseRenovation()
        {
            InitializeComponent();
        }

        private void Button_Click_Regular(object sender, RoutedEventArgs e)
        {
           Model.RenovationDateAndTime win = new Model.RenovationDateAndTime();
           win.Show();
        }

        private void Button_Click_Separate(object sender, RoutedEventArgs e)
        {
            Model.SeperateRenovation win = new Model.SeperateRenovation();
            win.Show();
        }

        private void Button_Click_Merge(object sender, RoutedEventArgs e)
        {
            Model.MergeRenovation win = new Model.MergeRenovation();
            win.Show();
        }
    }
}
