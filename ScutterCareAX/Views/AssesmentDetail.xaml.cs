using MazikCare.MobEval.Views.Frames;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AssesmentDetail : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public AssesmentDetail()
        {
            this.InitializeComponent();
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
            frame.Navigate(typeof(AssesmentDiagnosis));
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


        private void Tab_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            foreach (TextBlock item in this.spTabs.Children)
            {
                item.Foreground = new SolidColorBrush(Colors.White);
            }
            var item1 = (TextBlock)sender;
            item1.Foreground = new SolidColorBrush(Color.FromArgb(255, 253, 189, 81));

            Type toNavigate;
            switch (item1.Text)
            {
                case "Symptom/Analysis":
                    toNavigate = typeof(AssesmentDiagnosis);
                    break;
                case "Evaluation":
                    toNavigate = typeof(AssessmentEvaluation);
                    break;
                case "Assessment":
                    toNavigate = typeof(AssessmentEnquiry);
                    break;
                case "Plan":
                    toNavigate = typeof(AssessmentPlan);
                    break;
                case "Physical":
                    toNavigate = typeof(AssesmentPhysical);
                    break;
                case "History":
                    toNavigate = typeof(AssesmentHistory);
                    break;
                case "Prescription":
                    toNavigate = typeof(PrescriptionView);
                    break;
                case "Mobility":
                    toNavigate = typeof(AssesmentMobility);
                    break;
                default:
                    toNavigate = typeof(AssesmentDiagnosis);
                    break;
            }

            frame.Navigate(toNavigate);
        }

        private void OrderPrescription_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderPrescription));
        }
    }
}
