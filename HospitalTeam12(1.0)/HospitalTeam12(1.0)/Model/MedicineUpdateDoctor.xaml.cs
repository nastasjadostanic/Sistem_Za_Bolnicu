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
    /// Interaction logic for MedicineUpdateDoctor.xaml
    /// </summary>
    public partial class MedicineUpdateDoctor : Window
    {
        public MedicineUpdateDoctor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var m = new Medicine();
            bool verified = false;
            if(verifyCheck.IsChecked==true)
            {
                verified = true;
            }
            else
            {
                verified = false;
            }
            String status = "";
            if(verified==true)
            {
                status = "CONFIRMED";
            }
            else
            {
                status = "WAITING";
            }
            m.UpdateByDoctor(id.Text, name.Text, desc.Text, ingr.Text, alt.Text, status, expl.Text);
        }
    }
}
