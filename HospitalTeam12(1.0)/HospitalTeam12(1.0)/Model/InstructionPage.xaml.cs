using MainPackage.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for InstructionPage.xaml
    /// </summary>
    public partial class InstructionPage : Window
    {
        public InstructionPage()
        {
            Instruction insturction = new Instruction() ;
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            InitializeComponent();
            int numberOfInstructions = 0;
            string[] allInstructions= insturction.getAllInstructions(patient,ref numberOfInstructions);
            for (int i = 0; i < numberOfInstructions; i++)
            {
                string[] words = allInstructions[i].Split();
                Ins.Items.Add(newItem:words[0] +" " + words[3] + " " + words[4] + " " + words[5] + " " + words[6] + " " + words[7] + " " + words[8]);
            }


            this.DataContext = this;

            fillGrid();




        }

        public System.Collections.ObjectModel.ObservableCollection<ExamBinding> ExamBindings
        {

            get;
            set;
        }

        public void stariKrsOdFunkcije2() 
        {
            Examination ee = new Examination();
            ExamBinding exb = (ExamBinding)dataGridExamination.SelectedItem;
            Random rnd = new Random();
            Doctor d = new Doctor();
            d = d.SearchDoctorByNameAndLastName(exb.DOCTORFirstName + " " + exb.DOCTORLastName);
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");

            ee.patient = pp;
            ee.doctor = d;
            ee.Id = rnd.Next(0, 100).ToString();

            ee.day = exb.DAY;
            ee.mnth = exb.MNTH;
            ee.year = exb.YEAR;
            ee.hour = exb.HOUR;
            ee.min = exb.MINUTE;
            ee.ScheduleP(ee);
        }//ova funkcija je iz KT3 pa zato nije bas(nimalo) po clean codu

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            Instruction instrction = new Instruction();
            stariKrsOdFunkcije2();
            string[] words = Ins.Text.Split();
            instrction.deleteInstruction(instrction.searchByID(words[0]));


            this.Hide();
            Model.InstructionPage win = new Model.InstructionPage();
            win.Show();
        }

        private void Ins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void fillGrid()
        {
            ExamBindings = new ObservableCollection<ExamBinding>();
            string[] tmp = File.ReadAllLines("TEMP3.txt");
            int m = 0;
            foreach (string s in tmp)
            {
                string[] words = tmp[m].Split();


                ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4], PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });
                m++;
            }
        }

        public void stariKrsOdFunkcije(Doctor[] doctors,Patient patient,int[] currentTime, int i, Examination examination, string[] words)
        {
            int numberOfTermini = 0;
             string[] termini = examination.schedulePriortyDoctor(doctors[i], patient, currentTime[0], currentTime[1], currentTime[2], currentTime[3], 0, int.Parse(words[2]), int.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]), int.Parse(words[6]), ref numberOfTermini);
           



            File.CreateText("TEMP3.txt").Close();


            for (int j = 0; j < numberOfTermini; j++)
            {
                string[] words2 = termini[j].Split();




                File.AppendAllText("TEMP3.txt", words2[0] + " " + words2[1] + " " + words2[2] + " " + words2[3] + " " + words2[4] + " " + words2[5] + " " + words2[6] + " " + words2[7] + " " + words2[8] + " " + words2[9] + " " + words2[10] + " " + words2[11] + " " + words2[12] + " " + words2[13] + "\n");
            }
        } //ova funkcija je iz KT3 pa zato nije bas(nimalo) po clean codu
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] words = Ins.Text.Split();
            int numberOfDoctors = 0;
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            Examination examination = new Examination();
            Doctor dr = new Doctor();
            Doctor[] doctors = dr.SearchDoctorsBySpecializastion(words[1], ref numberOfDoctors);
            int[] currentTime = dr.CurrentTimeToInt();
            for (int i = 0; i < numberOfDoctors; i++)
            {
                stariKrsOdFunkcije(doctors, patient, currentTime, i,examination, words);

            }

            this.Hide();
            Model.InstructionPage win = new Model.InstructionPage();
            win.Show();
        }
    }
}
