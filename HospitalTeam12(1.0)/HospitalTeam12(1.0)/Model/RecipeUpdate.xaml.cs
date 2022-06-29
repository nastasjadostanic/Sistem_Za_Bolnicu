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
    public partial class RecipeUpdate : Window
    {
        public RecipeUpdate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var m = new MedicalRecord();
            var r = new Recipe();
            r.SetHRN(hrn.Text);
            r.SetName(naziv.Text);
            r.SetQuantity(kolicina.Text);
            r.SetInstructions(uputstvo.Text);
            r.dt = DateTime.Now.ToString();

            m.UpdateRecipe(r);
        }
    }
}
