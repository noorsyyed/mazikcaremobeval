﻿using MazikCare.MobEval.Datas;
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
    public sealed partial class Myopathy : MazikCare.MobEval.Common.LayoutAwarePage
    {
        public Myopathy()
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
            this.gvMyopathy.ItemsSource = new ObservableCollection<CheckListItemSource>() 
            {
               new CheckListItemSource(){Id="335.11", Name ="Kugelberg-Welander disease",ValueBeforePrecession="335", ValueAfterPrecession="11", FieldName="Kugelberg-Welander disease  335.11"},
               new CheckListItemSource(){Id="330.0", Name ="Leukodystrophy",ValueBeforePrecession="330", ValueAfterPrecession="0", FieldName="Leukodystrophy  330.0"},
               new CheckListItemSource(){Id="335.29", Name="Motor neuron  disease, other",ValueBeforePrecession="335", ValueAfterPrecession="29", FieldName="Motor neuron  disease, other  335.29"},
               new CheckListItemSource(){Id="323.63", Name="Postinfectious myelitis",ValueBeforePrecession="323", ValueAfterPrecession="63", FieldName="Postinfectious myelitis  323.63"},
               new CheckListItemSource(){Id="332.0", Name="Parkinson's disease",ValueBeforePrecession="332", ValueAfterPrecession="0", FieldName="Parkinson's disease  332.0"},
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
            foreach (CheckListItemSource str in this.gvMyopathy.SelectedItems)
            {
                list.Add(str);
            }

            ((MobilityData)this.DefaultViewModel["MobilityData"]).Myopathy = list;
            this.Frame.Navigate(typeof(DiagnosisCondition));
        }
    }
}
