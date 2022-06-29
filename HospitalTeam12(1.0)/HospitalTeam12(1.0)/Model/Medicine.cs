using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Collections;
using MainPackage.Model;
using System.Collections;

namespace HospitalTeam12.Model
{
    public class Medicine
    {
        public string[] ReadLinesMedicines()
        {
            string[] lines = File.ReadAllLines("Medicines.txt");
            return lines;
        }
        public Medicine SearchByID(string ID)
        {
            string[] lines = ReadLinesMedicines();
            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (ID == words[0])
                {
                    var m = new Medicine();
                    m.Id = words[0];
                    m.Name = words[1];
                    m.Description = words[2];
                    m.Ingredients = words[3];
                    m.AlternativeMedicine = words[4];
                    m.Explanation = words[5];

                    return m;
                }


            }
            return null;
        }
        public Medicine Search(string Input)
        {
            string[] lines = File.ReadAllLines("Medicines.txt");
            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (Input == words[0] || Input== words[1] || Input==words[2] || Input == words[3] || Input == words[4] || Input == words[5] || Input == words[6]  )
                {
                    var m = new Medicine();
                    m.Id = words[0];
                    m.Name = words[1];
                    m.Description = words[2];
                    m.Ingredients = words[3];
                    m.AlternativeMedicine = words[4];
                    m.Status = words[5];
                    m.Explanation = words[6];

                    return m;
                }

            }
            return null;
        }
        public string[] GetAll()
        {
            string[] lines = ReadLinesMedicines();
            return lines;

        }
        public Boolean Create(string id, string name, string description,string ingredients, string alternativeMedicine, string Status, string Explanation)
        {
            string[] lines = File.ReadAllLines("Medicines.txt");
            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (id == words[0])
                    return false;
            }
            File.AppendAllText("Medicines.txt", id + " " + name + " " + description + " " + ingredients + " " + alternativeMedicine + " " + "WAITING" + " " + "StillNotWritten" + "\n");
            return true;

        }
        public Boolean Update(string ID, string Name, string Description, string Ingredients, string AlternativeMedicine, string Status, string Explanation)
        {
            if (SearchByID(ID) != null)
            {
                Delete(ID);
                Create(ID, Name, Description, Ingredients, AlternativeMedicine, Status, "StillNotWritten");
            }

            return false;
        }
        public Boolean Delete(string ID)
        {
            string[] lines = File.ReadAllLines("Medicines.txt");

            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (ID != words[0])
                    File.AppendAllText("Medicines2.txt", lines[i - 1] + "\n");

            }

            File.Delete("Medicines.txt");
            File.Move("Medicines2.txt", "Medicines.txt");
            return true;
        }
        
        public int GenerateID()
        {
            string[] lines = File.ReadAllLines("Medicines.txt");

            int i = 0;
            int max = 0;
            foreach (string room in lines)
            {
                string[] words = lines[i].Split();

                if (int.Parse(words[0]) > max)
                    max = int.Parse(words[0]);
                i++;
            }
            max++;
            return max;
        }


        // feature-i za doktora =============================================================

        public Boolean CreateByDoctor(string id, string name, string description, string ingredients, string alternativeMedicine, String Status, string Explanation)
        {
            string[] lines = File.ReadAllLines("Medicines.txt");
            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (id == words[0])
                    return false;
            }
            String newExplanation = ignoreSpaceInText(Explanation);
            
            File.AppendAllText("Medicines.txt", id + " " + name + " " + description + " " + ingredients + " " + alternativeMedicine + " " + Status + " " + newExplanation + "\n");
            return true;

        }
        public Boolean CreateAllergenByDoctor(string health_record_num, string name)
        {
            string[] lines = File.ReadAllLines("AllergensByDoctor.txt");
            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (health_record_num==words[0] && name == words[1])
                    return false;
            }

            File.AppendAllText("AllergensByDoctor.txt", health_record_num + " " + name + "\n");
            return true;

        }


        public String ignoreSpaceInText(String explanation)
        {
            String[] splited = explanation.Split();
            String newExplanation = "";
            foreach (String word in splited)
            {
                newExplanation += word;
                newExplanation += "|";
            }
            return newExplanation;
        }

        public Boolean UpdateByDoctor(string ID, string Name, string Description, string Ingredients, string AlternativeMedicine, String Status, string Explanation)
        {
            if (SearchByID(ID) != null)
            {
                Delete(ID);
                CreateByDoctor(ID, Name, Description, Ingredients, AlternativeMedicine, Status, Explanation);
            }

            return false;
        }

        public ArrayList ViewMedicineByDoctor(String idOfMedicine)
        {
            string[] lines = File.ReadAllLines("Medicines.txt");
            int i = 0;
            ArrayList result = new ArrayList();
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (idOfMedicine == words[0])
                {
                    var m = new Medicine();
                    m.Id = words[0];
                    m.Name = words[1];
                    m.Description = words[2];
                    m.Ingredients = words[3];
                    m.AlternativeMedicine = words[4];
                    m.Status = words[5];
                    String[] parts = words[6].Split("|");
                    foreach(var word in parts)
                    {
                        m.Explanation += word;
                        m.Explanation += " ";
                    }

                    result.Add(m);
                }
            }

            return result;
        }
        public Medicine ViewAllergenByDoctor(String health_record_num,String name)
        {
            string[] lines = File.ReadAllLines("AllergensByDoctor.txt");
            int i = 0;
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (health_record_num == words[0] && name==words[1])
                {
                    var m = new Medicine();
                    m.Name = words[1];
                    m.health_record_num = words[0];

                    return m;
                }
            }

            return null;
        }
        public ArrayList ViewAllergensByDoctor(String health_record_num)
        {
            string[] lines = File.ReadAllLines("AllergensByDoctor.txt");
            int i = 0;
            ArrayList result = new ArrayList();
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (health_record_num == words[0])
                {
                    var m = new Medicine();
                    m.Name = words[1];
                    m.health_record_num = words[0];

                    result.Add(m);
                }
            }

            return result;
        }

        public ArrayList ViewAllByDoctor()
        {
            string[] lines = File.ReadAllLines("Medicines.txt");
            int i = 0;
            ArrayList result = new ArrayList();
            foreach (string medicine in lines)
            {
                string[] words = lines[i].Split();
                i++;
                
                    var m = new Medicine();
                    m.Id = words[0];
                    m.Name = words[1];
                    m.Description = words[2];
                    m.Ingredients = words[3];
                    m.AlternativeMedicine = words[4];
                    m.Status = words[5];
                    String[] parts = words[6].Split("|");
                    foreach (var word in parts)
                    {
                        m.Explanation += word;
                        m.Explanation += " ";
                    }

                    result.Add(m);
                
            }

            return result;
        }

    public String Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public String Ingredients { get; set; }
    public String AlternativeMedicine { get; set; }
    public String Status { get; set; } 
    public String Explanation { get; set; }
    public String health_record_num { get; set; }
    }
    
}
