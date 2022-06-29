using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HospitalTeam12.Model
{
    public class NotificationsPatient
    {
        public string ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string PATIENTFirstName { get; set; }
        public string PATIENTLastName { get; set; }
        public string PATIENTJMBG { get; set; }
        public string PATIENTHRN { get; set; }
        public string DOCTORFirstName { get; set; }
        public string DOCTORLastName { get; set; }
        public int DAY { get; set; }
        public int MNTH { get; set; }
        public int YEAR { get; set; }
        public int HOUR { get; set; }
        public int MINUTE { get; set; }
       
        public NotificationsPatient searchById(string Id)
        {
            string[] lines = File.ReadAllLines("NotificationsPatient.txt");
            int i = 0;
            foreach (string inst in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (Id == words[0])
                {
                    NotificationsPatient notification = new NotificationsPatient();
                    notification.ID = words[0];
                    notification.DESCRIPTION = words[1];
                    notification.PATIENTFirstName = words[2];
                    notification.PATIENTLastName = words[3];
                    notification.PATIENTJMBG = words[4];
                    notification.PATIENTHRN = words[5];
                    notification.DOCTORFirstName = words[6];
                    notification.DOCTORLastName = words[7];
                    notification.DAY = int.Parse(words[8]);
                    notification.MNTH = int.Parse(words[9]);
                    notification.YEAR = int.Parse(words[10]);
                    notification.HOUR = int.Parse(words[11]);
                    notification.MINUTE = int.Parse(words[12]);
                    return notification;
                }
            }
            return null;
        }

        public NotificationsPatient setNotification(string Id, string Description, string PatientF, string PatientL, string PatientJMBG, string PatientHRN, string DoctorF, string DoctorL, string Day, string Mnth, string Year, string Hour, string Min)
        {
            NotificationsPatient notification = new NotificationsPatient();
            notification.ID = Id;
            notification.DESCRIPTION = Description;
            notification.PATIENTFirstName = PatientF;
            notification.PATIENTLastName = PatientL;
            notification.PATIENTJMBG = PatientJMBG;
            notification.PATIENTHRN = PatientHRN;
            notification.DOCTORFirstName = DoctorF;
            notification.DOCTORLastName = DoctorL;
            notification.DAY = int.Parse(Day);
            notification.MNTH = int.Parse(Mnth);
            notification.YEAR = int.Parse(Year);
            notification.HOUR = int.Parse(Hour);
            notification.MINUTE = int.Parse(Min);

            return notification;
        }
        public void createNotification(NotificationsPatient notification)
        {
            File.AppendAllText("NotificationsPatient.txt", notification.ID + " " + notification.DESCRIPTION + " " + notification.PATIENTFirstName + " " + notification.PATIENTLastName + " " + notification.PATIENTJMBG + " " + notification.PATIENTHRN + " " + notification.DOCTORFirstName + " " + notification.DOCTORLastName + " " + notification.DAY + " " + notification.MNTH + " " + notification.YEAR + " " + notification.HOUR + " " + notification.MINUTE + "\n");
        }

        public void deleteNotification(NotificationsPatient notification)
        {
            string[] lines = File.ReadAllLines("NotificationsPatient.txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (notification.ID != words[0])
                    File.AppendAllText("NotificationsPatient2.txt", lines[i - 1] + "\n");

            }
            File.Delete("NotificationsPatient.txt");
            File.Move("NotificationsPatient2.txt", "NotificationsPatient.txt");
        }

        public void updateNotification(NotificationsPatient toDelete, NotificationsPatient toCreate)
        {
            deleteNotification(toDelete);
            createNotification(toCreate);
        }
    }
}
