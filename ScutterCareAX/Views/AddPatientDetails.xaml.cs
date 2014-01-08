using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AddPatientDetails : MazikCare.MobEval.Common.LayoutAwarePage
    {
        SolidColorBrush selectedTabColor = new SolidColorBrush(Color.FromArgb(255,64,175,73));
        public AddPatientDetails()
        {
            this.InitializeComponent();
            txtDemographic.Foreground = selectedTabColor;
            this.patientFrame.Navigate(typeof(PatientDemog));
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

        private void txtDemographic_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            txtDemographic.Foreground = selectedTabColor;

            txtVisitReason.Foreground = new SolidColorBrush(Colors.Black);
            txtPlan.Foreground = new SolidColorBrush(Colors.Black);
            txtEvaluation.Foreground = new SolidColorBrush(Colors.Black);
            txtAssesment.Foreground = new SolidColorBrush(Colors.Black);
            txtPrescription.Foreground = new SolidColorBrush(Colors.Black);

            this.patientFrame.Navigate(typeof(PatientDemog));
        }

        private void txtVisitReason_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            txtVisitReason.Foreground = selectedTabColor;

            txtDemographic.Foreground = new SolidColorBrush(Colors.Black);
            txtPlan.Foreground = new SolidColorBrush(Colors.Black);
            txtEvaluation.Foreground = new SolidColorBrush(Colors.Black);
            txtAssesment.Foreground = new SolidColorBrush(Colors.Black);
            txtPrescription.Foreground = new SolidColorBrush(Colors.Black);

            this.patientFrame.Navigate(typeof(PatientVisitReason));
        }

        private void txtPlan_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            txtPlan.Foreground = selectedTabColor;

            txtVisitReason.Foreground = new SolidColorBrush(Colors.Black);
            txtDemographic.Foreground = new SolidColorBrush(Colors.Black);
            txtEvaluation.Foreground = new SolidColorBrush(Colors.Black);
            txtAssesment.Foreground = new SolidColorBrush(Colors.Black);
            txtPrescription.Foreground = new SolidColorBrush(Colors.Black);

            this.patientFrame.Navigate(typeof(PatientPlan));
        }
        
        private void txtEvaluation_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            txtEvaluation.Foreground = selectedTabColor;

            txtVisitReason.Foreground = new SolidColorBrush(Colors.Black);
            txtPlan.Foreground = new SolidColorBrush(Colors.Black);
            txtDemographic.Foreground = new SolidColorBrush(Colors.Black);
            txtAssesment.Foreground = new SolidColorBrush(Colors.Black);
            txtPrescription.Foreground = new SolidColorBrush(Colors.Black);

            this.patientFrame.Navigate(typeof(PatientEvolution));
        }

        private void txtAssesment_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            txtAssesment.Foreground = selectedTabColor;

            txtVisitReason.Foreground = new SolidColorBrush(Colors.Black);
            txtPlan.Foreground = new SolidColorBrush(Colors.Black);
            txtEvaluation.Foreground = new SolidColorBrush(Colors.Black);
            txtDemographic.Foreground = new SolidColorBrush(Colors.Black);
            txtPrescription.Foreground = new SolidColorBrush(Colors.Black);

            this.patientFrame.Navigate(typeof(PatientAssesment));
        }

        private void txtPrescription_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            txtPrescription.Foreground = selectedTabColor;

            txtVisitReason.Foreground = new SolidColorBrush(Colors.Black);
            txtPlan.Foreground = new SolidColorBrush(Colors.Black);
            txtEvaluation.Foreground = new SolidColorBrush(Colors.Black);
            txtAssesment.Foreground = new SolidColorBrush(Colors.Black);
            txtDemographic.Foreground = new SolidColorBrush(Colors.Black);

            this.patientFrame.Navigate(typeof(PatientPrescription));
        }

        //private void Demog_Click(object sender, RoutedEventArgs e)
        //{
        //    btnDemog.Background = new SolidColorBrush(Colors.LightGreen);
            
        //    btnAssesment.Background = new SolidColorBrush(Colors.Gray);
        //    btnEvaluation.Background = new SolidColorBrush(Colors.Gray);
        //    btnPlan.Background = new SolidColorBrush(Colors.Gray);
        //    btnPrescripton.Background = new SolidColorBrush(Colors.Gray);
        //    btnVisit.Background = new SolidColorBrush(Colors.Gray);

        //    this.patientFrame.Navigate(typeof(PatientDemog));
        //}

        //private void Visit_Click(object sender, RoutedEventArgs e)
        //{
        //    btnVisit.Background = new SolidColorBrush(Colors.LightGreen);

        //    btnDemog.Background = new SolidColorBrush(Colors.Gray);
        //    btnEvaluation.Background = new SolidColorBrush(Colors.Gray);
        //    btnPlan.Background = new SolidColorBrush(Colors.Gray);
        //    btnPrescripton.Background = new SolidColorBrush(Colors.Gray);
        //    btnAssesment.Background = new SolidColorBrush(Colors.Gray);

        //    this.patientFrame.Navigate(typeof(PatientVisitReason));
        //}

        //private void Plan_Click(object sender, RoutedEventArgs e)
        //{
        //    btnPlan.Background = new SolidColorBrush(Colors.LightGreen);

        //    btnAssesment.Background = new SolidColorBrush(Colors.Gray);
        //    btnEvaluation.Background = new SolidColorBrush(Colors.Gray);
        //    btnDemog.Background = new SolidColorBrush(Colors.Gray);
        //    btnPrescripton.Background = new SolidColorBrush(Colors.Gray);
        //    btnVisit.Background = new SolidColorBrush(Colors.Gray);

        //    this.patientFrame.Navigate(typeof(PatientPlan));
        //}

        //private void Evol_Click(object sender, RoutedEventArgs e)
        //{
        //    btnEvaluation.Background = new SolidColorBrush(Colors.LightGreen);

        //    btnAssesment.Background = new SolidColorBrush(Colors.Gray);
        //    btnDemog.Background = new SolidColorBrush(Colors.Gray);
        //    btnPlan.Background = new SolidColorBrush(Colors.Gray);
        //    btnPrescripton.Background = new SolidColorBrush(Colors.Gray);
        //    btnVisit.Background = new SolidColorBrush(Colors.Gray);

        //    this.patientFrame.Navigate(typeof(PatientEvolution));
        //}

        //private void Asses_Click(object sender, RoutedEventArgs e)
        //{
        //    btnAssesment.Background = new SolidColorBrush(Colors.LightGreen);

        //    btnDemog.Background = new SolidColorBrush(Colors.Gray);
        //    btnEvaluation.Background = new SolidColorBrush(Colors.Gray);
        //    btnPlan.Background = new SolidColorBrush(Colors.Gray);
        //    btnPrescripton.Background = new SolidColorBrush(Colors.Gray);
        //    btnVisit.Background = new SolidColorBrush(Colors.Gray);

        //    this.patientFrame.Navigate(typeof(PatientAssesment));
        //}

        //private void Presc_Click(object sender, RoutedEventArgs e)
        //{
        //    btnPrescripton.Background = new SolidColorBrush(Colors.LightGreen);

        //    btnAssesment.Background = new SolidColorBrush(Colors.Gray);
        //    btnEvaluation.Background = new SolidColorBrush(Colors.Gray);
        //    btnPlan.Background = new SolidColorBrush(Colors.Gray);
        //    btnDemog.Background = new SolidColorBrush(Colors.Gray);
        //    btnVisit.Background = new SolidColorBrush(Colors.Gray);

        //    this.patientFrame.Navigate(typeof(PatientPrescription));
        //}


    }
}
