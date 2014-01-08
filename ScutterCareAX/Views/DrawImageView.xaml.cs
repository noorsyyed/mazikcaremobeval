using System;
using System.Collections.Generic;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.Imaging;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MazikCare.MobEval.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DrawImageView : MazikCare.MobEval.Common.LayoutAwarePage
    {
        #region Private Vars
        private InkManager _inkManager;
        private uint _penID;
        private uint _touchID;
        private Point _previousContactPt;
        private Point currentContactPt;
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private WriteableBitmap _image;
        private string _fileName;
        private Color _brushColor;
        #endregion
        public DrawImageView()
        {
            this.InitializeComponent();
            this._inkManager = new InkManager();

            //#FF003f82
            this._brushColor = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
            this.Loaded += DrawImageView_Loaded;
        }

        void DrawImageView_Loaded(object sender, RoutedEventArgs e)
        {
            var height = Convert.ToInt32(this.panelcanvas.ActualHeight);
            var width = Convert.ToInt32(this.panelcanvas.ActualWidth);

            this._image = BitmapFactory.New(width, height);
            this._image.GetBitmapContext();
        }


        #region Overrides
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

            this.DefaultViewModel["AppTitle"] = string.Empty;
            if ("ms-appx:///Assets/physical_report.png" == navigationParameter)
            {
                this.DefaultViewModel["AppTitle"] = "MasculoSkeletol Details";
            }
            else
            {
                this.DefaultViewModel["AppTitle"] = "Cardio Respiratory Report";
            }
            //var page = ("ms-appx-web:///Data/" + (string)navigationParameter);
            //this.wView.Navigate(new Uri(page));       
            this._fileName = (string)navigationParameter;
            this.panelcanvas.Background = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(this._fileName)),
                Stretch = Stretch.Fill
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
        #endregion

        #region Panel Codes
        private void panelcanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Get information about the pointer location.
            PointerPoint pt = e.GetCurrentPoint(panelcanvas);
            _previousContactPt = pt.Position;

            // Accept input only from a pen or mouse with the left button pressed. 
            PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
            if (pointerDevType == PointerDeviceType.Pen || pointerDevType == PointerDeviceType.Mouse && pt.Properties.IsLeftButtonPressed)
            {
                // Pass the pointer information to the InkManager.
                _inkManager.ProcessPointerDown(pt);
                _penID = pt.PointerId;
                e.Handled = true;
            }

            else if (pointerDevType == PointerDeviceType.Touch)
            {
                // Process touch input
                _inkManager.ProcessPointerDown(pt);
                _penID = pt.PointerId;
                e.Handled = true;
            }
        }

        private void panelcanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == _penID)
            {
                Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(panelcanvas);
                

                // Pass the pointer information to the InkManager. 
                _inkManager.ProcessPointerUp(pt);
            }

            else if (e.Pointer.PointerId == _touchID)
            {
                // Process touch input
                PointerPoint pt = e.GetCurrentPoint(panelcanvas);
                

                // Pass the pointer information to the InkManager. 
                _inkManager.ProcessPointerUp(pt);
            }

            _touchID = 0;
            _penID = 0;

            // Call an application-defined function to render the ink strokes.
            e.Handled = true;
        }

        private void panelcanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == _penID)
            {
                PointerPoint pt = e.GetCurrentPoint(panelcanvas);
                // Render a red line on the canvas as the pointer moves. 
                // Distance() is an application-defined function that tests
                // whether the pointer has moved far enough to justify 
                // drawing a new line.
                currentContactPt = pt.Position;
                x1 = _previousContactPt.X;
                y1 = _previousContactPt.Y;
                x2 = currentContactPt.X;
                y2 = currentContactPt.Y;

                if (Distance(x1, y1, x2, y2) > 2.0)
                {
                    Line line = new Line()
                    {
                        X1 = x1,
                        Y1 = y1,
                        X2 = x2,
                        Y2 = y2,
                        StrokeThickness = 5,
                        Stroke = new SolidColorBrush(this._brushColor)
                    };
                    _previousContactPt = currentContactPt;

                    // Draw the line on the canvas by adding the Line object as
                    // a child of the Canvas object.
                    panelcanvas.Children.Add(line);

                    // Pass the pointer information to the InkManager.
                    _inkManager.ProcessPointerUpdate(pt);
                }


                this._image.DrawLine(Convert.ToInt32(x1), Convert.ToInt32(y1), Convert.ToInt32(x2), Convert.ToInt32(y2), this._brushColor);

            }

            else if (e.Pointer.PointerId == _touchID)
            {
                // Process touch input
                PointerPoint pt = e.GetCurrentPoint(panelcanvas);

                // Render a red line on the canvas as the pointer moves. 
                // Distance() is an application-defined function that tests
                // whether the pointer has moved far enough to justify 
                // drawing a new line.
                currentContactPt = pt.Position;
                x1 = _previousContactPt.X;
                y1 = _previousContactPt.Y;
                x2 = currentContactPt.X;
                y2 = currentContactPt.Y;

                if (Distance(x1, y1, x2, y2) > 2.0)
                {
                    Line line = new Line()
                    {
                        X1 = x1,
                        Y1 = y1,
                        X2 = x2,
                        Y2 = y2,
                        StrokeThickness = 4.0,
                        Stroke = new SolidColorBrush(this._brushColor)
                    };
                    _previousContactPt = currentContactPt;

                    // Draw the line on the canvas by adding the Line object as
                    // a child of the Canvas object.
                    panelcanvas.Children.Add(line);

                    // Pass the pointer information to the InkManager.
                    _inkManager.ProcessPointerUpdate(pt);
                }

                using (this._image.GetBitmapContext())
                {
                    this._image.DrawLineAa(Convert.ToInt32(x1), Convert.ToInt32(y1), Convert.ToInt32(x2), Convert.ToInt32(y2), this._brushColor);
                }
            }
        }

        #endregion

        #region Util Functions
        private double Distance(double x1, double y1, double x2, double y2)
        {
            double d = 0;
            d = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return d;
        }
        #endregion

        private async void Save_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var height = Convert.ToInt32(this.panelcanvas.ActualHeight);
            var width = Convert.ToInt32(this.panelcanvas.ActualWidth);

            //save image to buffer
            //var signBuffer = new InMemoryRandomAccessStream();
            //await this._inkManager.SaveAsync(signBuffer);
            //signBuffer.Seek(0);

            //load the two images
            //var background = await BitmapFactory.New(width, height).FromContent(new Uri("ms-appx:///Assets/drawImg1.jpg"));
            var background = await BitmapFactory.New(width, height).FromContent(new Uri(this._fileName));
            //var sign = await BitmapFactory.New(width, height).FromStream(signBuffer);

            //get context for bliting
            using (background.GetBitmapContext())
            {
                //using (this._image.GetBitmapContext())
                //{
                background.Blit
                    (
                    new Rect(0, 0, background.PixelWidth, background.PixelHeight),
                    this._image,
                    new Rect(1, 1, this._image.PixelWidth, this._image.PixelHeight),
                    WriteableBitmapExtensions.BlendMode.Alpha
                    );
                //}
            }

            var filename = Guid.NewGuid() + ".jpg";
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await background.SaveToFile(file, BitmapEncoder.JpegEncoderId);

            var app = (App)Application.Current;
            //   app.SettingsData.DrawImages.Add(file); //save the file in the list

            //  this.Frame.Navigate(typeof(WorkOrderDetails));

            //var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("sign.png", CreationCollisionOption.ReplaceExisting);
            //await this._image.SaveToFile(file, BitmapEncoder.PngEncoderId);
            //await Launcher.LaunchFileAsync(file);

        }

        private void pageRoot_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

    }
}
