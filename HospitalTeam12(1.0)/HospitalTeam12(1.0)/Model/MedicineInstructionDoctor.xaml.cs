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
using System.Collections;

namespace HospitalTeam12.Model
{
    public partial class MedicineInstructionDoctor : Window
    {
        public ArrayList res { get; set; }
        public MedicineInstructionDoctor()
        {
            this.DataContext = this;
            InitializeComponent();

            var i = new Instruction();
            res = i.ViewAllInstructions();
            dataGridInstruction.ItemsSource = res;
            
        }

        private void Button_Write_Instruction(object sender, RoutedEventArgs e)
        {
            var i = new Instruction();
            i.ID = id.Text;
            i.patientJMBG = patientJMBG.Text;
            i.doctorJMBG = doctorJMBG.Text;
            i.specialization = "GeneralPractic";

            if (MyCombobox1.SelectedItem != null)
            {
                ComboBoxItem cbi = (ComboBoxItem)MyCombobox1.SelectedItem;
                i.specialization = cbi.Content.ToString();
            }
            i.endTime = DatePicker.Text;
            i.Explanation = expl.Text;
            var ii = new Instruction();
            ii.writeInstructionByDoctor(i);

            res = i.ViewAllInstructions();
            dataGridInstruction.ItemsSource = res;

        }
    }
}
