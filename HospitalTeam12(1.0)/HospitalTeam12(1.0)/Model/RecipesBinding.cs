using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HospitalTeam12.Model
{
    public class RecipesBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public String name { get; set; }
        public String quantity { get; set; }
        public String instructions { get; set; }
        public String hrn { get; set; }
        public String dt { get; set; }
    }
}
