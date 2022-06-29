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
using HospitalTeam12.Model;

namespace HospitalTeam12.Model
{
    public partial class SurgerySchedule : Window
    {
        public SurgerySchedule()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User userP = new User();
            userP.FirstName = patient_name.Text;
            userP.LastName = patient_surname.Text;
            userP.Jmbg = patient_jmbg.Text;

            Patient patient = new Patient();
            patient.SetUser(userP);
            patient.HealthRecordNumber = health_record_num.Text;

            User userD = new User();
            userD.FirstName = doctor_name.Text;
            userD.LastName = doctor_surname.Text;

            Doctor doctor = new Doctor();
            Room room = new Room();
            room.Number = room_num.Text;
            room.Floor = floor_num.Text;
            doctor.SetUser(userD);
            doctor.SetSpecialization(spec.Text);

            Surgery s = new Surgery();
            s.Id = exam_id.Text;
            s.SetPatient(patient);
            s.SetRoom(room);
            s.doctor = doctor;
            bool isHour;
            bool isMin;
            bool isDay;
            bool isMnth;
            bool isYear;
            bool isNumber = Double.TryParse(hour_num.Text + "." + min_num.Text, out Double numericValue);
            if (isNumber == false)
            {
                error_value.Content = "Invalid value";
                return;
            }
            if (isHour = int.TryParse(hour_num.Text, out int numericValue1))
            {
                s.hour = int.Parse(hour_num.Text);
            }
            else
            {
                error_value.Content = "Invalid value";
                return;
            }
            if (isMin = int.TryParse(min_num.Text, out int numericValue2))
            {
                s.min = int.Parse(min_num.Text);
            }
            else
            {
                error_value.Content = "Invalid value";
                return;
            }
            if (isDay = int.TryParse(day_num.Text, out int numericValue3))
            {
                s.day = int.Parse(day_num.Text);
            }
            else
            {
                error_value.Content = "Invalid value";
                return;
            }
            if (isMnth = int.TryParse(mnth_num.Text, out int numericValue4))
            {
                s.mnth = int.Parse(mnth_num.Text);
            }
            else
            {
                error_value.Content = "Invalid value";
                return;
            }
            if (isYear = int.TryParse(year_num.Text, out int numericValue5))
            {
                s.year = int.Parse(year_num.Text);
            }
            else
            {
                error_value.Content = "Invalid value";
                return;
            }

            if (s.Schedule(s))
            {
                MessageLabel.Content = "Surgery successfully booked.";
            }
            else
            {
                MessageLabel.Content = "There is no free term at that time.";
            }
            room_num.Text = "";
            floor_num.Text = "";
            hour_num.Text = "";
            min_num.Text = "";
            day_num.Text = "";
            mnth_num.Text = "";
            year_num.Text = "";
            patient_name.Text = "";
            patient_surname.Text = "";
            patient_jmbg.Text = "";
            health_record_num.Text = "";
            doctor_name.Text = "";
            doctor_surname.Text = "";
            exam_id.Text = "";
        }
    }
}
