
using ModernUI.Toolkit.Data.Charting.Charts.Series;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PatientDetails : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public PatientDetails()
        {
            this.InitializeComponent();

            List<NameValueItem> items = new List<NameValueItem>();
            items.Add(new NameValueItem() { Name = "Jul", Value = 4 });
            items.Add(new NameValueItem() { Name = "Aug", Value = 5 });
            items.Add(new NameValueItem() { Name = "Sep", Value = 2 });
            items.Add(new NameValueItem() { Name = "Oct", Value = 1 });
            items.Add(new NameValueItem() { Name = "Nov", Value = 3 });

            //((ColumnSeries)Chart.Series[0]).ItemsSource = items;
            //((LineSeries)LineChart.Series[0]).ItemsSource = items;

            //LoadMap();
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

        private void Demog_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientDemog));
        }

        private void Visit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientVisitReason));
        }

        private void Plan_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientPlan));
        }

        private void Evol_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientEvolution));
        }

        private void Asses_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientAssesment));
        }

        private void Presc_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientPrescription));
        }

        private void Physical_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(PhysicalExamReport));
            this.Frame.Navigate(typeof(DrawImageView), "ms-appx:///Assets/physical_report.png");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderPrescription));
        }

        private void Assesment_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AssesmentDetail));
        }

        private void MRIImage_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var imgData = ((Image)sender).Tag;
            this.Frame.Navigate(typeof(MRIDetails), imgData);
        }

        private void Cardio_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DrawImageView), "ms-appx:///Assets/card_resp_report.png");
        }



        //#region Bing Map Navigation

        //Geolocator geolocator;
        //Pushpin MyPushPin;
        //Location location;
        //string URL;
        //double FromLatitude, FromLongitude;

        //private async void LoadMap()
        //{
        //    progressRing1.IsActive = true;
        //    try
        //    {
        //        URL = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=NewYork&wp.1=NewYork&optmz=distance&rpo=Points&key=Alro8lVmxLJs9TJBJQWY1LISuFTLoc9Ubjv6ZEgPN5BK6qvA-GBVCl_VMNTU3ad3";
        //        //URL = "http://dev.virtualearth.net/REST/v1/Locations/US/adminDistrict/postalCode/locality/addressLine?includeNeighborhood=includeNeighborhood&maxResults=maxResults&key=Alro8lVmxLJs9TJBJQWY1LISuFTLoc9Ubjv6ZEgPN5BK6qvA-GBVCl_VMNTU3ad3";

        //        Uri geocodeRequest = new Uri(URL);
        //        BingMapsRESTService.Response r = await GetResponse(geocodeRequest);

        //        geolocator = new Geolocator();
        //        MyPushPin = new Pushpin();

        //        FromLatitude = ((BingMapsRESTService.Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates[0][0];
        //        FromLongitude = ((BingMapsRESTService.Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates[0][1];

        //        location = new Location(FromLatitude, FromLongitude);
        //        MapLayer.SetPosition(MyPushPin, location);
        //        MyMap.Children.Add(MyPushPin);
        //        //MyMap.SetView(location, 15.0f);

        //        MapPolyline routeLine = new MapPolyline();
        //        routeLine.Locations = new LocationCollection();
        //        routeLine.Color = Windows.UI.Colors.Blue;
        //        routeLine.Width = 5.0;
        //        // Retrieve the route points that define the shape of the route.
        //        int bound = ((BingMapsRESTService.Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates.GetUpperBound(0);
        //        for (int i = 0; i < bound; i++)
        //        {
        //            routeLine.Locations.Add(new Location
        //            {
        //                Latitude = ((BingMapsRESTService.Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates[i][0],
        //                Longitude = ((BingMapsRESTService.Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates[i][1]
        //            });
        //        }
        //        MapShapeLayer shapeLayer = new MapShapeLayer();
        //        shapeLayer.Shapes.Add(routeLine);
        //        MyMap.ShapeLayers.Add(shapeLayer);
        //        MyMap.ZoomLevel = 11;
        //        MyMap.SetView(routeLine.Locations[0]);

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    progressRing1.IsActive = false;
        //}

        //void retry_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadMap();
        //}

        //private async Task<BingMapsRESTService.Response> GetResponse(Uri uri)
        //{
        //    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        //    var response = await client.GetAsync(uri);
        //    using (var stream = await response.Content.ReadAsStreamAsync())
        //    {
        //        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BingMapsRESTService.Response));
        //        return ser.ReadObject(stream) as BingMapsRESTService.Response;
        //    }
        //}

        //#endregion
    }


    public class NameValueItem
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public NameValueItem()
        {
        }
    }
}
