using MazikCare.MobEval.Common;
using MazikCare.MobEval.Datas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class POCPage : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public POCPage()
        {
            this.InitializeComponent();
            ObservableCollection<Patient> patientList = new ObservableCollection<Patient>();

            patientList.Add(new Patient() { Name = "James",PhoneNumber="989898343",RoomNumber="101"});
            patientList.Add(new Patient() { Name = "Rita", PhoneNumber = "989845343", RoomNumber = "102" });
            patientList.Add(new Patient() { Name = "Meeta", PhoneNumber = "9893458343", RoomNumber = "103" });
            patientList.Add(new Patient() { Name = "Bata", PhoneNumber = "9898945643", RoomNumber = "104" });
            patientList.Add(new Patient() { Name = "Henry", PhoneNumber = "9898943443", RoomNumber = "105" });
            patientList.Add(new Patient() { Name = "Jackson", PhoneNumber = "9898546343", RoomNumber = "106" });
            patientList.Add(new Patient() { Name = "Jill", PhoneNumber = "9898984353", RoomNumber = "107" });
            patientList.Add(new Patient() { Name = "Jakes", PhoneNumber = "98989843533", RoomNumber = "108" });
            patientList.Add(new Patient() { Name = "Billy", PhoneNumber = "98989845653", RoomNumber = "109" });

            //this.gvInGrid.ItemsSource = patientList;
            //this.gvOutGrid.ItemsSource = patientList;
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

        private void LoadApp_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
