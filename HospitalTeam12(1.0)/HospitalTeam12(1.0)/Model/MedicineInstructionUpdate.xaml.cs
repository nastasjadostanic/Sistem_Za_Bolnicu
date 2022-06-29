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
    /// Interaction logic for MedicineInstructionUpdate.xaml
    /// </summary>
    public partial class MedicineInstructionUpdate : Window
    {
        public MedicineInstructionUpdate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var i = new Instruction();
            i.ID = id.Text;
            i.endTime = DatePicker.Text;

            var ii = new Instruction();
            ii.updateInstructionByDoctor(i);
        }
    }
}
