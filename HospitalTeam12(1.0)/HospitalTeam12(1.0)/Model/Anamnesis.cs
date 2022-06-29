using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MainPackage.Model
{
    class Anamnesis
    {
        public String name { get; set; }
        public String symptoms { get; set; }
        public String results { get; set; }
        public String hrn { get; set; }
        public String dt { get; set; }

        public void SetHRN(String hrn)
        {
            this.hrn = hrn;
        }

        public String GetHRN()
        {
            return hrn;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public String GetName()
        {
            return name;
        }

        public void SetSymptoms(String symptoms)
        {
            this.symptoms = symptoms;
        }

        public String GetSymptoms()
        {
            return symptoms;
        }

        public void SetResults(String results)
        {
            this.results = results;
        }

        public String GetResults()
        {
            return results;
        }
    }
}
