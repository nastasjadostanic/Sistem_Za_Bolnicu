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
using System.Collections;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for SurgerySearch.xaml
    /// </summary>
    public partial class SurgerySearch : Window
    {
        public String id { get; set; }
        public ArrayList rez { get; set; }
        public SurgerySearch()
        {
            InitializeComponent();

            this.DataContext = this;

        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var s = new Surgery();
            rez = s.ViewSurgery(surgeryID.Text);
            dataGridSurgery.ItemsSource = rez;
        }

    }
}
