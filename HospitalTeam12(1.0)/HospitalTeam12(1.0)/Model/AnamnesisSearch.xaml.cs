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
    /// Interaction logic for AnamnesisSearch.xaml
    /// </summary>
    public partial class AnamnesisSearch : Window
    {
        public ArrayList res { get; set; }
        public AnamnesisSearch()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var mr = new MedicalRecord();
            res = mr.GetAnamnesises(recipeID.Text);
            dataGridAnamnesis.ItemsSource = res;
        }
    }
}
