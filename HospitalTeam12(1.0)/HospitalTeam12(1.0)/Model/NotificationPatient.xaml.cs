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
using System.Threading.Tasks;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for NotificationPatient.xaml
    /// </summary>
    public partial class NotificationPatient : Window
    {
        public ObservableCollection<NotificationBinding> Notifications { get; set; }
        public ObservableCollection<NotificationBinding> Notifications2 { get; set; }
        public NotificationPatient()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");
            string timeNow= DateTime.Now.ToString();
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
            hour= int.Parse(thirdSplit[0]);
            minute = int.Parse(thirdSplit[1]);

            if (firstSplit[2] == "PM")  hour += 12;

            Notifications = new ObservableCollection<NotificationBinding>();
            Notifications2 = new ObservableCollection<NotificationBinding>();
            string[] tmp = File.ReadAllLines("NotificationsPatient.txt");
            for (int i = 0; i < tmp.Length; i++)
            {
                
                string[] words = tmp[i].Split();

                if (words[4]==pp.user.Jmbg)
                    Notifications.Add(new NotificationBinding { ID = words[0], DESCRIPTION = words[1], PATIENTFirstName = words[2], PATIENTLastName = words[3],  PATIENTJMBG = words[4], PATIENTHRN = words[5], DOCTORFirstName = words[6], DOCTORLastName = words[7], DAY = int.Parse(words[8]), MNTH = int.Parse(words[9]), YEAR = int.Parse(words[10]), HOUR = int.Parse(words[11]), MINUTE = int.Parse(words[12]) });

                if (words[4] == pp.user.Jmbg && day == int.Parse(words[8]) && mnth == int.Parse(words[9]) && year == int.Parse(words[10]) && ((hour == int.Parse(words[11]) - 1 && minute >= int.Parse(words[12])) || (hour == int.Parse(words[11])  && minute <= int.Parse(words[12]))))
                    Notifications2.Add(new NotificationBinding { ID = words[0], DESCRIPTION = words[1], PATIENTFirstName = words[2], PATIENTLastName = words[3], PATIENTJMBG = words[4], PATIENTHRN = words[5], DOCTORFirstName = words[6], DOCTORLastName = words[7], DAY = int.Parse(words[8]), MNTH = int.Parse(words[9]), YEAR = int.Parse(words[10]), HOUR = int.Parse(words[11]), MINUTE = int.Parse(words[12]) });
            }




        }
    }
}
