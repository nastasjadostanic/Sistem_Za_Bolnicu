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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for HealthRecordWpfPAGE.xaml
    /// </summary>
    public partial class HealthRecordWpfPAGE : Page
    {
        public HealthRecordWpfPAGE()
        {
            InitializeComponent();
            this.DataContext = this;
            fillAnamnesisGrid();
            fillRecipesGrid();
            fillIntructionsGrid();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void fillAnamnesisGrid()
        {
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            AnamnesisBindings = new ObservableCollection<AnamnesisBinding>();
            int AnamCounter = 0;
            string[] tmp= getAllAnamnesis(patient, ref AnamCounter);
            for (int i=0; i< AnamCounter;i++)
            {
                string[] words = tmp[i].Split();
                AnamnesisBindings.Add(new AnamnesisBinding {name= words[0], symptoms = words[1], results = words[2], hrn = words[3], dt = words[4]+" "+ words[5] + " " + words[6] });
            }
        }

        private void fillRecipesGrid()
        {
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            RecipesBindings = new ObservableCollection<RecipesBinding>();
            int RecipeCounter = 0;
            string[] tmp = getAllRecipes(patient, ref RecipeCounter);
            for (int i = 0; i < RecipeCounter; i++)
            {
                string[] words = tmp[i].Split();
                RecipesBindings.Add(new RecipesBinding { name = words[0], quantity = words[1], instructions = words[2], hrn = words[3], dt = words[4] + " " + words[5] + " " + words[6] });
            }
        }

        private void fillIntructionsGrid()
        {
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            InstructionsBindings = new ObservableCollection<InstructionsBinding>();
            int InstructionCounter = 0;
            Instruction inst = new Instruction();
            string[] tmp = inst.getAllInstructions(patient, ref InstructionCounter);
            for (int i = 0; i < InstructionCounter; i++)
            {
                string[] words = tmp[i].Split();
                InstructionsBindings.Add(new InstructionsBinding {ID= words[0], patientJMBG = words[1], doctorJMBG = words[2], specialization = words[3], Day = int.Parse(words[4]), Mounth = int.Parse(words[5]), Year = int.Parse(words[6]), Hour = int.Parse(words[7]), Minute = int.Parse(words[8])});
            }
        }

        private void getMatchingAnamnesis(string[] lines, ref int i, ref int j, Patient patient, ref string[] matchingAnamnesis)
        {
            string[] words = lines[i].Split();
            i++;
            if (words[3] == patient.HealthRecordNumber)
            {
                matchingAnamnesis[j] = lines[i - 1];
                j++;

            }
        }

        private string[] getAllAnamnesis(Patient patient, ref int numberOfAnamnesis)
        {
            string[] matchingAnamnesis = new string[1000];
            string[] lines = File.ReadAllLines("Anamnesis.txt");
            int i = 0;
            int j = 0;
            foreach (string line in lines)
            {
                getMatchingAnamnesis(lines, ref i, ref j, patient, ref matchingAnamnesis);
            }


            numberOfAnamnesis = j;
            return matchingAnamnesis;
        }
        public string[] getAllRecipes(Patient patient, ref int nubmerOfRecipes)
        {
            string[] matchingRecipes = new string[1000];
            string[] lines = File.ReadAllLines("Recipe.txt");
            int i = 0;
            int j = 0;
            foreach (string line in lines)
            {
                getMatchingRecipes(lines, ref i, ref j, patient, ref matchingRecipes);
            }


            nubmerOfRecipes = j;
            return matchingRecipes;
        }
        public void getMatchingRecipes(string[] lines, ref int i, ref int j, Patient patient, ref string[] matchingRecipes)
        {
            string[] words = lines[i].Split();
            i++;
            if (words[3] == patient.HealthRecordNumber)
            {
                matchingRecipes[j] = lines[i - 1];
                j++;

            }
        }

       
        public ObservableCollection<AnamnesisBinding> AnamnesisBindings
        {

            get;
            set;
        }

        public ObservableCollection<RecipesBinding>RecipesBindings
        {

            get;
            set;
        }

        public ObservableCollection<InstructionsBinding> InstructionsBindings
        {

            get;
            set;
        }
    }

    

}
