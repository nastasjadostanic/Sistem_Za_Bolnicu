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
    /// Interaction logic for DeleteRoomPage.xaml
    /// </summary>
    public partial class DeleteRoomPage : Window
    {
        public DeleteRoomPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var r = new Room();
            r.Delete(IDDelete.Text);
            IDDelete.Text = "";
        }
    }
}
