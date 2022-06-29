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
    /// Interaction logic for NotificationPatientWpfPAGE.xaml
    /// </summary>
    public partial class NotificationPatientWpfPAGE : Page
    {
        public ObservableCollection<NotificationBinding> Notifications { get; set; }
        public ObservableCollection<NotificationBinding> Notifications2 { get; set; }
        public NotificationPatientWpfPAGE()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");
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

            Notifications = new ObservableCollection<NotificationBinding>();
            Notifications2 = new ObservableCollection<NotificationBinding>();
            string[] tmp = File.ReadAllLines("NotificationsPatient.txt");
            for (int i = 0; i < tmp.Length; i++)
            {

                string[] words = tmp[i].Split();

                if (words[4] == pp.user.Jmbg)
                    Notifications.Add(new NotificationBinding { ID = words[0], DESCRIPTION = words[1], PATIENTFirstName = words[2], PATIENTLastName = words[3], PATIENTJMBG = words[4], PATIENTHRN = words[5], DOCTORFirstName = words[6], DOCTORLastName = words[7], DAY = int.Parse(words[8]), MNTH = int.Parse(words[9]), YEAR = int.Parse(words[10]), HOUR = int.Parse(words[11]), MINUTE = int.Parse(words[12]) });

                if (words[4] == pp.user.Jmbg && day == int.Parse(words[8]) && mnth == int.Parse(words[9]) && year == int.Parse(words[10]) && ((hour == int.Parse(words[11]) - 1 && minute >= int.Parse(words[12])) || (hour == int.Parse(words[11]) && minute <= int.Parse(words[12]))))
                    Notifications2.Add(new NotificationBinding { ID = words[0], DESCRIPTION = words[1], PATIENTFirstName = words[2], PATIENTLastName = words[3], PATIENTJMBG = words[4], PATIENTHRN = words[5], DOCTORFirstName = words[6], DOCTORLastName = words[7], DAY = int.Parse(words[8]), MNTH = int.Parse(words[9]), YEAR = int.Parse(words[10]), HOUR = int.Parse(words[11]), MINUTE = int.Parse(words[12]) });
            }
        }

        private void Nitify2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nitify_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            Random rnd = new Random();
            NotificationsPatient notification = new NotificationsPatient();
            notification = notification.setNotification(rnd.Next(1000, 10000).ToString(), Description.Text, patient.user.FirstName, patient.user.LastName, patient.user.Jmbg, patient.HealthRecordNumber, "PRIVATE_ALARM", "PRIVATE_ALARM", Day.Text, Mounth.Text, Year.Text, Hour.Text, Minutes.Text);
            notification.createNotification(notification);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            NotificationBinding nb = new NotificationBinding();
            nb = (NotificationBinding)Nitify.SelectedItem;
            NotificationsPatient notificationToDelete = new NotificationsPatient();
            NotificationsPatient notificationToCreate = new NotificationsPatient();
            notificationToDelete = notificationToDelete.searchById(nb.ID);
            notificationToCreate = notificationToCreate.setNotification(nb.ID, Description.Text, patient.user.FirstName, patient.user.LastName, patient.user.Jmbg, patient.HealthRecordNumber, "PRIVATE_ALARM", "PRIVATE_ALARM", Day.Text, Mounth.Text, Year.Text, Hour.Text, Minutes.Text);
            notificationToCreate.updateNotification(notificationToDelete, notificationToCreate);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
           
            NotificationBinding nb = new NotificationBinding();
            nb = (NotificationBinding)Nitify.SelectedItem;
            NotificationsPatient notificationToDelete = new NotificationsPatient();
            notificationToDelete = notificationToDelete.searchById(nb.ID);
            notificationToDelete.deleteNotification(notificationToDelete);
        }

        
    }
}
