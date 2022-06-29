using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class CreateRoomPage : Window
    {
        public CreateRoomPage()
        {
            InitializeComponent();
            TYPE.Items.Add("Office");
            TYPE.Items.Add("OperationRoom");
            TYPE.Items.Add("HospitalRoom");
        }

        private void Button_Click_Create (object sender, RoutedEventArgs e)
        {
            Room r = new Room();
            r.Create(r.GenerateID().ToString() , NUMBER.Text, FLOOR.Text, DESCRIPTION.Text, TYPE.Text);
            
            NUMBER.Text = "";
            FLOOR.Text = "";
            DESCRIPTION.Text = "";
            TYPE.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
