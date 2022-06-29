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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for ReschedulePagePatientWpfPAGE.xaml
    /// </summary>
    public partial class ReschedulePagePatientWpfPAGE : Page
    {
        public ObservableCollection<ExamBinding> ExamBindings { get; set; }
        public ObservableCollection<ExamBinding> ExamBindings2 { get; set; }

        public ReschedulePagePatientWpfPAGE()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");//rucno setovaje pacijenta jer nema login
            ExamBinding eb = new ExamBinding();
            Examination ee = new Examination();
            ExamBindings = new ObservableCollection<ExamBinding>();

            string[] tmp = ee.GetAllExamination();
            for (int i = 0; i < tmp.Length; i++)
            {
                string[] words = tmp[i].Split();

                if (pp.user.Jmbg == words[6])
                    ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4], PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });

            }

            ExamBindings2 = new ObservableCollection<ExamBinding>();
            string[] tmp2 = File.ReadAllLines("TEMP2.txt");
            for (int i = 0; i < tmp2.Length; i++)
            {
                string[] words = tmp2[i].Split();
                ExamBindings2.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4], PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });

            }

        }


        bool isAhead24(int d, int m, int y, int h, int min, int d2, int m2, int y2, int h2, int min2)
        {

            if (y > y2) return false;
            if (m > m2) return false;
            if (d > d2) return false;
            if (d == d2 && m == m2 && y == y2) return false; //da li je isti dan

            d2--;
            if (d2 == 0) { d2 = 30; m2--; if (m2 == 0) { m2 = 12; y2--; } }
            if (d == d2 && m == m2 && y == y2)
            {
                if (h > h2) return false;
                if (h == h2 && min > min2) return false;

            }








            return true;
        }


        private void Button_Click_2(object sender, RoutedEventArgs e) //search
        {
            Patient pp = new Patient();

            Doctor d = new Doctor();
            Examination ee = new Examination();
            ExamBinding exb = (ExamBinding)SearchExa.SelectedItem;
            d = d.SearchDoctorByNameAndLastName(exb.DOCTORFirstName + " " + exb.DOCTORLastName);
            pp = pp.SearchPatientByJMBG("123456789");
            //File.AppendAllText("TEMP2.txt", d.user.FirstName + " " + pp.user.FirstName);

            //provera da li je 24h pred pregled

            string timeNow = DateTime.Now.ToString();
            int day;
            int mnth;
            int year;
            int hour;
            int minute;
            string[] firstSplit = timeNow.Split();

            string[] secondSplit = firstSplit[0].Split('/');
            day = int.Parse(secondSplit[1]);
            mnth = int.Parse(secondSplit[0]);
            year = int.Parse(secondSplit[2]);

            string[] thirdSplit = firstSplit[1].Split(':');
            hour = int.Parse(thirdSplit[0]);
            minute = int.Parse(thirdSplit[1]);

            if (firstSplit[2] == "PM") hour += 12;






            int DAY = exb.DAY;
            int MNTH = exb.MNTH;
            int YEAR = exb.YEAR;
            int HOUR = exb.HOUR;
            int MINUTE = exb.MINUTE;

            if (isAhead24(day, mnth, year, hour, minute, DAY, MNTH, YEAR, HOUR, MINUTE) == true)
            {

                int DAY2 = exb.DAY;
                int MNTH2 = exb.MNTH;
                int YEAR2 = exb.YEAR;
                int HOUR2 = exb.HOUR;
                int MINUTE2 = exb.MINUTE;



                DAY--; DAY--;
                DAY2++; DAY2++;

                if (DAY == 0) { DAY = 30; MNTH--; if (MNTH == 0) { MNTH = 12; YEAR--; } }
                if (DAY == 1) { DAY = 29; MNTH--; if (MNTH == 0) { MNTH = 12; YEAR--; } }

                if (DAY2 == 29) { DAY2 = 1; MNTH2++; if (MNTH2 == 13) { MNTH2 = 1; YEAR2++; } }
                if (DAY2 == 30) { DAY2 = 2; MNTH2++; if (MNTH2 == 13) { MNTH2 = 1; YEAR2++; } }





                int cnt = 0;

                string[] termini = ee.schedulePriortyDoctor(d, pp, DAY, MNTH, YEAR, HOUR, MINUTE, DAY2, MNTH2, YEAR2, HOUR2, MINUTE2, ref cnt); //ISPRAVITI

                //termini = ee.schedulePriortyDoctor(d,/*this.pp*/pp, 3, 3, 2021, 10, 30, 2, 3, 2021, 10, 30, ref cnt);//IZ NEKOG RAZLOGA VRATI PRAZNO I CNT=0;
                /* File.AppendAllText("TEMP2.txt", DAY.ToString()+ " "+MNTH.ToString()+ " " + YEAR.ToString() + " " + HOUR.ToString() + " " +MINUTE.ToString()+ "\n" + DAY2.ToString()+ " " + MNTH2.ToString()+ " " + YEAR2.ToString() + " " + HOUR2.ToString() + " " + MINUTE2.ToString() + "\n");
                 File.AppendAllText("TEMP2.txt", d.user.FirstName + " " + d.user.LastName + " " +d.user.Jmbg + " " +d.user.Password + " " +d.user.Phone + " " +d.user.Username + " " +d.specialization +"\n");
                 File.AppendAllText("TEMP2.txt", pp.user.FirstName + " " + pp.user.LastName + " " + pp.user.Jmbg + " " + pp.user.Password + " " + pp.user.Phone + " " + pp.user.Username + "\n");
                 File.AppendAllText("TEMP2.txt", cnt + "\n");*/
                if (cnt == 0)
                {
                    //nema praznih termina da se premesti

                }
                else
                {//ima praznih termina
                    File.CreateText("TEMP2.txt").Close();


                    for (int j = 0; j < cnt; j++)
                    {
                        string[] words = termini[j].Split();





                        File.AppendAllText("TEMP2.txt", words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + words[5] + " " + words[6] + " " + words[7] + " " + words[8] + " " + words[9] + " " + words[10] + " " + words[11] + " " + words[12] + " " + words[13] + "\n");
                    }
                }

            }

            //this.Hide();
           // Model.ReschedulePagePatient Win = new Model.ReschedulePagePatient();
           // Win.Show();
        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Patient pp = new Patient();

            Doctor d = new Doctor();
            Examination ee = new Examination();
            ExamBinding exb = (ExamBinding)ScheduleExa.SelectedItem;
            ExamBinding exb2 = (ExamBinding)SearchExa.SelectedItem;
            // File.AppendAllText("bbb.txt", exb.DAY + " " + exb.DOCTORFirstName);//KINESKA SLOVA
            d = d.SearchDoctorByNameAndLastName(exb.DOCTORFirstName + " " + exb.DOCTORLastName);
            pp = pp.SearchPatientByJMBG("123456789");
            Random rnd = new Random();

            ee.patient = pp;
            ee.doctor = d;
            ee.Id = rnd.Next(0, 100).ToString();

            ee.day = exb.DAY;
            ee.mnth = exb.MNTH;
            ee.year = exb.YEAR;
            ee.hour = exb.HOUR;
            ee.min = exb.MINUTE;
            ee.Remove(exb2.ID);
            ee.ScheduleP(ee);

            // ee.schedulePat(rnd.Next(0, 100).ToString(), d.room.Number, d.room.Floor, exb.PATIENTFirstName, exb.PATIENTLastName, exb.PATIENTHRN, exb.PATIENTJMBG, exb.DOCTORFirstName, exb.DOCTORLastName, exb.DAY, exb.MNTH, exb.YEAR, exb.HOUR, exb.MINUTE);


            //iz selektovanog iz drugog datagrida uzmi podatke
            //zakazi termin sa scheduleP()
           // this.Hide();
          //  Model.ReschedulePagePatient Win = new Model.ReschedulePagePatient();
           // Win.Show();
        }

        private void ScheduleExa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
