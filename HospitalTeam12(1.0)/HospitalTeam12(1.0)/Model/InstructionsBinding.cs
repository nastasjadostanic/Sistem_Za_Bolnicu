using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalTeam12.Model
{
    public  class InstructionsBinding : INotifyPropertyChanged
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
        public string patientJMBG { get; set; }

        public string doctorJMBG { get; set; }
        public string specialization { get; set; }


        public int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

    }
}
