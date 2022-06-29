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
    /// <summary>
    /// Interaction logic for RemoveExeminationPage.xaml
    /// </summary>
    public partial class RemoveExeminationPage : Window
    {
        public RemoveExeminationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ee = new Examination();
            ee.Remove(RemoveID.Text);
            RemoveID.Text = "";
            if (ee.Remove(RemoveID.Text) == false) { Err.Content = "No match for ID"; }
        }
    }
}
