using MainPackage.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalTeam12.Model
{
   public class ExamBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public  string ID { get; set; }
    public string ROOM{ get; set; }
    public string FLOOR { get; set; }
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

        public ExamBinding() {
        }
        public ExamBinding(string id, string room, string floor, string patientFirstName, string patientLastName,string patientHRN, string patientJMBG, string doctorFirstName, string doctorLastName, int day, int mnth, int year, int hour, int minute) 
        {
            ID = id;
            ROOM = room;
            FLOOR = floor;
            PATIENTFirstName = patientFirstName;
            PATIENTLastName = patientLastName;
            PATIENTJMBG = patientJMBG;
            PATIENTHRN = patientHRN;
            DOCTORFirstName = doctorFirstName;
            DOCTORLastName = doctorLastName;
            DAY = day;
            MNTH = mnth;
            YEAR = year;
            HOUR = hour;
            MINUTE = minute;
        
        }
    }
}
