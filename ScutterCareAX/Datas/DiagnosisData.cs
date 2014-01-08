using MazikCare.MobEval.Common;
using System.Collections.ObjectModel;

namespace MazikCare.MobEval.Datas
{
    public class DiagnosisData:BindableBase
    {
        private ObservableCollection<string> _painLocation;
        public ObservableCollection<string> PainLocation
        {
            get
            {
                return this._painLocation;
            }
            set
            {
                this.SetProperty(ref this._painLocation, value, "PainLocation");
            }
        }
        
        private ObservableCollection<string> _symptoms;
        public ObservableCollection<string> Symptoms
        {
            get
            {
                return this._symptoms;
            }
            set
            {
                this.SetProperty(ref this._symptoms, value, "Symptoms");
            }
        }

        private ObservableCollection<string> _medicalCondition;
        public ObservableCollection<string> MedicalCondition
        {
            get
            {
                return this._medicalCondition;
            }
            set
            {
                this.SetProperty(ref this._medicalCondition, value, "MedicalCondition");
            }
        }

        private ObservableCollection<string> _mradlStatus;
        public ObservableCollection<string> MradlStatus
        {
            get
            {
                return this._mradlStatus;
            }
            set
            {
                this.SetProperty(ref this._mradlStatus, value, "MradlStatus");
            }
        }

        private ObservableCollection<string> _ambulatoryStatus;
        public ObservableCollection<string> AmbulatoryStatus
        {
            get
            {
                return this._ambulatoryStatus;
            }
            set
            {
                this.SetProperty(ref this._ambulatoryStatus, value, "AmbulatoryStatus");
            }
        }

        private ObservableCollection<string> _povStatus;
        public ObservableCollection<string> PovStatus
        {
            get
            {
                return this._povStatus;
            }
            set
            {
                this.SetProperty(ref this._povStatus, value, "PovStatus");
            }
        }

        private ObservableCollection<string> _walkStatus;
        public ObservableCollection<string> WalkStatus
        {
            get
            {
                return this._walkStatus;
            }
            set
            {
                this.SetProperty(ref this._walkStatus, value, "WalkStatus");
            }
        }        
        
    }
}
