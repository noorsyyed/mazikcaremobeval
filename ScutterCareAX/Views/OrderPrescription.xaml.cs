using MazikCare.MobEval.Datas;
using MazikCare.MobEval.Helpers;
using MazikCare.MobEval.Views.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using System.Linq;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class OrderPrescription : MazikCare.MobEval.Common.LayoutAwarePage
    {
        #region Private Vars
        private StorageFile _pdf;
        private StorageFile _signature;
        private long _prescriptionId;
        private SignaturePage _signPopup;
        #endregion

        #region CTOR
        public OrderPrescription()
        {
            this.DefaultViewModel["OrderItems"] = new ObservableCollection<OrderItem>() 
            {
                new OrderItem()
                {
                    Name="--Select--"
                },
                new OrderItem()
                {
                    Image="../Assets/diabetes02.jpg",
                     Name="Glucophage XR 500mg",
                     Id="000142_202"
                },
                new OrderItem()
                {
                    Image="../Assets/diabetes06.jpg",
                     Name="Glucometer",
                     Id="000155_202"
                },
                new OrderItem()
                {
                    Image="../Assets/pod_tubeless02.jpg",
                     Name="OmniPod Insulin Pump",
                     Id="000161_202"
                },
            };

            this.DefaultViewModel["DiagnosisDatas"] = new ObservableCollection<string>() 
            {                
                "331.0 - Alzheimer's disease",
                "330.0 - Leukodystrophy",
                "756.51 - Osteogenesis imperfecta",
                "741.00-741.93 - Spina bifida"
            };

            this.InitializeComponent();
            this.txtFFDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            this.txtPrescriptionDate.Text = DateTime.Today.ToString("dd MMM yyyy");

            chkListFrame.Navigate(typeof(DiagnosisCondition));
        }
        #endregion

        #region Overrides
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
            var app = (App)Application.Current;

            if (pageState == null && !app.SettingsData.IsShareStorageItemsHandlerAssigned)
            {
                DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
                dataTransferManager.DataRequested += this.ShareStorageItemsHandler;
                app.SettingsData.IsShareStorageItemsHandlerAssigned = true;
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            pageState["PrescriptionSet"] = true;
        }
        #endregion

        #region Event Handlers

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CoreWindow currentWindow = Window.Current.CoreWindow;
                Popup popup = new Popup();
                popup.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                popup.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

                if (_signPopup == null)
                {
                    _signPopup = new SignaturePage();

                }
                else
                {
                    _signPopup = null;
                    this._signPopup = new SignaturePage();
                }

                popup.Child = _signPopup;
                this._signPopup.Tag = popup;
                this._signPopup.Height = currentWindow.Bounds.Height;
                this._signPopup.Width = currentWindow.Bounds.Width;
                var btn = (Button)sender;
                this._signPopup.Source = this.imgSign;

                popup.Margin = new Thickness(0, 0, 0, 0);

                popup.IsOpen = true;
            }
            catch (Exception ex)
            {
                Util.HandleException(ex, ex.Message);
            }
        }

        private async void GeneratePdf_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                this.progressRing.IsActive = true;
                await this.WriteDataToXML();
                var pdf = await this.GeneratePdf();
                await Launcher.LaunchFileAsync(pdf);

                var app = (App)Application.Current;
                var srv = app.ServiceHelper;
                var pat = app.Patient;
                this.progressRing.IsActive = false;
            }
            catch (Exception ex)
            {
                this.progressRing.IsActive = false;
                Util.HandleException(ex, ex.Message);
            }

            //srv.AddDocument(pat.SSN
        }


        private void llComboItem_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedItems = null;

            if (cmbSelected.Content != null)
                selectedItems = new List<string>(cmbSelected.Content.ToString().Split(','));
            else
                selectedItems = new List<string>();

            if (e.RemovedItems.Count > 0)
            {
                var listItemRemoved = e.RemovedItems[0] as ListViewItem;

                var stk = listItemRemoved.Content as StackPanel;

                selectedItems.Remove(((TextBlock)stk.Children[1]).Text);
            }

            if (e.AddedItems.Count > 0)
            {
                var listItemAdded = e.AddedItems[0] as ListViewItem;

                var stk = listItemAdded.Content as StackPanel;

                selectedItems.Add(((TextBlock)stk.Children[1]).Text);
            }

            string seleted = string.Empty;

            foreach (var item in selectedItems)
            {
                seleted += item + ",";
            }

            if (seleted != string.Empty)
            {
                cmbSelected.Content = seleted.Substring(0, seleted.Length - 1);
                cmb1.SelectedItem = cmbSelected;
            }
            else
            {
                cmbSelected.Content = string.Empty;
                cmb1.SelectedIndex = 0;
            }
        }

        private async void Complete_Click(object sender, RoutedEventArgs e)
        {
            //post data to AX
            var app = (App)Application.Current;
            if (app.SettingsData.IsSyncWithAX)
            {
                //ax calls
                //await app.ServiceHelper.ConvertProspectToPatient(app.Patient.RecId);
                var itemsForOrder = new ObservableCollection<string>();

                itemsForOrder.Add(app.PrescriptionData.OrderItem.Id);//adding item for order

                var diagnosis = new ObservableCollection<string>();

                //add diagnosis
                if (app.MobilityData.NeurologicalCondition != null)
                    foreach (var condtion in app.MobilityData.NeurologicalCondition)
                    {
                        diagnosis.Add(condtion.Id);
                    }

                if (app.MobilityData.CongenitalSkeletal != null)
                    foreach (var condtion in app.MobilityData.CongenitalSkeletal)
                    {
                        diagnosis.Add(condtion.Id);
                    }

                if (app.MobilityData.Myopathy != null)
                    foreach (var condtion in app.MobilityData.Myopathy)
                    {
                        diagnosis.Add(condtion.Id);
                    }

                this._prescriptionId = await app.ServiceHelper.CreatePrescription(app.Patient.RecId, app.PrescriptionData.LON, itemsForOrder, diagnosis);

                //add document
                //   await app.ServiceHelper.AddDocumentToPrescription(this._prescriptionId, await this.GenerateSignature());
                try
                {
                    await app.ServiceHelper.AddDocumentToPrescription(this._prescriptionId, await this.GeneratePdf());
                }
                catch (Exception)//silent it as of now
                {
                }

                await this.WriteDataToXML(); //save the prescription id
            }

            this.Frame.Navigate(typeof(CompleteMainPage));
        }
        #endregion

        #region PDF Generation
        private async Task<StorageFile> GeneratePdf()
        {
            if (this._pdf == null)
            {
                var app = (App)Application.Current;
                //data
                var data = (PrescriptionData)this.DefaultViewModel["PrescriptionData"];
                var diagData = (DiagnosisData)this.DefaultViewModel["DiagnosisData"];


                StorageFile page1 = await Package.Current.InstalledLocation.GetFileAsync(@"Datas\page1.png");
                StorageFile page2 = await Package.Current.InstalledLocation.GetFileAsync(@"Datas\page2.png");
                StorageFile page3 = await Package.Current.InstalledLocation.GetFileAsync(@"Datas\page3.png");
                //StorageFile page4 = await Package.Current.InstalledLocation.GetFileAsync(@"Datas\page4.png");
                StorageFile page5 = await Package.Current.InstalledLocation.GetFileAsync(@"Datas\page5.png");
                StorageFile check = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\Check.png");
                var checkImage = new Siberix.Sparkle.Graphics.Image(await check.OpenStreamForReadAsync());

                this._pdf = await ApplicationData.Current.LocalFolder.CreateFileAsync(@"Data\Prescription.pdf", CreationCollisionOption.ReplaceExisting);
                var signStream = await this.GetLocalResource("Sign.png");
                using (var stream = await this._pdf.OpenStreamForWriteAsync())
                {
                    await Task.Run(async () =>
                    {
                        // Document
                        Siberix.Sparkle.PDF.Document document = new Siberix.Sparkle.PDF.Document();

                        // Info
                        document.Info.Title = "Mazik Care";
                        document.Info.Author = "Mazik Global";
                        document.Info.Creator = "Mazik Tech Solutions, Hyderabad, India";

                        document.Permissions.Add = false;
                        document.Permissions.Copy = false;
                        document.Permissions.Modify = false;
                        document.Permissions.Print = true;

                        // Page
                        document.AddPage(845, 1195);
                        document.AddPage(850, 1100);
                        document.AddPage(850, 1100);
                        //document.AddPage(850, 1100);
                        //document.AddPage(850, 1100);
                        document.AddPage(850, 1100);

                        var font = new Siberix.Sparkle.Graphics.Font(await DBHelper.GetResourceStreamAsync(@"Datas\calibrib.ttf"), 17);
                        var font1 = new Siberix.Sparkle.Graphics.Font(await DBHelper.GetResourceStreamAsync(@"Datas\calibriz.ttf"), 15);

                        //page 1
                        Siberix.Sparkle.PDF.IPage page = document.Pages[0];

                        page.Graphics.Font = font;
                        page.Graphics.Brush = Siberix.Sparkle.Graphics.Brushes.Black;

                        var image = new Siberix.Sparkle.Graphics.Image(await page1.OpenStreamForReadAsync());
                        page.Graphics.DrawImage(image, 1, 1, image.Width, image.Height);



                        page.Graphics.DrawString(29, 453, "Genitourinary Symptoms");
                        int sympYCoordinate = 453;
                        int sympXCoordinate = 40;
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.GenitourinarySymptomsList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(29, sympYCoordinate, "Endocrine Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.EndocrineSymptomsList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(29, sympYCoordinate, "Skin Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.SkinSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);

                        sympXCoordinate = 440;
                        sympYCoordinate = 453;
                        page.Graphics.Font = font;
                        page.Graphics.DrawString(430, sympYCoordinate, "Neurological Symptoms");
                        sympYCoordinate += 20;
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.NeurologicalSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(430, sympYCoordinate, "Gastrointestinal Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.GastroIntestinalSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(430, sympYCoordinate, "Systemic Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.SystemicSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(430, sympYCoordinate, "Eye Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.EyeSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(430, sympYCoordinate, "Cardiovascular Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.CardiovascularSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);

                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(430, sympYCoordinate, "Psychological Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.PsychologicalSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);


                        page.Graphics.Font = font;
                        sympYCoordinate += 20;
                        page.Graphics.DrawString(430, sympYCoordinate, "Pediatric Symptoms");
                        page.Graphics.Font = font1;
                        FillSymptomsSection(app.GastroIntestinalSymptomList, page, ref sympYCoordinate, ref sympXCoordinate);


                        string city = "City", state = "State", zip = "Zip";

                        string[] cityState = app.SettingsData.CityState.Split(',');

                        if (cityState.Length == 2)
                        {
                            city = cityState[0];
                            string[] stateZip = cityState[1].Split('-');

                            if (stateZip.Length == 2)
                            {
                                state = stateZip[0];
                                zip = stateZip[1];
                            }
                        }


                        page.Graphics.DrawString(193, 120, DateTime.Today.ToString("dd MMM yyyy"));
                        //page.Graphics.DrawString(82, 206, "Male");
                        page.Graphics.DrawString(75, 200, app.SettingsData.Name);
                        page.Graphics.DrawString(140, 227, app.SettingsData.Address);
                        page.Graphics.DrawString(63, 252, city);
                        page.Graphics.DrawString(233, 252, state);
                        page.Graphics.DrawString(310, 252, zip);

                        if (app.Patient != null)
                            if (app.Patient.DOB != null)
                                page.Graphics.DrawString(552, 252, app.Patient.DOB.Substring(0, 2));

                        page.Graphics.DrawString(75, 310, "Dr.David Carter");
                        page.Graphics.DrawString(140, 335, "2930 Skyway Circle North, Bldg B");
                        page.Graphics.DrawString(63, 362, "Irving");
                        page.Graphics.DrawString(468, 362, "TX");
                        page.Graphics.DrawString(622, 361, "75038");

                        //vitals
                        page.Graphics.DrawString(182, 1050, app.PatientPhysicalAssessment.OralTemperature);
                        page.Graphics.DrawString(68, 1001, app.PatientPhysicalAssessment.Height);
                        page.Graphics.DrawString(261, 1001, app.PatientPhysicalAssessment.Weight);
                        page.Graphics.DrawString(459, 1001, app.PatientPhysicalAssessment.BP);
                        page.Graphics.DrawString(545, 1050, app.PrescriptionData.Respiratory);
                        page.Graphics.DrawString(736, 1001, app.PatientPhysicalAssessment.PulseRate);



                        //page.Graphics.DrawString(120, 1063, GetYesNo(app.PatientPhysicalAssessment.HasRestBreathShortness)); //ShortNess of Breathe are Rest
                        //page.Graphics.DrawString(290, 1063, GetYesNo(app.PatientPhysicalAssessment.HasExertionBreathShortness));//ShortNess of Breathe are Exertion
                        //page.Graphics.DrawString(440, 1063, GetYesNo(app.PatientPhysicalAssessment.IsO2Required));//Is O2 Required
                        //page.Graphics.DrawString(538, 1053, app.PatientPhysicalAssessment.NoofLitres);//No Of Liters Required
                        //page.Graphics.DrawString(700, 1048, app.PatientPhysicalAssessment.O2Sats);//O2 Required

                        page.Graphics.Flush();

                        #region Page 2
                        page = document.Pages[1];

                        page.Graphics.Font = font;
                        page.Graphics.Brush = Siberix.Sparkle.Graphics.Brushes.Black;

                        image = new Siberix.Sparkle.Graphics.Image(await page2.OpenStreamForReadAsync());
                        page.Graphics.DrawImage(image, 1, 1, image.Width, image.Height);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsOrthostaticHypotension ? 367 : 402, 150, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsVisionAssessment ? 367 : 402, 187, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsOSExam ? 367 : 402, 232, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsOSCatractExam ? 367 : 402, 267, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsOSRetinaExam ? 367 : 402, 308, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsCSExam ? 367 : 402, 358, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsArterialPulse ? 367 : 402, 400, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsNSExam ? 367 : 402, 451, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsNSTuningFork ? 367 : 402, 497, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsNSVibrationDecrease ? 367 : 402, 541, 30, 30);
                        page.Graphics.DrawImage(checkImage, !app.PrescriptionData.IsNSDTRReflexPatterns ? 367 : 402, 588, 30, 30);

                        page.Graphics.DrawString(456, 150, app.PrescriptionData.NoteOrthostaticHypotension);
                        page.Graphics.DrawString(456, 187, app.PrescriptionData.NoteVisionAssessment);
                        page.Graphics.DrawString(456, 232, app.PrescriptionData.NoteOSExam);
                        page.Graphics.DrawString(456, 267, app.PrescriptionData.NoteOSCatractExam);
                        page.Graphics.DrawString(456, 308, app.PrescriptionData.NoteOSRetinaExam);
                        page.Graphics.DrawString(456, 354, app.PrescriptionData.NoteCSExam);
                        page.Graphics.DrawString(456, 400, app.PrescriptionData.NoteArterialPulse);
                        page.Graphics.DrawString(456, 451, app.PrescriptionData.NoteNSExam);
                        page.Graphics.DrawString(456, 496, app.PrescriptionData.NoteNSTuningFork);
                        page.Graphics.DrawString(456, 541, app.PrescriptionData.NoteNSVibrationDecrease);
                        page.Graphics.DrawString(456, 590, app.PrescriptionData.NoteNSDTRReflexPatterns);

                        #endregion

                        #region Page 3
                        //page 3
                        page = document.Pages[2];

                        page.Graphics.Font = font;
                        page.Graphics.Brush = Siberix.Sparkle.Graphics.Brushes.Black;

                        image = new Siberix.Sparkle.Graphics.Image(await page3.OpenStreamForReadAsync());
                        page.Graphics.DrawImage(image, 1, 1, image.Width, image.Height);

                        //page.Graphics.DrawString(120, 130, GetYesNo(app.PatientPhysicalAssessment.HasCurrentPressureSores));
                        //page.Graphics.DrawString(290, 130, GetYesNo(app.PatientPhysicalAssessment.HasHistoryPressureSores));
                        page.Graphics.DrawString(400, 130, app.PatientPhysicalAssessment.Locations);
                        page.Graphics.DrawString(540, 130, app.PatientPhysicalAssessment.Stage);
                        //page.Graphics.DrawString(740, 130, GetYesNo(app.PatientPhysicalAssessment.CanShiftWeight));

                        //page.Graphics.DrawString(120, 180, GetYesNo(app.PatientPhysicalAssessment.HasPoorBalance));
                        //page.Graphics.DrawString(290, 180, GetYesNo(app.PatientPhysicalAssessment.HasPoorEndurance));
                        //page.Graphics.DrawString(430, 180, GetYesNo(app.PatientPhysicalAssessment.HasHistoryOfFalls));
                        //page.Graphics.DrawString(570, 180, GetYesNo(app.PatientPhysicalAssessment.HasRiskOfFalls));
                        //page.Graphics.DrawString(740, 180, GetYesNo(app.PatientPhysicalAssessment.HasSignificantEdema));


                        int histYCoordinate = 187;
                        page.Graphics.DrawString(30, histYCoordinate, "Past Medical History");
                        page.Graphics.Font = font1;
                        foreach (var item in app.PastMedicalHistoryList)
                        {
                            histYCoordinate += 20;
                            page.Graphics.DrawEllipse(40, histYCoordinate + 5, 10, 10, Siberix.Sparkle.Graphics.PaintMode.Fill);
                            page.Graphics.DrawString(60, histYCoordinate, item);

                        }
                        histYCoordinate += 40;
                        page.Graphics.Font = font;
                        page.Graphics.DrawString(30, histYCoordinate, "Social History");
                        page.Graphics.Font = font1;
                        foreach (var item in app.SocialHistoryList)
                        {
                            histYCoordinate += 20;
                            page.Graphics.DrawEllipse(40, histYCoordinate + 5, 10, 10, Siberix.Sparkle.Graphics.PaintMode.Fill);
                            page.Graphics.DrawString(60, histYCoordinate, item);

                        }

                        histYCoordinate += 40;
                        page.Graphics.Font = font;
                        page.Graphics.DrawString(30, histYCoordinate, "History of Endocrine disorder");
                        page.Graphics.Font = font1;
                        foreach (var item in app.EndocrineDisorderList)
                        {
                            histYCoordinate += 20;
                            page.Graphics.DrawEllipse(40, histYCoordinate + 5, 10, 10, Siberix.Sparkle.Graphics.PaintMode.Fill);
                            page.Graphics.DrawString(60, histYCoordinate, item);

                        }

                        page.Graphics.DrawString(210, 543, app.PatientHistory.RiskOfFallsOnSet);
                        page.Graphics.DrawString(305, 543, app.PatientHistory.RiskOfFallsDescription);
                        page.Graphics.DrawString(705, 543, app.PatientHistory.RiskOfFallsDiagnosis);

                        page.Graphics.DrawString(210, 597, app.PatientHistory.WeaknessOnSet);
                        page.Graphics.DrawString(305, 597, app.PatientHistory.WeaknessDescription);
                        page.Graphics.DrawString(705, 597, app.PatientHistory.WeaknessDiagnosis);

                        page.Graphics.DrawString(210, 640, app.PatientHistory.InabiliyToAmbulateOnSet);
                        page.Graphics.DrawString(305, 640, app.PatientHistory.InabiliyToAmbulateDescription);
                        page.Graphics.DrawString(705, 640, app.PatientHistory.InabiliyToAmbulateDiagnosis);

                        page.Graphics.DrawString(210, 680, app.PatientHistory.OtherOnSet);
                        page.Graphics.DrawString(305, 680, app.PatientHistory.OtherDescription);
                        page.Graphics.DrawString(705, 680, app.PatientHistory.OtherDiagnosis);

                        if (app.PatientHistory.UpperBodyWeaknessType != null)
                            switch (app.PatientHistory.UpperBodyWeaknessType)
                            {
                                case "Mild": page.Graphics.DrawImage(checkImage,195, 743, 30, 30);
                                    break;

                                case "Moderate": page.Graphics.DrawImage(checkImage,305, 743, 30, 30);
                                    page.Graphics.DrawString(330, 770, app.PatientHistory.UpperBodyWeaknessDescription);
                                    break;

                                case "Severe": page.Graphics.DrawImage(checkImage, 580, 743, 30,30);
                                    page.Graphics.DrawString(610, 770, app.PatientHistory.UpperBodyWeaknessDescription);
                                    break;
                            }

                        if (app.PatientHistory.UpperBodyPainType != null)
                            switch (app.PatientHistory.UpperBodyPainType)
                            {
                                case "Mild": page.Graphics.DrawImage(checkImage,195, 800, 30, 30);
                                    break;

                                case "Moderate": page.Graphics.DrawImage(checkImage, 305, 800, 30, 30);
                                    page.Graphics.DrawString(330, 825, app.PatientHistory.UpperBodyPainDescription);
                                    break;

                                case "Severe": page.Graphics.DrawImage(checkImage, 580, 800, 30, 30);
                                    page.Graphics.DrawString(610, 828, app.PatientHistory.UpperBodyPainDescription);
                                    break;
                            }

                        if (app.PatientHistory.UpperBodyRangeOfMotionType != null)
                            switch (app.PatientHistory.UpperBodyRangeOfMotionType)
                            {
                                case "Mild": page.Graphics.DrawImage(checkImage, 195, 860, 30, 30);
                                    break;

                                case "Moderate": page.Graphics.DrawImage(checkImage, 305, 860, 30, 30);
                                    page.Graphics.DrawString(330, 883, app.PatientHistory.UpperBodyRangeOfMotionDescription);
                                    break;

                                case "Severe": page.Graphics.DrawImage(checkImage, 580, 860, 30, 30);
                                    page.Graphics.DrawString(610, 886, app.PatientHistory.UpperBodyRangeOfMotionDescription);
                                    break;
                            }

                        if (app.PatientHistory.LowerBodyWeaknessType != null)
                            switch (app.PatientHistory.LowerBodyWeaknessType)
                            {
                                case "Mild": page.Graphics.DrawImage(checkImage, 195, 917, 30, 30);
                                    break;

                                case "Moderate": page.Graphics.DrawImage(checkImage, 305, 917, 30, 30);
                                    page.Graphics.DrawString(330, 942, app.PatientHistory.LowerBodyWeaknessDescription);
                                    break;

                                case "Severe": page.Graphics.DrawImage(checkImage, 580, 917, 30, 30);
                                    page.Graphics.DrawString(610, 946, app.PatientHistory.LowerBodyWeaknessDescription);
                                    break;
                            }

                        if (app.PatientHistory.LowerBodyPainType != null)
                            switch (app.PatientHistory.LowerBodyPainType)
                            {
                                case "Mild": page.Graphics.DrawImage(checkImage, 195, 975, 30, 30);
                                    break;

                                case "Moderate": page.Graphics.DrawImage(checkImage, 305, 975, 30, 30);
                                    page.Graphics.DrawString(330, 1000, app.PatientHistory.LowerBodyPainDescription);
                                    break;

                                case "Severe": page.Graphics.DrawImage(checkImage, 580, 975, 30, 30);
                                    page.Graphics.DrawString(610, 1003, app.PatientHistory.LowerBodyPainDescription);
                                    break;
                            }

                        if (app.PatientHistory.LowerBodyRangeOfMotionType != null)
                            switch (app.PatientHistory.LowerBodyRangeOfMotionType)
                            {
                                case "Mild": page.Graphics.DrawImage(checkImage, 195, 1034, 30, 30);
                                    break;

                                case "Moderate": page.Graphics.DrawImage(checkImage, 305, 1034, 30, 30);
                                    page.Graphics.DrawString(330, 1056, app.PatientHistory.LowerBodyRangeOfMotionDescription);
                                    break;

                                case "Severe": page.Graphics.DrawImage(checkImage, 580, 1034, 30, 30);
                                    page.Graphics.DrawString(610, 1058, app.PatientHistory.LowerBodyRangeOfMotionDescription);
                                    break;
                            }


                        page.Graphics.Flush();
                        #endregion



                        #region Page 4
                        //page 5
                        page = document.Pages[3];

                        page.Graphics.Font = font;
                        page.Graphics.Brush = Siberix.Sparkle.Graphics.Brushes.Black;

                        //background
                        image = new Siberix.Sparkle.Graphics.Image(await page5.OpenStreamForReadAsync());
                        page.Graphics.DrawImage(image, 1, 1, image.Width, image.Height);

                        //signature                     
                        if (signStream != Stream.Null)
                        {
                            var signImage = new Siberix.Sparkle.Graphics.Image(signStream);
                            page.Graphics.DrawImage(signImage, 370, 925, signImage.Width * 0.27F, signImage.Height * 0.27F);
                        }
                        var smallerFont = new Siberix.Sparkle.Graphics.Font(await DBHelper.GetResourceStreamAsync(@"Datas\calibrib.ttf"), 12);

                        //Order Prescription Details
                        // page.Graphics.DrawString(677, 191, DateTime.Today.ToString("dd MMM yyyy"));
                        // page.Graphics.DrawString(364, 315, app.SettingsData.Name);
                        //page.Graphics.DrawString(376, 392, data.OrderItem == null ? string.Empty : data.OrderItem.Name);
                        page.Graphics.Font = smallerFont;
                        page.Graphics.DrawString(370, 1032, DateTime.Today.ToString("dd MMM yyyy"));

                        int ICSCount = 1;
                        var nerologyList = app.MobilityData.NeurologicalCondition as ObservableCollection<CheckListItemSource>;

                        if (nerologyList != null)
                            foreach (var neurology in nerologyList)
                            {
                                if (ICSCount < 8)
                                {
                                    page.Graphics.DrawString(380, (619 + (ICSCount * 18)), ((CheckListItemSource)neurology).ValueBeforePrecession);
                                    page.Graphics.DrawString(435, (619 + (ICSCount * 18)), ((CheckListItemSource)neurology).ValueAfterPrecession);
                                    page.Graphics.DrawString(565, (619 + (ICSCount * 18)), ((CheckListItemSource)neurology).Name);

                                    ICSCount++;
                                }
                            }

                        var myopathyList = app.MobilityData.Myopathy as ObservableCollection<CheckListItemSource>;

                        if (myopathyList != null)
                            foreach (var myopathy in myopathyList)
                            {
                                if (ICSCount < 8)
                                {
                                    page.Graphics.DrawString(380, (619 + (ICSCount * 18)), ((CheckListItemSource)myopathy).ValueBeforePrecession);
                                    page.Graphics.DrawString(435, (619 + (ICSCount * 18)), ((CheckListItemSource)myopathy).ValueAfterPrecession);
                                    page.Graphics.DrawString(565, (619 + (ICSCount * 18)), ((CheckListItemSource)myopathy).Name);

                                    ICSCount++;
                                }
                            }

                        var congenitalSkeletalList = app.MobilityData.CongenitalSkeletal as ObservableCollection<CheckListItemSource>;
                        if (congenitalSkeletalList != null)
                            foreach (var congenitalSkeletal in congenitalSkeletalList)
                            {
                                if (ICSCount < 8)
                                {
                                    page.Graphics.DrawString(380, (619 + (ICSCount * 18)), ((CheckListItemSource)congenitalSkeletal).ValueBeforePrecession);
                                    page.Graphics.DrawString(435, (619 + (ICSCount * 18)), ((CheckListItemSource)congenitalSkeletal).ValueAfterPrecession);
                                    page.Graphics.DrawString(565, (619 + (ICSCount * 18)), ((CheckListItemSource)congenitalSkeletal).Name);

                                    ICSCount++;
                                }
                            }

                        page.Graphics.DrawString(400, 850, app.PrescriptionData.LON);

                        //if (data.LON != null)
                        //    page.Graphics.DrawString(345, 841, data.LON);
                        page.Graphics.DrawString(350, 1050, DateTime.Today.ToString("dd MMM yyyy"));


                        //page.Graphics.DrawString(341, 937, (data.IsOMAmbulatory ? "Yes" : "No") + ", " + data.NoteAmbulatory);
                        //page.Graphics.DrawString(284, 450, (data.IsOMGait ? "Yes" : "No") + ", " + data.NoteGait);
                        //page.Graphics.DrawString(284, 470, (data.IsOMAssistance ? "Yes" : "No") + ", " + data.NoteAssistance);
                        //page.Graphics.DrawString(3401030, 490, (data.IsOMMotion ? "Yes" : "No") + ", " + data.NoteMotion);

                        //mrdls
                        var mrdl = "";
                        mrdl += (data.IsBathing ? "Bathing," : "");
                        mrdl += (data.IsDressing ? "Dressing," : "");
                        mrdl += (data.IsFeeding ? "Feeding," : "");
                        mrdl += (data.IsGrooming ? "Grooming," : "");
                        mrdl += (data.IsToileting ? "Toileting," : "");

                        //page.Graphics.DrawString(136, 560, mrdl);
                        //page.Graphics.DrawString(50, 588, data.MridlReason);

                        //page.Graphics.DrawString(160, 618, (data.IsCane ? "Cane," : "") + (data.IsWalker ? "Walker," : ""));

                        //page.Graphics.DrawString(210, 685, (data.IsMWC ? "Yes" : "No"));

                        //page.Graphics.DrawString(220, 870, (data.IsPMDYes ? "Yes" : "No"));

                        page.Graphics.Flush();
                        #endregion

                        document.Generate(stream);
                        await stream.FlushAsync();

                    });
                }
            }
            return this._pdf;
        }

        private static int FillSymptomsSection(ObservableCollection<string> collection, Siberix.Sparkle.PDF.IPage page, ref int sympYCoordinate, ref int sympXCoordinate)
        {
            foreach (var item in collection)
            {
                sympYCoordinate += 20;
                page.Graphics.DrawEllipse(sympXCoordinate, sympYCoordinate + 5, 10, 10, Siberix.Sparkle.Graphics.PaintMode.Fill);
                page.Graphics.DrawString(sympXCoordinate + 15, sympYCoordinate, item);
            }
            return sympYCoordinate;
        }

        /// <summary>
        /// First Generate the signature 
        /// </summary>
        /// <returns></returns>
        //private async Task<StorageFile> GenerateSignature()
        //{
        //    if (this._signature == null)
        //    {
        //        var data = this.wView.InvokeScript("getImageData", null);
        //        data = data.Replace("data:image/png;base64,", "");
        //        var bytes = System.Convert.FromBase64String(data);

        //        var storageItemAccessList = StorageApplicationPermissions.FutureAccessList;

        //        this._signature = await ApplicationData.Current.LocalFolder.CreateFileAsync(@"Data\sign.png", CreationCollisionOption.ReplaceExisting);

        //        using (IRandomAccessStream fileStream = await this._signature.OpenAsync(FileAccessMode.ReadWrite))
        //        {
        //            using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
        //            {
        //                using (DataWriter dataWriter = new DataWriter(outputStream))
        //                {
        //                    //TODO: Replace "Bytes" with the type you want to write.
        //                    dataWriter.WriteBytes(bytes);
        //                    await dataWriter.StoreAsync();
        //                    dataWriter.DetachStream();
        //                }

        //                await outputStream.FlushAsync();
        //            }
        //        }

        //    }
        //    return this._signature;
        //}
        #endregion

        #region Other Methods

        private async Task<Stream> GetLocalResource(string fileName)
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                return stream.AsStreamForWrite();
            }
            catch (Exception)
            {
                return Stream.Null;
            }
        }

        private async Task WriteDataToXML()
        {
            try
            {
                var data = (PrescriptionData)this.DefaultViewModel["PrescriptionData"];
                var folder = KnownFolders.DocumentsLibrary;
                var file = await folder.CreateFileAsync("data.xml", CreationCollisionOption.ReplaceExisting);
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    var doc = new XDocument(
                               new XElement("Data",
                                   new XElement("OrderItem", data.OrderItem == null ? string.Empty : data.OrderItem.Name),
                                   new XElement("Diagnosis", data.Diagnosis ?? string.Empty),
                                   new XElement("PrescriptionId", this._prescriptionId)
                                   )
                               );

                    doc.Save(stream);
                    await stream.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                Util.HandleException(ex, ex.Message);
            }
        }

        private async Task SendFile(StorageFile file)
        {
            var srv = ((App)Application.Current).ServiceHelper;
            while (true)
            {
                try
                {
                    await srv.AddDocumentToPrescription(this._prescriptionId, file);
                }
                catch (Exception)
                {
                    var dialog = new MessageDialog("Unable to upload File. Retry?");

                    bool? result = null;
                    dialog.Commands.Add(
                       new UICommand("Yes", new UICommandInvokedHandler((cmd) => result = true)));
                    dialog.Commands.Add(
                       new UICommand("Cancel", new UICommandInvokedHandler((cmd) => result = false)));

                    //await dialog.ShowAsync();
                    if (result == true)
                    {
                        // do something    
                    }

                }

            }

        }
        #endregion

        #region Data Sharing
        private async void ShareStorageItemsHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = "Order Prescription";
            request.Data.Properties.Description = "The Final Order Prescription";

            // Because we are making async calls in the DataRequested event handler,
            // we need to get the deferral first.
            DataRequestDeferral deferral = request.GetDeferral();

            // Make sure we always call Complete on the deferral.
            try
            {
                var pdf = await this.GeneratePdf();

                List<IStorageItem> storageItems = new List<IStorageItem>();
                storageItems.Add(pdf);

                request.Data.SetStorageItems(storageItems);
            }
            finally
            {
                deferral.Complete();
            }
        }
        #endregion

        string GetYesNo(bool value)
        {
            if (value)
                return "Y";
            else
                return "N";
        }
    }
}
