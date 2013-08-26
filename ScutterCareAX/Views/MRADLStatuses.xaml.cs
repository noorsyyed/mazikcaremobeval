using MazikCare.MobEval.Datas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MRADLStatuses : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public MRADLStatuses()
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
            this.gvGrid.ItemsSource = new List< MRADL>() 
            {
             new MRADL {Key= "Feeding",Value="needs some assistance"},
             new MRADL {Key="Bathing",Value="needs total assistance"},
             new MRADL {Key="Grooming",Value="needs some assistance"},
             new MRADL {Key="Dressing",Value="not assessed"},
             new MRADL {Key="Toileting",Value="needs some assistance"}
             };
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

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            var list = new ObservableCollection<string>();
            foreach (MRADL str in this.gvGrid.SelectedItems)
            {
                list.Add(str.Key);
            }

            ((DiagnosisData)this.DefaultViewModel["DiagnosisData"]).MradlStatus = list;
            this.Frame.Navigate(typeof(AssessmentEnquiry));
        }
    }

    class MRADL
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
