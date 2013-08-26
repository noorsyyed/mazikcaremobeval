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
    public sealed partial class CongenitalSkeletalDeformity : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public CongenitalSkeletalDeformity()
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
            this.gvCongenitalSkeletalDeformities.ItemsSource = new ObservableCollection<CheckListItemSource>() 
            {
               new CheckListItemSource(){Id="323.72", Name ="Other congenital anomalies of limbs",ValueBeforePrecession="323", ValueAfterPrecession="72", FieldName="Other congenital anomalies of limbs 755.50-755.9"},
               new CheckListItemSource(){Id="334.0", Name ="Congenital dislocation of hip",ValueBeforePrecession="334", ValueAfterPrecession="0", FieldName="Congenital dislocation of hip 754.30-754.35"},
               new CheckListItemSource(){Id="333.6", Name="Osteogenesis imperfecta",ValueBeforePrecession="333", ValueAfterPrecession="6", FieldName="Osteogenesis imperfecta 756.51"},
               new CheckListItemSource(){Id="357.0", Name="Spina bifida",ValueBeforePrecession="357", ValueAfterPrecession="0", FieldName="Spina bifida 741.00-741.93"},
               new CheckListItemSource(){Id="342.0", Name="Dwarfism, NEC",ValueBeforePrecession="342", ValueAfterPrecession="0", FieldName="Dwarfism, NEC  259.4"},
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
            var list = new ObservableCollection<CheckListItemSource>();
            foreach (CheckListItemSource str in this.gvCongenitalSkeletalDeformities.SelectedItems)
            {
                list.Add(str);
            }

            ((MobilityData)this.DefaultViewModel["MobilityData"]).CongenitalSkeletal = list;
            this.Frame.Navigate(typeof(DiagnosisCondition));
        }
    }
}
