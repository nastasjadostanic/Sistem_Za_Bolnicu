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
    /// Interaction logic for MedicineHospitalInstructionUpdate.xaml
    /// </summary>
    public partial class MedicineHospitalInstructionUpdate : Window
    {
        public MedicineHospitalInstructionUpdate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var i = new Instruction();
            i.ID = id.Text;
            i.endTime = DatePicker.Text;

            var ii = new Instruction();
            ii.updateHospitalInstructionByDoctor(i);
        }
    }
}
