using MazikCare.MobEval.Datas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class AssesmentDiagnosis : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public AssesmentDiagnosis()
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

        private void gvGenitourinary_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.GenitourinarySymptomsList == null)
            {
                app.GenitourinarySymptomsList = new ObservableCollection<string>();
            }
            else
            {
                app.GenitourinarySymptomsList.Clear();
            }
            foreach (string item in this.gvGenitourinary.SelectedItems)
            {
                app.GenitourinarySymptomsList.Add(item);
            }
        }

        private void gvEndocrineSymptoms_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.EndocrineSymptomsList == null)
            {
                app.EndocrineSymptomsList = new ObservableCollection<string>();
            }
            else
            {
                app.EndocrineSymptomsList.Clear();
            }
            foreach (string item in this.gvEndocrineSymptoms.SelectedItems)
            {
                app.EndocrineSymptomsList.Add(item);
            }
        }

        private void gvNeurologicalSymptom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.NeurologicalSymptomList == null)
            {
                app.NeurologicalSymptomList = new ObservableCollection<string>();
            }
            else
            {
                app.NeurologicalSymptomList.Clear();
            }
            foreach (string item in this.gvNeurologicalSymptom.SelectedItems)
            {
                app.NeurologicalSymptomList.Add(item);
            }
        }

       
    }
}
