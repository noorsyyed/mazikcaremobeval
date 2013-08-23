using System;
using System.Collections.Generic;
using MazikCare.MobEval.Datas;
using MazikCare.MobEval.Views;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CompleteMainPage : MazikCare.MobEval.Common.LayoutAwarePage
    {
        XmlDocument tileXml;
        public static bool FromLast = false;
        public CompleteMainPage()
        {
            InitializeComponent();
            notification_tile.Begin();
            alerts_tile.Begin();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 12);
            timer.Tick += timer_Tick;
            timer.Start();

            //workOrderData = new WorkOrderData();
            //if (!FromLast)
            //{
            //    ItemListView.ItemsSource = workOrderData.Collection;
            //    this.btnReset.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //}
            //else
            //{
            //    ItemListView.ItemsSource = workOrderData.Collection.Skip(1);
            //    this.btnReset.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //}
            //ItemListView.SelectedIndex = 0;
            //FromLast = true;
        }

        #region Live Tile Code

        void timer_Tick(object sender, object e)
        {
            try
            {
                tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideBlockAndText02);

                XmlNodeList tileTextAttributes = tileXml.GetElementsByTagName("text");
                tileTextAttributes[0].InnerText = "Today's Patients";
                tileTextAttributes[1].InnerText = "5";
                //tileTextAttributes[1].InnerText = ((WorkOrder)this.DefaultViewModel["WorkOrder"]).WOCount.ToString();

                var tileNotification = new TileNotification(tileXml);
                tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(6);

                TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
            }
            catch
            {
            }
        }

        #endregion

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

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MazikCare.MobEval.Views.SettingsData));
        }

        private void WO_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                //this.Frame.Navigate(typeof(WorkOrderDetails));
            }
        }

        private void ItemListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(WorkOrderDetails));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //((WorkOrder)this.DefaultViewModel["WorkOrder"]).Status = "Open";
            //workOrderData = new WorkOrderData();
            //ItemListView.ItemsSource = workOrderData.Collection;
            //ItemListView.SelectedIndex = 0;
            //this.btnReset.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        
        private void ViewAll_PointerReleased_1(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientList));
        }

        private void Grid_PointerReleased_1(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientDetails));
        }

        private async void pageRoot_Loaded_1(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            if (app.SettingsData.IsSyncWithAX)
            {
                var srv = app.ServiceHelper;
                var prosp = await srv.GetAllProspects();

                this.lblPatient1.Text = prosp[1].parmName;
                try
                {
                    this.imgPatient1.Source = await srv.GetPatientImage(prosp[1].parmRecId);
                }
                catch (Exception)
                {
                }


                this.lblPatient2.Text = prosp[2].parmName;
                try
                {
                    this.imgPatient2.Source = await srv.GetPatientImage(prosp[2].parmRecId);
                }
                catch (Exception)
                {
                }

                this.lblPatient3.Text = prosp[3].parmName;
                try
                {
                    this.imgPatient3.Source = await srv.GetPatientImage(prosp[3].parmRecId);
                }
                catch (Exception)
                {
                }

                this.lblPatient4.Text = prosp[4].parmName;
                try
                {
                    this.imgPatient4.Source = await srv.GetPatientImage(prosp[4].parmRecId);
                }
                catch (Exception)
                {
                }
                //this.lblPatient5.Text = prosp[5].parmName;
                //try
                //{
                //    this.imgPatient5.Source = await srv.GetPatientImage(prosp[5].parmRecId);
                //}
                //catch (Exception)
                //{
                //}
            }

        }
    }
}
