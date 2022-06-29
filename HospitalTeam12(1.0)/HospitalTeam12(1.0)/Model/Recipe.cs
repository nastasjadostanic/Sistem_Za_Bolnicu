using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MainPackage.Model
{
    class Recipe
    {
        public String name { get; set; }
        public String quantity { get; set; }
        public String instructions { get; set; }
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

        public void SetQuantity(String quantity)
        {
            this.quantity = quantity;
        }

        public String GetQuantity()
        {
            return quantity;
        }

        public void SetInstructions(String instructions)
        {
            this.instructions = instructions;
        }

        public String GetInstructions()
        {
            return instructions;
        }
    }
}
