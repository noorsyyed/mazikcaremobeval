using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AssesmentHistory : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public AssesmentHistory()
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

        private void Walk_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WalkStatuses));
        }

        private void DGPastMedHist_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.PastMedicalHistoryList==null)
            {
                app.PastMedicalHistoryList = new System.Collections.ObjectModel.ObservableCollection<string>();
            }
            else
            {
                app.PastMedicalHistoryList.Clear();
            }
            foreach (string item in this.DGPastMedHist.SelectedItems)
            {
                app.PastMedicalHistoryList.Add(item);
            }
        }

        private void DGSocialHist_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.SocialHistoryList==null)
            {
                app.SocialHistoryList = new System.Collections.ObjectModel.ObservableCollection<string>();
            }
            else
            {
                app.SocialHistoryList.Clear();
            }
            foreach (string item in DGSocialHist.SelectedItems)
            {
                app.SocialHistoryList.Add(item);
            }
        }

        private void DGEndocrineDisorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.EndocrineDisorderList==null)
            {
                app.EndocrineDisorderList = new System.Collections.ObjectModel.ObservableCollection<string>();
            }
            else
            {
                app.EndocrineDisorderList.Clear();
            }
            foreach (string item in DGEndocrineDisorder.SelectedItems)
            {
                app.EndocrineDisorderList.Add(item);
            }
        }
    }
}
