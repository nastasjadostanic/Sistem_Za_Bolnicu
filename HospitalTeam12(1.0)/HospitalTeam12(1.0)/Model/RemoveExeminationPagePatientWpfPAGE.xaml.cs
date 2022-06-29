using MainPackage.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RemoveExeminationPagePatientWpfPAGE.xaml
    /// </summary>
    public partial class RemoveExeminationPagePatientWpfPAGE : Page
    {
        const int MAXTROLLCOUNTER = 10;
        public ObservableCollection<ExamBinding> ExamBindings { get; set; }
        public RemoveExeminationPagePatientWpfPAGE()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient pp = new Patient();
            pp = pp.SearchPatientByJMBG("123456789");//rucno setovaje pacijenta jer nema login
            ExamBinding eb = new ExamBinding();
            Examination ee = new Examination();
            ExamBindings = new ObservableCollection<ExamBinding>();

            string[] tmp = ee.GetAllExamination();
            for (int i = 0; i < tmp.Length; i++)
            {
                string[] words = tmp[i].Split();

                if (pp.user.Jmbg == words[6])
                    ExamBindings.Add(new ExamBinding { ID = words[0], ROOM = words[1], FLOOR = words[2], PATIENTFirstName = words[3], PATIENTLastName = words[4], PATIENTHRN = words[5], PATIENTJMBG = words[6], DOCTORFirstName = words[7], DOCTORLastName = words[8], DAY = int.Parse(words[9]), MNTH = int.Parse(words[10]), YEAR = int.Parse(words[11]), HOUR = int.Parse(words[12]), MINUTE = int.Parse(words[13]) });

            }

            pp.CleanOldTrollCounters(pp);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                Patient pp = new Patient();
                pp = pp.SearchPatientByJMBG("123456789");//rucno setovaje pacijenta jer nema login
                Examination ee = new Examination();
                ExamBinding exb = (ExamBinding)SearchExa.SelectedItem;
                ee.Remove(exb.ID);

                pp.increaseTrollCounter(pp);

                int j = 0;
                pp.getAllTrollCounters(pp, ref j);
                if (j >= MAXTROLLCOUNTER) pp.disableAccount(pp);


            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
