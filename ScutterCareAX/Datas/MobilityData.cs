using MazikCare.MobEval.Common;
using System.Collections.ObjectModel;

namespace MazikCare.MobEval.Datas
{
    public class MobilityData:BindableBase
    {
        private ObservableCollection<CheckListItemSource> _neurologicalCondition;
        public ObservableCollection<CheckListItemSource> NeurologicalCondition
        {
            get
            {
                return this._neurologicalCondition;
            }
            set
            {
                this.SetProperty(ref this._neurologicalCondition, value, "NeurologicalCondition");
            }
        }

        private ObservableCollection<CheckListItemSource> _myopathy;
        public ObservableCollection<CheckListItemSource> Myopathy
        {
            get
            {
                return this._myopathy;
            }
            set
            {
                this.SetProperty(ref this._myopathy, value, "Myopathy");
            }
        }

        private ObservableCollection<CheckListItemSource> _congenitalSkeletal;
        public ObservableCollection<CheckListItemSource> CongenitalSkeletal
        {
            get
            {
                return this._congenitalSkeletal;
            }
            set
            {
                this.SetProperty(ref this._congenitalSkeletal, value, "CongenitalSkeletal");
            }
        }
    }
}
