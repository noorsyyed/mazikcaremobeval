using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MazikCare.MobEval.Controls
{
    public sealed partial class PatientInfoBox : UserControl
    {
        public PatientInfoBox()
        {
            this.InitializeComponent();
        }

        private async void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            this.DataContext = app;
            try
            {
                this.imgPatient.Source = await app.ServiceHelper.GetPatientImage(app.Patient.RecId);
            }
            catch (Exception)
            {
            }
        }
    }
}
