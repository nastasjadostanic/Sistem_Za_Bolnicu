using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalTeam12.Model
{
   public class NotificationBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
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



    }
}
