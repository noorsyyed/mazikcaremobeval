using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SettingsData : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public SettingsData()
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;

            if (app.SettingsData.IsSyncWithAX)
            {
                app.SettingsData.Name = app.Patient.Name;
                app.SettingsData.Address = app.Patient.Address;
                app.SettingsData.ContactPhone = app.Patient.PhoneNumber;

                string cityState = string.Empty;

                if (app.Patient.City != null)
                    cityState = app.Patient.City;

                if (app.Patient.State != null)
                    cityState = ", " + app.Patient.State;

                if (app.Patient.Zip != null)
                    cityState = " - " + app.Patient.Zip;

                app.SettingsData.CityState = cityState;
            }

            app.SaveSettings();

            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);

            var elements = toastXml.GetElementsByTagName("text");
            elements[0].AppendChild(toastXml.CreateTextNode("Settings sucessfully saved"));

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);

            this.Frame.Navigate(typeof(MainPage));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
