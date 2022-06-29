using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using HospitalTeam12.Model;

namespace MainPackage.Model
{
    class MedicalRecord
    {
        private ArrayList anamnesises = new ArrayList();
        private ArrayList recipes = new ArrayList();
        public String health_record_num { get; set; }

        public Boolean CreateAnamnesis(Anamnesis a)
        {
            string[] lines = File.ReadAllLines("Anamnesis.txt");
            int i = 0;
            Boolean foundSame = false;
            foreach (string anamnesis in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (words[0]==a.GetName())
                {
                    foundSame = true;
                }

            }
            if (foundSame == false)
            {
                File.AppendAllText("Anamnesis.txt", a.GetName() + " " + a.GetResults() + " " + a.GetSymptoms() + 
                " " + a.GetHRN() + " " + a.dt + "\n");
                return true;
            }
            return false;
        }


        public Boolean UpdateAnamnesis(Anamnesis a)
        {
            string[] lines1 = File.ReadAllLines("Anamnesis.txt");
            int i = 0;
            String symptom;
            String result;

            foreach (string anamnesis in lines1)
            {
                string[] words = lines1[i].Split();
                i++;

                if (words[0] == a.GetName())
                {
                    if (a.GetSymptoms().Length != 0)
                    {
                        symptom = a.GetSymptoms();
                    }
                    else
                    {
                        symptom = words[2];
                    }
                    if (a.GetResults().Length != 0)
                    {
                        result = a.GetResults();
                    }
                    else
                    {
                        result = words[1];
                    }
                    File.AppendAllText("Anamnesis.txt", a.GetName() + " " + result + " " + symptom + 
                    " " + a.GetHRN() + " " + a.dt + "\n");
                }
            }

            string tempFile = Path.GetTempFileName();
            i = 0;
            int count = 0;
            using (var sr = new StreamReader("Anamnesis.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines2;

                while ((lines2 = sr.ReadLine()) != null)
                {
                    string[] words = lines2.Split();

                    if (a.GetName() == words[0])
                    {
                        count++;
                    }

                    if (count == 2 || a.GetName() != words[0])
                    {
                        sw.WriteLine(lines2);
                    }
                    i++;
                }
            }

            File.Delete("Anamnesis.txt");
            File.Move(tempFile, "Anamnesis.txt");


            return true;
        }

        public Boolean CreateRecipe(Recipe r)
        {
            string[] lines = File.ReadAllLines("Recipe.txt");
            int i = 0;
            Boolean foundSame = false;
            foreach (string anamnesis in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (words[0] == r.GetName())
                {
                    foundSame = true;
                }

            }
            if (foundSame == false)
            {
                File.AppendAllText("Recipe.txt", r.GetName() + " " + r.GetQuantity() + " " + r.GetInstructions() + 
                " " + r.GetHRN() + " " + r.dt + "\n");
                return true;
            }
            return false;
        }


        public Boolean UpdateRecipe(Recipe r)
        {
            string[] lines1 = File.ReadAllLines("Recipe.txt");
            int i = 0;
            String instruction;
            String quantity;

            foreach (string recipe in lines1)
            {
                string[] words = lines1[i].Split();
                i++;

                if (words[0] == r.GetName())
                {
                    if (r.GetQuantity().Length != 0)
                    {
                        quantity = r.GetQuantity();
                    }
                    else
                    {
                        quantity = words[1];
                    }
                    if (r.GetInstructions().Length != 0)
                    {
                        instruction = r.GetInstructions();
                    }
                    else
                    {
                        instruction = words[2];
                    }
                    File.AppendAllText("Recipe.txt", r.GetName() + " " + quantity + " " + instruction +
                    " " + r.GetHRN()+ " " + r.dt + "\n");
                }
            }

            string tempFile = Path.GetTempFileName();
            i = 0;
            int count = 0;
            using (var sr = new StreamReader("Recipe.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines2;

                while ((lines2 = sr.ReadLine()) != null)
                {
                    string[] words = lines2.Split();

                    if (r.GetName() == words[0])
                    {
                        count++;
                    }

                    if (count == 2 || r.GetName() != words[0])
                    {
                        sw.WriteLine(lines2);
                    }
                    i++;
                }
            }

            File.Delete("Recipe.txt");
            File.Move(tempFile, "Recipe.txt");

            return true;
        }

        public ArrayList GetAnamnesises(String HRN)
        {
            if (anamnesises == null)
                anamnesises = new System.Collections.ArrayList();
            string[] lines = File.ReadAllLines("Anamnesis.txt");
            int i = 0;
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (HRN==words[3])
                {
                    Anamnesis a = new Anamnesis();
                    a.SetName(words[0]);
                    a.SetResults(words[1]);
                    a.SetSymptoms(words[2]);
                    a.SetHRN(words[3]);
                    a.dt = words[4] + " " + words[5] + " " + words[6];
                    anamnesises.Add(a);
                }
            }
            return anamnesises;
        }

        public ArrayList GetRecipes(String HRN)
        {
            if (anamnesises == null)
                anamnesises = new System.Collections.ArrayList();
            string[] lines = File.ReadAllLines("Recipe.txt");
            int i = 0;
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (HRN == words[3])
                {
                    Recipe a = new Recipe();
                    a.SetName(words[0]);
                    a.SetQuantity(words[1]);
                    a.SetInstructions(words[2]);
                    a.SetHRN(words[3]);
                    a.dt = words[4]+" "+words[5]+" "+words[6];
                    recipes.Add(a);
                }
            }
            return recipes;
        }

        public void SetAnamnesises(System.Collections.ArrayList newAnamnesises)
        {
            RemoveAllAnamnesises();
            foreach (Anamnesis oAnamnesises in newAnamnesises)
                AddAnamnesis(oAnamnesises);
        }

        public void AddAnamnesis(Anamnesis newAnamnesis)
        {
            if (newAnamnesis == null)
                return;
            if (this.anamnesises == null)
                this.anamnesises = new System.Collections.ArrayList();
            if (!this.anamnesises.Contains(newAnamnesis))
                this.anamnesises.Add(newAnamnesis);
        }

        public void RemoveAnamnesis(Anamnesis oldAnamnesis)
        {
            if (oldAnamnesis == null)
                return;
            if (this.anamnesises != null)
                if (this.anamnesises.Contains(oldAnamnesis))
                    this.anamnesises.Remove(oldAnamnesis);
        }

        public void RemoveAllAnamnesises()
        {
            if (anamnesises != null)
                anamnesises.Clear();
        }

        public void SetRecipes(System.Collections.ArrayList newRecipes)
        {
            RemoveAllRecipes();
            foreach (Anamnesis oRecipes in newRecipes)
                AddAnamnesis(oRecipes);
        }

        public void AddRecipe(Recipe newRecipe)
        {
            if (newRecipe == null)
                return;
            if (this.recipes == null)
                this.recipes = new System.Collections.ArrayList();
            if (!this.recipes.Contains(newRecipe))
                this.recipes.Add(newRecipe);
        }

        public void RemoveRecipe(Anamnesis oldRecipe)
        {
            if (oldRecipe == null)
                return;
            if (this.recipes != null)
                if (this.recipes.Contains(oldRecipe))
                    this.recipes.Remove(oldRecipe);
        }

        public void RemoveAllRecipes()
        {
            if (recipes != null)
                recipes.Clear();
        }


    }
}
