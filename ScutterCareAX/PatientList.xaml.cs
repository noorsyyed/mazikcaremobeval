using MazikCare.MobEval.Datas;
using MazikCare.MobEval.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PatientList : MazikCare.MobEval.Common.LayoutAwarePage
    {
        private Random _rand;
        public PatientList()
        {
            this.InitializeComponent();

            this._rand = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        #region Default methods
        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddPatientDetails));
        }

        private void gvInGrid_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientDetails));
        }

        private void Grid_PointerReleased_1(object sender, PointerRoutedEventArgs e)
        {
            var data = ((Grid)sender).DataContext;
            this.Frame.Navigate(typeof(PatientDetails), data);
        }

        private async void pageRoot_Loaded_1(object sender, RoutedEventArgs e)
        {
            var setng = ((App)Application.Current).SettingsData;

            ObservableCollection<Patient> patientList = (setng.IsSyncWithAX ? await this.GetAXPatients() : this.GetDefaultPatients());            

            this.gvInGrid.ItemsSource = patientList;
            this.gvOutGrid.ItemsSource = patientList;
        }


        #endregion

        #region Util Methods
        private ObservableCollection<Patient> GetDefaultPatients()
        {
            ObservableCollection<Patient> patientList = new ObservableCollection<Patient>();


            patientList.Add(new Patient() { Name = "Bruce Caine", PhoneNumber = "989898343", RoomNumber = "101", ImagePath = "Assets/profile2.png", PatientDiagnosis1 = "Diabetic nephropathy,", PatientDiagnosis2 = "Cardiovascular disease,", PatientDiagnosis3 = "Asthma", Prescription1 = "Oxygen holder", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Rita Keeter", PhoneNumber = "989845343", RoomNumber = "102", ImagePath = "Assets/profile4.png", PatientDiagnosis1 = "Diabetic neuropathy,", PatientDiagnosis2 = "Frequent urination,", PatientDiagnosis3 = "Nausea", Prescription1 = "Oxygen holder", Prescription2 = "Oxygen holder" });
            patientList.Add(new Patient() { Name = "Mia Jackson", PhoneNumber = "9893458343", RoomNumber = "103", ImagePath = "Assets/profile7.png", PatientDiagnosis1 = "Diabetic obesity,", PatientDiagnosis2 = "Breathlessness,", PatientDiagnosis3 = "Back and joint pains", Prescription1 = "Acupuncture therapies", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Jacob Thomas", PhoneNumber = "9898945643", RoomNumber = "104", ImagePath = "Assets/profile5.png", PatientDiagnosis1 = "Diabetic foot ulcers,", PatientDiagnosis2 = "Blisters on the foot,", PatientDiagnosis3 = "Discoloration in feet", Prescription1 = "OmniPod Insulin Pump", Prescription2 = "Oxygen holder" });
            patientList.Add(new Patient() { Name = "Henry Pitt", PhoneNumber = "9898943443", RoomNumber = "105", ImagePath = "Assets/profile3.png", PatientDiagnosis1 = "Diabetic Retinopathy,", PatientDiagnosis2 = "Blurred vision,", PatientDiagnosis3 = "Fluctuating vision", Prescription1 = "Gel", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Jackson Hardy", PhoneNumber = "9898546343", RoomNumber = "106", ImagePath = "Assets/profile6.png", PatientDiagnosis1 = "Diabetic nephropathy,", PatientDiagnosis2 = "Cardiovascular disease,", PatientDiagnosis3 = "Asthma", Prescription1 = "OmniPod Insulin Pump", Prescription2 = "Gel" });
            patientList.Add(new Patient() { Name = "Jill Parker", PhoneNumber = "9898984353", RoomNumber = "107", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Cardiovascular disease,", PatientDiagnosis2 = "Faster heartbeat,", PatientDiagnosis3 = "Palpitations", Prescription1 = "Oxygen holder", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Jakes Sullivan", PhoneNumber = "98989843533", RoomNumber = "108", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Skin Complications,", PatientDiagnosis2 = "Itching,", PatientDiagnosis3 = "Sores", Prescription1 = "Gel", Prescription2 = "Oxygen holder" });
            patientList.Add(new Patient() { Name = "Billy Christian", PhoneNumber = "98989845653", RoomNumber = "109", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Dental Complications,", PatientDiagnosis2 = "Bleeding gums,", PatientDiagnosis3 = "Gingivitis", Prescription1 = "Apply a cold compress", Prescription2 = "Gel" });
            patientList.Add(new Patient() { Name = "Mia Jackson", PhoneNumber = "9893458343", RoomNumber = "110", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Cardiovascular disease,", PatientDiagnosis2 = "Faster heartbeat,", PatientDiagnosis3 = "Palpitations", Prescription1 = "Oxygen holder", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Bata Thomas", PhoneNumber = "9898945643", RoomNumber = "111", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Dental Complications,", PatientDiagnosis2 = "Bleeding gums,", PatientDiagnosis3 = "Gingivitis", Prescription1 = "Apply a cold compress", Prescription2 = "Gel" });

            patientList.Add(new Patient() { Name = "Henry Pitt", PhoneNumber = "9898943443", RoomNumber = "112", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Diabetic nephropathy,", PatientDiagnosis2 = "Cardiovascular disease,", PatientDiagnosis3 = "Asthma", Prescription1 = "Oxygen holder", Prescription2 = "Acupuncture therapies" });
            patientList.Add(new Patient() { Name = "Jackson Hardy", PhoneNumber = "9898546343", RoomNumber = "113", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Dental Complications,", PatientDiagnosis2 = "Bleeding gums,", PatientDiagnosis3 = "Gingivitis", Prescription1 = "Apply a cold compress", Prescription2 = "Oxygen holder" });
            patientList.Add(new Patient() { Name = "James Sanders", PhoneNumber = "989898343", RoomNumber = "114", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Diabetic Retinopathy,", PatientDiagnosis2 = "Blurred vision,", PatientDiagnosis3 = "Fluctuating vision", Prescription1 = "Gel", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Rita Keeter", PhoneNumber = "989845343", RoomNumber = "115", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Cardiovascular disease,", PatientDiagnosis2 = "Faster heartbeat,", PatientDiagnosis3 = "Palpitations", Prescription1 = "Oxygen holder", Prescription2 = "Gel" });
            patientList.Add(new Patient() { Name = "Jill Parker", PhoneNumber = "9898984353", RoomNumber = "116", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Diabetic nephropathy,", PatientDiagnosis2 = "Cardiovascular disease,", PatientDiagnosis3 = "Asthma", Prescription1 = "Oxygen holder", Prescription2 = "OmniPod Insulin Pump" });
            patientList.Add(new Patient() { Name = "Jakes Sullivan", PhoneNumber = "98989843533", RoomNumber = "117", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Diabetic foot ulcers,", PatientDiagnosis2 = "Blisters on the foot,", PatientDiagnosis3 = "Discoloration in feet", Prescription1 = "OmniPod Insulin Pump", Prescription2 = "Gel" });
            patientList.Add(new Patient() { Name = "Billy Christian", PhoneNumber = "98989845653", RoomNumber = "118", ImagePath = "Assets/profile_gen.png", PatientDiagnosis1 = "Diabetic Retinopathy,", PatientDiagnosis2 = "Blurred vision,", PatientDiagnosis3 = "Fluctuating vision", Prescription1 = "OmniPod Insulin Pump", Prescription2 = "Gel" });
            return patientList;
        }

        private async Task<ObservableCollection<Patient>> GetAXPatients()
        {
            var result = new ObservableCollection<Patient>();
            var srv = ((App)Application.Current).ServiceHelper;
            var prospects=await srv.GetAllProspects();
            foreach (var pros in prospects)
            {
                result.Add(new Patient() 
                { 
                    Name=pros.parmName,
                    PhoneNumber=pros.parmContact,
                    RoomNumber=pros.parmMRN,
                    ImagePath = "Assets/profile_gen.png",
                    PatientDiagnosis1=this.GetRandomDiag(),
                    PatientDiagnosis2=this.GetRandomDiag(),
                    PatientDiagnosis3=this.GetRandomDiag(),
                    Prescription1=this.GetRandomPresc(),
                    Prescription2=this.GetRandomPresc()
                });
            }
            return result;
        }

        private string GetRandomPresc()
        {
            var diags = new string[]
            {
                "Oxygen holder",
                "OmniPod Insulin Pump",
                "Gel",
                "Acupuncture therapies",
                "Apply a cold compress",
            };
            var idx = this._rand.Next(diags.Length - 1);
            return diags[idx];
        }

        private string GetRandomDiag()
        {
            var diags = new string[]
            {
                "Alzheimer's disease,",
                "Cerebral palsy,",
                "Genetic torsion dystonia,",
                "Hereditary spastic paraplegia,",
                "Leukodystrophy,",
                "Parkinson's disease,",
                "Progressive muscular atrophy,",
                "Quadriplegia,",
                "Paroneal muscular atrophy,",
                "Myelopathy & vascular myelopathies,",
                "Amyotrophic lateral sclerosis (ALS),",
                "Other demyelinating diseases of CNS,",
                "Guilain-Barre,",
                "Huntington's chorea,",
                "Motor neuron disease,",
                "Late effects of acute poliomyelitis (Post polio),",
                "Pseudo bulbar palsy,",
                "Paraplegia,",
                "Symptomatic torsion dystonia,",
                "Werdnig-Hoffman's disease,",
                "Diplegia of upper extremity",
                "Other cerebellar ataxia",
                "Friedreich's ataxia",
                "Hemiplegia/Hemiparesis",
                "Kugelberg-Welander disease",
                "Multiple Sclerosis",
                "syringomyelia",
                "Polymyositis",
            };            
            var idx = this._rand.Next(diags.Length - 1);
            return diags[idx];
        }
        #endregion
    }
}
