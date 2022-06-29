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
    /// Interaction logic for CreateMedicinePage.xaml
    /// </summary>
    public partial class CreateMedicinePage : Window
    {
        public CreateMedicinePage()
        {
            InitializeComponent();
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            Medicine m = new Medicine();
            m.Create(m.GenerateID().ToString(), NAME.Text, DESCRIPTION.Text, INGREDIENTS.Text, ALTERNATIVE.Text, "WAITING", "StillNotWritten");

            NAME.Text = "";
            DESCRIPTION.Text = "";
            INGREDIENTS.Text = "";
            ALTERNATIVE.Text = "";
        }
    }
}
