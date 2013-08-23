using MazikCare.MobEval.Common;

namespace MazikCare.MobEval.Datas
{
    public class PrescriptionData : BindableBase
    {
        private bool _isToileting;
        public bool IsToileting
        {
            get
            {
                return this._isToileting;
            }
            set
            {
                this.SetProperty(ref this._isToileting, value, "IsToileting");
            }
        }

        private bool _isFeeding;
        public bool IsFeeding
        {
            get
            {
                return this._isFeeding;
            }
            set
            {
                this.SetProperty(ref this._isFeeding, value, "IsFeeding");
            }
        }

        private bool _isDressing;
        public bool IsDressing
        {
            get
            {
                return this._isDressing;
            }
            set
            {
                this.SetProperty(ref this._isDressing, value, "IsDressing");
            }
        }

        private bool _isGrooming;
        public bool IsGrooming
        {
            get
            {
                return this._isGrooming;
            }
            set
            {
                this.SetProperty(ref this._isGrooming, value, "IsGrooming");
            }
        }

        private bool _isBathing;
        public bool IsBathing
        {
            get
            {
                return this._isBathing;
            }
            set
            {
                this.SetProperty(ref this._isBathing, value, "IsBathing");
            }
        }

        private bool _isCane;
        public bool IsCane
        {
            get
            {
                return this._isCane;
            }
            set
            {
                this.SetProperty(ref this._isCane, value, "IsCane");
            }
        }

        private bool _isWalker;
        public bool IsWalker
        {
            get
            {
                return this._isWalker;
            }
            set
            {
                this.SetProperty(ref this._isWalker, value, "IsWalker");
            }
        }

        private bool _isMWC;
        public bool IsMWC
        {
            get
            {
                return this._isMWC;
            }
            set
            {
                this.SetProperty(ref this._isMWC, value, "IsMWC");
            }
        }

        private bool _isJoystick;
        public bool IsJoystick
        {
            get
            {
                return this._isJoystick;
            }
            set
            {
                this.SetProperty(ref this._isJoystick, value, "IsJoystick");
            }
        }

        private bool _isElevating;
        public bool IsElevating
        {
            get
            {
                return this._isElevating;
            }
            set
            {
                this.SetProperty(ref this._isElevating, value, "IsElevating");
            }
        }

        private bool _isFully;
        public bool IsFully
        {
            get
            {
                return this._isFully;
            }
            set
            {
                this.SetProperty(ref this._isFully, value, "IsFully");
            }
        }

        private bool _isSpeacial;
        public bool IsSpeacial
        {
            get
            {
                return this._isSpeacial;
            }
            set
            {
                this.SetProperty(ref this._isSpeacial, value, "IsSpeacial");
            }
        }

        private string _mridlReason;
        public string MridlReason
        {
            get
            {
                return this._mridlReason;
            }
            set
            {
                this.SetProperty(ref this._mridlReason, value, "MridlReason");
            }
        }

        private string _ambulatorylReason;
        public string AmbulatorylReason
        {
            get
            {
                return this._ambulatorylReason;
            }
            set
            {
                this.SetProperty(ref this._ambulatorylReason, value, "AmbulatorylReason");
            }
        }

        private string _pOVReason;
        public string POVReason
        {
            get
            {
                return this._pOVReason;
            }
            set
            {
                this.SetProperty(ref this._pOVReason, value, "POVReason");
            }
        }

        private bool _isCN;
        public bool IsCN
        {
            get
            {
                return this._isCN;
            }
            set
            {
                this.SetProperty(ref this._isCN, value, "IsCN");
            }
        }

        private bool _isLabs;
        public bool IsLabs
        {
            get
            {
                return this._isLabs;
            }
            set
            {
                this.SetProperty(ref this._isLabs, value, "IsLabs");
            }
        }

        private bool _isHospital;
        public bool IsHospital
        {
            get
            {
                return this._isHospital;
            }
            set
            {
                this.SetProperty(ref this._isHospital, value, "IsHospital");
            }
        }

        private bool _isPMD;
        public bool IsPMD
        {
            get
            {
                return this._isPMD;
            }
            set
            {
                this.SetProperty(ref this._isPMD, value, "IsPMD");
            }
        }
        
        private string _bp;
        public string Bp
        {
            get
            {
                return this._bp;
            }
            set
            {
                this.SetProperty(ref this._bp, value, "Bp");
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

        private string _respiratory;
        public string Respiratory
        {
            get
            {
                return this._respiratory;
            }
            set
            {
                this.SetProperty(ref this._respiratory, value, "Respiratory");
            }
        }

        private bool _isOMCurrent;
        public bool IsOMCurrent
        {
            get
            {
                return this._isOMCurrent;
            }
            set
            {
                this.SetProperty(ref this._isOMCurrent, value, "IsOMCurrent");
            }
        }

        private string _noteCurrent;
        public string NoteCurrent
        {
            get
            {
                return this._noteCurrent;
            }
            set
            {
                this.SetProperty(ref this._noteCurrent, value, "NoteCurrent");
            }
        }

        private bool _isOMMusculoskeletal;
        public bool IsOMMusculoskeletal
        {
            get
            {
                return this._isOMMusculoskeletal;
            }
            set
            {
                this.SetProperty(ref this._isOMMusculoskeletal, value, "IsOMMusculoskeletal");
            }
        }

        private string _noteMusculoskeletal;
        public string NoteMusculoskeletal
        {
            get
            {
                return this._noteMusculoskeletal;
            }
            set
            {
                this.SetProperty(ref this._noteMusculoskeletal, value, "NoteMusculoskeletal");
            }
        }

        private bool _isOMCardio;
        public bool IsOMCardio
        {
            get
            {
                return this._isOMCardio;
            }
            set
            {
                this.SetProperty(ref this._isOMCardio, value, "IsOMCardio");
            }
        }

        private string _noteCardio;
        public string NoteCardio
        {
            get
            {
                return this._noteCardio;
            }
            set
            {
                this.SetProperty(ref this._noteCardio, value, "NoteCardio");
            }
        }

        private bool _isOMNeurologic;
        public bool IsOMNeurologic
        {
            get
            {
                return this._isOMNeurologic;
            }
            set
            {
                this.SetProperty(ref this._isOMNeurologic, value, "IsOMNeurologic");
            }
        }

        private string _noteNeurologic;
        public string NoteNeurologic
        {
            get
            {
                return this._noteNeurologic;
            }
            set
            {
                this.SetProperty(ref this._noteNeurologic, value, "NoteNeurologic");
            }
        }

        private bool _isOMAmbulatory;
        public bool IsOMAmbulatory
        {
            get
            {
                return this._isOMAmbulatory;
            }
            set
            {
                this.SetProperty(ref this._isOMAmbulatory, value, "IsOMAmbulatory");
            }
        }

        private string _noteAmbulatory;
        public string NoteAmbulatory
        {
            get
            {
                return this._noteAmbulatory;
            }
            set
            {
                this.SetProperty(ref this._noteAmbulatory, value, "NoteAmbulatory");
            }
        }

        private bool _isOMGait;
        public bool IsOMGait
        {
            get
            {
                return this._isOMGait;
            }
            set
            {
                this.SetProperty(ref this._isOMGait, value, "IsOMGait");
            }
        }

        private string _noteGait;
        public string NoteGait
        {
            get
            {
                return this._noteGait;
            }
            set
            {
                this.SetProperty(ref this._noteGait, value, "NoteGait");
            }
        }

        private bool _isOMAssistance;
        public bool IsOMAssistance
        {
            get
            {
                return this._isOMAssistance;
            }
            set
            {
                this.SetProperty(ref this._isOMAssistance, value, "IsOMAssistance");
            }
        }

        private string _noteAssistance;
        public string NoteAssistance
        {
            get
            {
                return this._noteAssistance;
            }
            set
            {
                this.SetProperty(ref this._noteAssistance, value, "NoteAssistance");
            }
        }

        private bool _isOMMotion;
        public bool IsOMMotion
        {
            get
            {
                return this._isOMMotion;
            }
            set
            {
                this.SetProperty(ref this._isOMMotion, value, "IsOMMotion");
            }
        }

        private string _noteMotion;
        public string NoteMotion
        {
            get
            {
                return this._noteMotion;
            }
            set
            {
                this.SetProperty(ref this._noteMotion, value, "NoteMotion");
            }
        }

        private OrderItem _orderItem;
        public OrderItem OrderItem
        {
            get
            {
                return this._orderItem;
            }
            set
            {
                this.SetProperty(ref this._orderItem, value, "OrderItem");
            }
        }

        private string _diagnosis;
        public string Diagnosis
        {
            get
            {
                return this._diagnosis;
            }
            set
            {
                this.SetProperty(ref this._diagnosis, value, "Diagnosis");
            }
        }

        private string _lON;
        public string LON
        {
            get
            {
                return this._lON;
            }
            set
            {
                this.SetProperty(ref this._lON, value, "LON");
            }
        }
    }
}
