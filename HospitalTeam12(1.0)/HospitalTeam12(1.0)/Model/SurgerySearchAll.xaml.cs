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
    /// Interaction logic for SurgerySearchAll.xaml
    /// </summary>
    public partial class SurgerySearchAll : Window
    {
        public ArrayList rez { get; set; }
        public SurgerySearchAll()
        {
            InitializeComponent();

            this.DataContext = this;
            var s = new Surgery();
            rez = new ArrayList();
            rez = s.ViewAll();

        }
    }
}
