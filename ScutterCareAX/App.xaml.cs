using MazikCare.MobEval.Datas;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace MazikCare.MobEval
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        private PatientPhysicalAssessment _physical;
        private PatientHistory _patientHistory;
        private SettingsData _data;
        private DBHelper _db;
        public DispatcherTimer _timer;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            this.LoadData();
        }

        private async void LoadData()
        {
            this._db = new DBHelper();
            this._data = await this._db.LoadData();
            if (this.LoadCompleted != null)
            {
                this.LoadCompleted();
            }
            this.ServiceHelper = new ServiceHelper();
            this.PrescriptionData = new PrescriptionData();
            this.DiagnosisData = new DiagnosisData();
            this._patientHistory = new PatientHistory();
            this.MobilityData = new MobilityData();
            _physical = new PatientPhysicalAssessment()
            {
                BP = "120/80",
                Height = "5ft 5inches",
                Weight = "140 lbs"
            };
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            if (args.Kind == ActivationKind.Protocol)
            {
                StartupAsync(args); 
            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            StartupAsync(args);
        }

        private static void StartupAsync(IActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage)))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public void SaveSettings()
        {
            this._db.SaveData(this._data);
        }

        public void SavePhysicalData()
        {
            this._db.SaveData(this._physical);
        }

        public SettingsData SettingsData
        {
            get
            {
                return this._data;
            }
        }

        public PatientPhysicalAssessment PatientPhysicalAssessment
        {
            get
            {
                return this._physical;
            }
        }

        public PatientHistory PatientHistory
        {
            get
            {
                return this._patientHistory;
            }
        }

        public PrescriptionData PrescriptionData
        {
            get;
            private set;
        }

        public MobilityData MobilityData
        {
            get;
            private set;
        }

        public DiagnosisData DiagnosisData
        {
            get;
            private set;
        }

        public Action LoadCompleted
        {
            get;
            set;
        }

        public ServiceHelper ServiceHelper
        {
            get;
            set;
        }

        public ObservableCollection<string> GenitourinarySymptomsList { get; set; }
        public ObservableCollection<string> EndocrineSymptomsList { get; set; }
        public ObservableCollection<string> NeurologicalSymptomList { get; set; }

        public Patient Patient
        {
            get
            {
                if (this.SettingsData.IsSyncWithAX)
                {
                    var pat = this.ServiceHelper.GetPatient();
                    if (!string.IsNullOrEmpty(pat.parmName))
                    {
                        var addrs = pat.parmAddress.Split('\n');
                        var val = new Patient()
                        {
                            Name = pat.parmName,
                            Address = addrs[0],
                            PhoneNumber = "Tel : " + pat.parmContact,
                            DOB = pat.parmAge,
                            Gender = "Gender : " + pat.parmGender,
                            RecId = pat.parmRecId,
                            MRN = pat.parmMRN
                        };

                        if (addrs.Length > 1)
                        {
                            val.City = addrs[1];
                        }
                        return val;
                    }
                    else
                    {
                        return new Patient()
                        {
                            Name = "Bruce Caine",
                            Address = "2604 Dempster St",
                            City = "Park Ridge IL 60016.",
                            PhoneNumber = "Tel : 1 312 345 6789",
                            DOB = "78 Years",
                            Gender = "Gender : Male",
                        };
                    }

                }
                else
                {
                    return new Patient()
                    {
                        Name = "Bruce Caine",
                        Address = "2604 Dempster St",
                        City = "Park Ridge IL 60016.",
                        PhoneNumber = "Tel : 1 312 345 6789",
                        DOB = "78 Years",
                        Gender = "Gender : Male",
                    };
                }
            }
        }
    }
}
