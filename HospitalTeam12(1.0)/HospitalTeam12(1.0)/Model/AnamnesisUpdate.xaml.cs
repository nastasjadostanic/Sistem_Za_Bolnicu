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
    /// Interaction logic for AnamnesisUpdate.xaml
    /// </summary>
    public partial class AnamnesisUpdate : Window
    {
        public AnamnesisUpdate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var m = new MedicalRecord();
            var a = new Anamnesis();
            a.SetHRN(hrn.Text);
            a.SetName(naziv.Text);
            a.SetResults(rezultati.Text);
            a.SetSymptoms(simptomi.Text);
            a.dt = DateTime.Now.ToString();

            m.UpdateAnamnesis(a);
        }
    }
}
