using MazikCare.MobEval.Common;
using SQLite;


namespace MazikCare.MobEval.Datas
{
    public class PatientPhysicalAssessment : BindableBase
    {
        private string _height;
        public string Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this.SetProperty(ref this._height, value, "Height");
            }
        }

        private string _weight;
        public string Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this.SetProperty(ref this._weight, value, "Weight");
            }
        }

        private string _pulseRate;
        public string PulseRate
        {
            get
            {
                return this._pulseRate;
            }
            set
            {
                this.SetProperty(ref this._pulseRate, value);
            }
        }

        private string _oralTemperature;
        public string OralTemperature
        {
            get
            {
                return this._oralTemperature;
            }
            set
            {
                this.SetProperty(ref this._oralTemperature, value);
            }
        }

        private string _bp;
        public string BP
        {
            get
            {
                return this._bp;
            }
            set
            {
                this.SetProperty(ref this._bp, value, "BP");
            }
        }

        private string _restingPulse;
        public string RestingPulse
        {
            get
            {
                return this._restingPulse;
            }
            set
            {
                this.SetProperty(ref this._restingPulse, value, "RestingPulse");
            }
        }

        private string _exertionPulse;
        public string ExertionPulse
        {
            get
            {
                return this._exertionPulse;
            }
            set
            {
                this.SetProperty(ref this._exertionPulse, value, "ExertionPulse");
            }
        }

        private bool _hasRestBreathShortness;
        public bool HasRestBreathShortness
        {
            get
            {
                return this._hasRestBreathShortness;
            }
            set
            {
                this.SetProperty(ref this._hasRestBreathShortness, value, "HasRestBreathShortness");
            }
        }

        private bool _hasExertionBreathShortness;
        public bool HasExertionBreathShortness
        {
            get
            {
                return this._hasExertionBreathShortness;
            }
            set
            {
                this.SetProperty(ref this._hasExertionBreathShortness, value, "HasExertionBreathShortness");
            }
        }

        private bool _isO2Required;
        public bool IsO2Required
        {
            get
            {
                return this._isO2Required;
            }
            set
            {
                this.SetProperty(ref this._isO2Required, value, "IsO2Required");
            }
        }

        private string _noofLitres;
        public string NoofLitres
        {
            get
            {
                return this._noofLitres;
            }
            set
            {
                this.SetProperty(ref this._noofLitres, value, "NoofLitres");
            }
        }

        private string _o2Sats;
        public string O2Sats
        {
            get
            {
                return this._o2Sats;
            }
            set
            {
                this.SetProperty(ref this._o2Sats, value, "O2Sats");
            }
        }

        private bool _hasCurrentPressureSores;
        public bool HasCurrentPressureSores
        {
            get
            {
                return this._hasCurrentPressureSores;
            }
            set
            {
                this.SetProperty(ref this._hasCurrentPressureSores, value, "HasCurrentPressureSores");
            }
        }

        private bool _hasHistoryPressureSores;
        public bool HasHistoryPressureSores
        {
            get
            {
                return this._hasHistoryPressureSores;
            }
            set
            {
                this.SetProperty(ref this._hasHistoryPressureSores, value, "HasHistoryPressureSores");
            }
        }

        private string _locations;
        public string Locations
        {
            get
            {
                return this._locations;
            }
            set
            {
                this.SetProperty(ref this._locations, value, "Locations");
            }
        }

        private string _stage;
        public string Stage
        {
            get
            {
                return this._stage;
            }
            set
            {
                this.SetProperty(ref this._stage, value, "Stage");
            }
        }

        private bool _canShiftWeight;
        public bool CanShiftWeight
        {
            get
            {
                return this._canShiftWeight;
            }
            set
            {
                this.SetProperty(ref this._canShiftWeight, value, "CanShiftWeight");
            }
        }

        private bool _hasPoorBalance;
        public bool HasPoorBalance
        {
            get
            {
                return this._hasPoorBalance;
            }
            set
            {
                this.SetProperty(ref this._hasPoorBalance, value, "HasPoorBalance");
            }
        }

        private bool _hasPoorEndurance;
        public bool HasPoorEndurance
        {
            get
            {
                return this._hasPoorEndurance;
            }
            set
            {
                this.SetProperty(ref this._hasPoorEndurance, value, "HasPoorEndurance");
            }
        }

        private bool _hasHistoryOfFalls;
        public bool HasHistoryOfFalls
        {
            get
            {
                return this._hasHistoryOfFalls;
            }
            set
            {
                this.SetProperty(ref this._hasHistoryOfFalls, value, "HasHistoryOfFalls");
            }
        }

        private bool _hasRiskOfFalls;
        public bool HasRiskOfFalls
        {
            get
            {
                return this._hasRiskOfFalls;
            }
            set
            {
                this.SetProperty(ref this._hasRiskOfFalls, value, "HasRiskOfFalls");
            }
        }

        private bool _hasSignificantEdema;
        public bool HasSignificantEdema
        {
            get
            {
                return this._hasSignificantEdema;
            }
            set
            {
                this.SetProperty(ref this._hasSignificantEdema, value, "HasSignificantEdema");
            }
        }

        public static PatientPhysicalAssessment LoadDefault()
        {
            return new PatientPhysicalAssessment()
            {
            };
        }
    }
}
