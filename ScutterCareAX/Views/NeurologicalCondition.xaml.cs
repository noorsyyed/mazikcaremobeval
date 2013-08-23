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
    public sealed partial class NeurologicalCondition : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public NeurologicalCondition()
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
            this.gvNeurologicalConditionsGroupA.ItemsSource = new ObservableCollection<CheckListItemSource>() 
            {
               new CheckListItemSource(){Id="331.0", Name ="Alzehimer's disease",ValueBeforePrecession="331", ValueAfterPrecession="0", FieldName="Alzehimer's disease  331.0"},
               new CheckListItemSource(){Id="335.20", Name ="Amotrophic lateral sclerosis(ALS)",ValueBeforePrecession="335", ValueAfterPrecession="20", FieldName="Congenital dislocation of hip  335.20"},
               new CheckListItemSource(){Id="335.9", Name="Anterior horn cell disease, unspecified",ValueBeforePrecession="335", ValueAfterPrecession="9", FieldName="Anterior horn cell disease, unspecified  335.9"},
               new CheckListItemSource(){Id="334.3", Name="Other cerebellar ataxia",ValueBeforePrecession="334", ValueAfterPrecession="3", FieldName="Other cerebellar ataxia  334.3"},
               new CheckListItemSource(){Id="342.0", Name="Flaccid hemiplegia",ValueBeforePrecession="342", ValueAfterPrecession="0", FieldName="Flaccid hemiplegia  342.0"},
            };
            this.gvNeurologicalConditionsGroupB.ItemsSource = new ObservableCollection<CheckListItemSource>() 
            {
               new CheckListItemSource(){Id="343.1", Name ="Hemiplegic, Congenital hemiplegia",ValueBeforePrecession="343", ValueAfterPrecession="1", FieldName="Hemiplegic, Congenital hemiplegia  343.1"},
               new CheckListItemSource(){Id="343.2", Name ="Quadriplegic, Tetraplegic",ValueBeforePrecession="343", ValueAfterPrecession="2", FieldName="Quadriplegic, Tetraplegic  343.2"},
               new CheckListItemSource(){Id="343.3", Name="Monoplegic",ValueBeforePrecession="343", ValueAfterPrecession="3", FieldName="Monoplegic  343.3"},
               new CheckListItemSource(){Id="343.4", Name="Infantile hemiplegia",ValueBeforePrecession="343", ValueAfterPrecession="4", FieldName="Infantile hemiplegia  343.4"},
               new CheckListItemSource(){Id="343.8", Name="Other specified infantile cerebral palsy",ValueBeforePrecession="343", ValueAfterPrecession="8", FieldName="Other specified infantile cerebral palsy  343.8"},
            };
            this.gvNeurologicalConditionsGroupC.ItemsSource = new ObservableCollection<CheckListItemSource>() 
            {
               new CheckListItemSource(){Id="342.1", Name ="Spastic hemiplegia",ValueBeforePrecession="342", ValueAfterPrecession="1", FieldName="Spastic hemiplegia  342.1"},
               new CheckListItemSource(){Id="342.8", Name ="Other specified hemiplegia",ValueBeforePrecession="342", ValueAfterPrecession="8", FieldName="Other specified hemiplegia  342.8"},
               new CheckListItemSource(){Id="342.9", Name="Hemiplegia, unspecified",ValueBeforePrecession="342", ValueAfterPrecession="9", FieldName="Hemiplegia, unspecified  342.9"},
               new CheckListItemSource(){Id="334.1", Name="Hereditary spastic  paraplegia",ValueBeforePrecession="334", ValueAfterPrecession="1", FieldName="Hereditary spastic  paraplegia  334.1"},
               new CheckListItemSource(){Id="333.4", Name="Huntington's chorea",ValueBeforePrecession="333", ValueAfterPrecession="4", FieldName="Huntington's chorea  333.4"},
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
            if(gvNeurologicalConditionsGroupA.SelectedItems!=null)
                foreach (CheckListItemSource str in this.gvNeurologicalConditionsGroupA.SelectedItems)
            {
                list.Add(str);
            }
            if (gvNeurologicalConditionsGroupB.SelectedItems != null)
                foreach (CheckListItemSource str in this.gvNeurologicalConditionsGroupB.SelectedItems)
                {
                    list.Add(str);
                }
            if (gvNeurologicalConditionsGroupC.SelectedItems != null)
                foreach (CheckListItemSource str in this.gvNeurologicalConditionsGroupC.SelectedItems)
                {
                    list.Add(str);
                }

            ((MobilityData)this.DefaultViewModel["MobilityData"]).NeurologicalCondition = list;
            this.Frame.Navigate(typeof(DiagnosisCondition));
        }
    }
}
