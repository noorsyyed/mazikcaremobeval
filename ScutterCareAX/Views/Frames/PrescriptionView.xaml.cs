using MazikCare.MobEval.Models;
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

namespace MazikCare.MobEval.Views.Frames
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PrescriptionView : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public PrescriptionView()
        {
            this.InitializeComponent();
            Loaded += PrescriptionView_Loaded;
        }

        void PrescriptionView_Loaded(object sender, RoutedEventArgs e)
        {
            this.DefaultViewModel["PrescriptionList"] = new ObservableCollection<Prescription>
            {
                new Prescription{Drug = "Marvelon 21",Dosage="1",Direction="Take 1 tablet once daily continous"},
                new Prescription{Drug = "Spirulina",Dosage="1/2",Direction="Take 1/2 tablet at bed time"},
                new Prescription{Drug = "Rantac 300",Dosage="1",Direction="twise daily"},
                new Prescription{Drug = "Pan D",Dosage="1",Direction="Take 1 daily before meal"},

            };
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var list = (ObservableCollection<Prescription>)this.DefaultViewModel["PrescriptionList"];
            list.Add(new Prescription());
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (this.PrescriptionGrid.SelectedItem != null)
            {

                var list = (ObservableCollection<Prescription>)this.DefaultViewModel["PrescriptionList"];
                list.Remove((Prescription)this.PrescriptionGrid.SelectedItem);
            }
        }


    }
}
