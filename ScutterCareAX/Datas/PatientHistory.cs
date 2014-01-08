using MazikCare.MobEval.Common;
using SQLite;


namespace MazikCare.MobEval.Datas
{
    public class PatientHistory : BindableBase
    {
        private string _riskOfFallsOnSet;
        public string RiskOfFallsOnSet
        {
            get
            {
                return this._riskOfFallsOnSet;
            }
            set
            {
                this.SetProperty(ref this._riskOfFallsOnSet, value, "RiskOfFallsOnSet");
            }
        }

        private string _riskOfFallsDescription;
        public string RiskOfFallsDescription
        {
            get
            {
                return this._riskOfFallsDescription;
            }
            set
            {
                this.SetProperty(ref this._riskOfFallsDescription, value, "RiskOfFallsDescription");
            }
        }

        private string _riskOfFallsDiagnosis;
        public string RiskOfFallsDiagnosis
        {
            get
            {
                return this._riskOfFallsDiagnosis;
            }
            set
            {
                this.SetProperty(ref this._riskOfFallsDiagnosis, value, "RiskOfFallsDiagnosis");
            }
        }

        private string _weaknessOnSet;
        public string WeaknessOnSet
        {
            get
            {
                return this._weaknessOnSet;
            }
            set
            {
                this.SetProperty(ref this._weaknessOnSet, value, "WeaknessOnSet");
            }
        }

        private string _weaknessDescription;
        public string WeaknessDescription
        {
            get
            {
                return this._weaknessDescription;
            }
            set
            {
                this.SetProperty(ref this._weaknessDescription, value, "WeaknessDescription");
            }
        }

        private string _weaknessDiagnosis;
        public string WeaknessDiagnosis
        {
            get
            {
                return this._weaknessDiagnosis;
            }
            set
            {
                this.SetProperty(ref this._weaknessDiagnosis, value, "WeaknessDiagnosis");
            }
        }

        private string _inabiliyToAmbulateOnSet;
        public string InabiliyToAmbulateOnSet
        {
            get
            {
                return this._inabiliyToAmbulateOnSet;
            }
            set
            {
                this.SetProperty(ref this._inabiliyToAmbulateOnSet, value, "InabiliyToAmbulateOnSet");
            }
        }

        private string _inabiliyToAmbulateDescription;
        public string InabiliyToAmbulateDescription
        {
            get
            {
                return this._inabiliyToAmbulateDescription;
            }
            set
            {
                this.SetProperty(ref this._inabiliyToAmbulateDescription, value, "InabiliyToAmbulateDescription");
            }
        }

        private string _inabiliyToAmbulateDiagnosis;
        public string InabiliyToAmbulateDiagnosis
        {
            get
            {
                return this._inabiliyToAmbulateDiagnosis;
            }
            set
            {
                this.SetProperty(ref this._inabiliyToAmbulateDiagnosis, value, "InabiliyToAmbulateDiagnosis");
            }
        }

        private string _otherOnSet;
        public string OtherOnSet
        {
            get
            {
                return this._otherOnSet;
            }
            set
            {
                this.SetProperty(ref this._otherOnSet, value, "OtherOnSet");
            }
        }

        private string _otherDescription;
        public string OtherDescription
        {
            get
            {
                return this._otherDescription;
            }
            set
            {
                this.SetProperty(ref this._otherDescription, value, "OtherDescription");
            }
        }

        private string _otherDiagnosis;
        public string OtherDiagnosis
        {
            get
            {
                return this._otherDiagnosis;
            }
            set
            {
                this.SetProperty(ref this._otherDiagnosis, value, "OtherDiagnosis");
            }
        }

        private string _upperBodyWeaknessType;
        public string UpperBodyWeaknessType
        {
            get
            {
                return this._upperBodyWeaknessType;
            }
            set
            {
                this.SetProperty(ref this._upperBodyWeaknessType, value, "UpperBodyWeaknessType");
            }
        }

        private string _upperBodyWeaknessDescription;
        public string UpperBodyWeaknessDescription
        {
            get
            {
                return this._upperBodyWeaknessDescription;
            }
            set
            {
                this.SetProperty(ref this._upperBodyWeaknessDescription, value, "UpperBodyWeaknessDescription");
            }
        }

        private string _upperBodyPainType;
        public string UpperBodyPainType
        {
            get
            {
                return this._upperBodyPainType;
            }
            set
            {
                this.SetProperty(ref this._upperBodyPainType, value, "UpperBodyPainType");
            }
        }

        private string _upperBodyPainDescription;
        public string UpperBodyPainDescription
        {
            get
            {
                return this._upperBodyPainDescription;
            }
            set
            {
                this.SetProperty(ref this._upperBodyPainDescription, value, "UpperBodyPainDescription");
            }
        }

        private string _upperBodyRangeOfMotionType;
        public string UpperBodyRangeOfMotionType
        {
            get
            {
                return this._upperBodyRangeOfMotionType;
            }
            set
            {
                this.SetProperty(ref this._upperBodyRangeOfMotionType, value, "UpperBodyRangeOfMotionType");
            }
        }

        private string _upperBodyRangeOfMotionDescription;
        public string UpperBodyRangeOfMotionDescription
        {
            get
            {
                return this._upperBodyRangeOfMotionDescription;
            }
            set
            {
                this.SetProperty(ref this._upperBodyRangeOfMotionDescription, value, "UpperBodyRangeOfMotionDescription");
            }
        }

        private string _lowerBodyWeaknessType;
        public string LowerBodyWeaknessType
        {
            get
            {
                return this._lowerBodyWeaknessType;
            }
            set
            {
                this.SetProperty(ref this._lowerBodyWeaknessType, value, "LowerBodyWeaknessType");
            }
        }

        private string _lowerBodyWeaknessDescription;
        public string LowerBodyWeaknessDescription
        {
            get
            {
                return this._lowerBodyWeaknessDescription;
            }
            set
            {
                this.SetProperty(ref this._lowerBodyWeaknessDescription, value, "LowerBodyWeaknessDescription");
            }
        }

        private string _lowerBodyPainType;
        public string LowerBodyPainType
        {
            get
            {
                return this._lowerBodyPainType;
            }
            set
            {
                this.SetProperty(ref this._lowerBodyPainType, value, "LowerBodyPainType");
            }
        }

        private string _lowerBodyPainDescription;
        public string LowerBodyPainDescription
        {
            get
            {
                return this._lowerBodyPainDescription;
            }
            set
            {
                this.SetProperty(ref this._lowerBodyPainDescription, value, "LowerBodyPainDescription");
            }
        }

        private string _lowerBodyRangeOfMotionType;
        public string LowerBodyRangeOfMotionType
        {
            get
            {
                return this._lowerBodyRangeOfMotionType;
            }
            set
            {
                this.SetProperty(ref this._lowerBodyRangeOfMotionType, value, "LowerBodyRangeOfMotionType");
            }
        }

        private string _lowerBodyRangeOfMotionDescription;
        public string LowerBodyRangeOfMotionDescription
        {
            get
            {
                return this._lowerBodyRangeOfMotionDescription;
            }
            set
            {
                this.SetProperty(ref this._lowerBodyRangeOfMotionDescription, value, "LowerBodyRangeOfMotionDescription");
            }
        }

        //properties of Mobility tab in assessment

        private bool _canCaneWalker;
        public bool CanCaneWalker
        {
            get
            {
                return this._canCaneWalker;
            }
            set
            {
                this.SetProperty(ref this._canCaneWalker, value, "CanCaneWalker");
            }
        }

        private string _canCaneWalkerDescription;
        public string CanCaneWalkerDescription
        {
            get
            {
                return this._canCaneWalkerDescription;
            }
            set
            {
                this.SetProperty(ref this._canCaneWalkerDescription, value, "CanCaneWalkerDescription");
            }
        }

        private bool _canManualChair;
        public bool CanManualChair
        {
            get
            {
                return this._canManualChair;
            }
            set
            {
                this.SetProperty(ref this._canManualChair, value, "CanManualChair");
            }
        }

        private string _canManualChairDescription;
        public string CanManualChairDescription
        {
            get
            {
                return this._canManualChairDescription;
            }
            set
            {
                this.SetProperty(ref this._canManualChairDescription, value, "CanManualChairDescription");
            }
        }

        private string _patientConditionInHome;
        public string PatientConditionInHome
        {
            get
            {
                return this._patientConditionInHome;
            }
            set
            {
                this.SetProperty(ref this._patientConditionInHome, value, "PatientConditionInHome");
            }
        }

        public static PatientHistory LoadDefault()
        {
            return new PatientHistory()
            {
            };
        }
    }
}
