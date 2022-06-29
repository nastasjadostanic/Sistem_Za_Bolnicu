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
    public partial class MedicineHospitalInstructionDoctor : Window
    {
        public ArrayList res2 { get; set; }
        public ArrayList res { get; set; }
        public MedicineHospitalInstructionDoctor()
        {
            this.DataContext = this;
            InitializeComponent();

            var r = new Room();
            res = r.ViewAllHospitalRooms();
            MyCombobox1.ItemsSource = res;

            var i = new Instruction();
            res2 = i.ViewAllHospitalInstructions();
            dataGridHospitalInstruction.ItemsSource = res2;

        }

        private void Button_Write_Instruction(object sender, RoutedEventArgs e)
        {
            var i = new Instruction();
            i.ID = id.Text;
            i.patientJMBG = patientJMBG.Text;
            i.endTime = DatePicker.Text;

            if (MyCombobox1.SelectedItem != null)
            {
                var selectedValue = (Room)MyCombobox1.SelectedItem;
                i.hospitalRoomNum = selectedValue.ToString();
            }
            var ii = new Instruction();
            ii.writeHospitalInstructionByDoctor(i);

            res2 = i.ViewAllHospitalInstructions();
            dataGridHospitalInstruction.ItemsSource = res2;
        }
    }
}
