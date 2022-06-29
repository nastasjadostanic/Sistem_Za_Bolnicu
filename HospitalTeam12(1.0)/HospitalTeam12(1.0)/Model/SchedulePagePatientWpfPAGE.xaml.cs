using MainPackage.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for SchedulePagePatientWpfPAGE.xaml
    /// </summary>
    public partial class SchedulePagePatientWpfPAGE : Page
    {
        private int colNum = 0;
        const int TIME = 3;


        Doctor d = new Doctor();

        public SchedulePagePatientWpfPAGE()
        
        {
                int numberOfDoctors = 0;
                string[] tmp = d.getAllRegularDoctors(ref numberOfDoctors);
                for (int i = 0; i < numberOfDoctors; i++)
                {
                    string[] words = tmp[i].Split();
                    InitializeComponent();
                    Doctors.Items.Add(newItem: words[0] + " " + words[1]);
                }

                this.DataContext = this;

                ExamBindings = new ObservableCollection<ExamBinding>();
                string[] ttt = File.ReadAllLines("TEMP.txt");
                int m = 0;
                foreach (string s in ttt)
                {
                    string[] words = ttt[m].Split();


                    ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4], PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });
                    // File.AppendAllText("bbb.txt", ExamBindings[0].ID + "\n");
                    m++;
                }


        }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Patient pp = new Patient();
                pp = pp.SearchPatientByJMBG("123456789");

                Examination ee = new Examination();

                int numberOfDoctors = 0;
                string[] tmp = d.getAllRegularDoctors(ref numberOfDoctors);


                for (int i = 0; i < numberOfDoctors; i++)
                {
                    string[] words = tmp[i].Split();
                    if (Doctors.Text == words[0] + " " + words[1])
                    {
                        d = d.SearchDoctorByNameAndLastName(words[0] + " " + words[1]);



                    }

                }

                int counter = 0;


                string[] termini = ee.schedulePriortyDoctor(d,/*this.pp*/pp, int.Parse(day.Text), int.Parse(mounth.Text), int.Parse(year.Text), int.Parse(hour.Text), int.Parse(minutes.Text), int.Parse(day2.Text), int.Parse(mounth2.Text), int.Parse(year2.Text), int.Parse(hour2.Text), int.Parse(minutes2.Text), ref counter);



                if (counter == 0)
                { //ako su zauzeti prvi trazeni racuna +-3 dana
                    int cnt1 = 0;
                    int cnt2 = 0;

                    File.AppendAllText("bbb.txt", d.user.FirstName + " " + d.user.LastName + " " + pp.user.FirstName + " " + pp.user.LastName + " " + (int.Parse(day.Text) - 3).ToString());

                    termini = ee.schedulePriortyDoctor(d,/*this.pp*/pp, int.Parse(day.Text) - 3, int.Parse(mounth.Text), int.Parse(year.Text), int.Parse(hour.Text), int.Parse(minutes.Text), int.Parse(day2.Text) - 3, int.Parse(mounth2.Text), int.Parse(year2.Text), int.Parse(hour2.Text), int.Parse(minutes2.Text), ref cnt1);
                    string[] termini2 = ee.schedulePriortyDoctor(d,/*this.pp*/pp, int.Parse(day.Text) + 3, int.Parse(mounth.Text), int.Parse(year.Text), int.Parse(hour.Text), int.Parse(minutes.Text), int.Parse(day2.Text) + 3, int.Parse(mounth2.Text), int.Parse(year2.Text), int.Parse(hour2.Text), int.Parse(minutes2.Text), ref cnt2);
                    if (cnt1 == 0 && cnt2 == 0)
                    {
                        //korisnik mora ponovo da unese datum jer nema nigde u pribliznom vremenu slobodnih termina
                        //File.AppendAllText("bbb.txt", cnt1.ToString() + cnt2.ToString());
                    }
                    else
                    {
                        //ispisuje alternativne termine uz poruku da su svi trazeni zauzeti
                        File.CreateText("TEMP.txt").Close();
                        File.AppendAllText("bbb.txt", cnt1.ToString() + cnt2.ToString());

                        for (int j = 0; j < cnt1; j++)
                        {
                            string[] words = termini[j].Split();

                            // ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4],  PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });



                            File.AppendAllText("TEMP.txt", words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + words[5] + " " + words[6] + " " + words[7] + " " + words[8] + " " + words[9] + " " + words[10] + " " + words[11] + " " + words[12] + " " + words[13] + "\n");
                        }
                        for (int j = 0; j < cnt2; j++)
                        {
                            string[] words = termini2[j].Split();

                            // ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4],  PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });



                            File.AppendAllText("TEMP.txt", words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + words[5] + " " + words[6] + " " + words[7] + " " + words[8] + " " + words[9] + " " + words[10] + " " + words[11] + " " + words[12] + " " + words[13] + "\n");
                        }
                    }


                }


                else
                {

                    //ispisi termine
                    //printf termini
                    File.CreateText("TEMP.txt").Close();


                    for (int j = 0; j < counter; j++)
                    {
                        string[] words = termini[j].Split();

                        // ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4],  PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });



                        File.AppendAllText("TEMP.txt", words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + words[5] + " " + words[6] + " " + words[7] + " " + words[8] + " " + words[9] + " " + words[10] + " " + words[11] + " " + words[12] + " " + words[13] + "\n");
                    }


                }

            

        

            // this.Hide();
            // Model.SchedulePagePatient Win = new Model.SchedulePagePatient();
            // Win.Show();

        }
        public System.Collections.ObjectModel.ObservableCollection<ExamBinding> ExamBindings
        {

            get;
            set;
        }


        private void Doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private Doctor Petlja(Doctor d, Patient pp, Examination ee, ref string[] tmp2, ref string[] termini, ref int cnt)
        {
            if (cnt == 0)
            {// nema slobodnih termina i racuna se alternativa
                if (tmp2.Length > 0)
                {
                    string[] words = tmp2[0].Split();
                    d = d.SearchDoctorByNameAndLastName(words[0] + " " + words[1]);
                    tmp2 = tmp2.Where(val => val != (d.user.FirstName + " " + d.user.LastName + " " + d.user.DateOfBirth + " " + d.user.Jmbg + " " + d.user.Email + " " + d.user.Phone + " " + d.user.Address + " " + d.user.Username + " " + d.user.Password + " " + d.specialization)).ToArray();
                    termini = ee.schedulePriortyDoctor(d,/*this.pp*/pp, int.Parse(day.Text), int.Parse(mounth.Text), int.Parse(year.Text), int.Parse(hour.Text), int.Parse(minutes.Text), int.Parse(day2.Text), int.Parse(mounth2.Text), int.Parse(year2.Text), int.Parse(hour2.Text), int.Parse(minutes2.Text), ref cnt);
                    if (cnt == 0)
                    {
                        Petlja(d, pp, ee, ref tmp2, ref termini, ref cnt);
                    }
                }
                else
                {
                    //nema vise doktora za taj period, error msg i vrati da ponovo bira datum
                }
            }
            else
            {
                return d;
            }
            return d;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");

            Examination ee = new Examination();
            int numberOfDoctors = 0;
            string[] tmp = d.getAllRegularDoctors(ref numberOfDoctors);
            string[] tmp2 = new string[numberOfDoctors];
            for (int i = 0; i < numberOfDoctors; i++)
            {
                tmp2[i] = tmp[i];
            }



            for (int i = 0; i < numberOfDoctors; i++)
            {
                string[] words = tmp[i].Split();
                if (Doctors.Text == words[0] + " " + words[1])
                {
                    d = d.SearchDoctorByNameAndLastName(words[0] + " " + words[1]);



                }

            }

            int cnt = 0;
            tmp2 = tmp2.Where(val => val != (d.user.FirstName + " " + d.user.LastName + " " + d.user.DateOfBirth + " " + d.user.Jmbg + " " + d.user.Email + " " + d.user.Phone + " " + d.user.Address + " " + d.user.Username + " " + d.user.Password + " " + d.specialization)).ToArray();
            string[] termini = ee.schedulePriortyDoctor(d,/*this.pp*/pp, int.Parse(day.Text), int.Parse(mounth.Text), int.Parse(year.Text), int.Parse(hour.Text), int.Parse(minutes.Text), int.Parse(day2.Text), int.Parse(mounth2.Text), int.Parse(year2.Text), int.Parse(hour2.Text), int.Parse(minutes2.Text), ref cnt);




            d = Petlja(d, pp, ee, ref tmp2, ref termini, ref cnt);
            //imas doktora, niz termina, koliko termina
            //ispisi termini jer je tu niz termina



            File.CreateText("TEMP.txt").Close();


            for (int j = 0; j < cnt; j++)
            {
                string[] words = termini[j].Split();

                // ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4],  PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });



                File.AppendAllText("TEMP.txt", words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + words[5] + " " + words[6] + " " + words[7] + " " + words[8] + " " + words[9] + " " + words[10] + " " + words[11] + " " + words[12] + " " + words[13] + "\n");
            }

           // this.Hide();
           // Model.SchedulePagePatient Win = new Model.SchedulePagePatient();
           // Win.Show();
        }
        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 14)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        private void dataGridExamination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //from selected call schedule

            Examination ee = new Examination();
            ExamBinding exb = (ExamBinding)dataGridExamination0.SelectedItem;
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
            // File.AppendAllText("bbb.txt",ee.Id + " " +ee.doctor.room.Number + " " +ee.doctor.room.Floor + " " +ee.patient.user.FirstName + " " +ee.patient.user.LastName + " " +ee.patient.HealthRecordNumber + " " +ee.patient.user.Jmbg + " " +ee.doctor.user.FirstName + " " +ee.doctor.user.LastName + " " +ee.day + " " +ee.mnth + " " +ee.year + " " +ee.hour + " " +ee.min+"\n");//KINESKA SLOVA
            //File.AppendAllText("bbb.txt", ee.Id + " " + ee.doctor.user.FirstName + " " + ee.patient.user.FirstName + " " + ee.day);
            ee.ScheduleP(ee);
            // ee.schedulePat(rnd.Next(0, 100).ToString(), d.room.Number, d.room.Floor, exb.PATIENTFirstName, exb.PATIENTLastName, exb.PATIENTHRN, exb.PATIENTJMBG, exb.DOCTORFirstName, exb.DOCTORLastName, exb.DAY, exb.MNTH, exb.YEAR, exb.HOUR, exb.MINUTE);
        }

        private void dataGridExamination0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
