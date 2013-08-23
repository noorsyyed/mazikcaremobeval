using MazikCare.MobEval.Common;
using SQLite;

namespace MazikCare.MobEval.Datas
{
    public class Patient : BindableBase
    {
        [PrimaryKey,AutoIncrement]
        public uint ID 
        { 
            get; 
            set; 
        }

        public long RecId
        {
            get;
            set;
        }

        public string MRN
        {
            get;
            set;
        }

        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.SetProperty(ref this._name, value, "Name");
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return this._phoneNumber;
            }
            set
            {
                this.SetProperty(ref this._phoneNumber, value, "PhoneNumber");
            }
        }

        private string _roomNumber;
        public string RoomNumber
        {
            get
            {
                return this._roomNumber;
            }
            set
            {
                this.SetProperty(ref this._roomNumber, value, "RoomNumber");
            }
        }

        private string _ssn;
        public string SSN
        {
            get
            {
                return this._ssn;
            }
            set
            {
                this.SetProperty(ref this._ssn, value, "SSN");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                this.SetProperty(ref this._lastName, value, "LastName");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                this.SetProperty(ref this._firstName, value, "FirstName");
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get
            {
                return this._middleName;
            }
            set
            {
                this.SetProperty(ref this._middleName, value, "MiddleName");
            }
        }

        private string _dob;
        public string DOB
        {
            get
            {
                return this._dob;
            }
            set
            {
                this.SetProperty(ref this._dob, value, "DOB");
            }
        }

        private string _gender;
        public string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                this.SetProperty(ref this._gender, value, "Gender");
            }
        }
        
        private string _maritalStatus;
        public string MaritalStatus
        {
            get
            {
                return this._maritalStatus;
            }
            set
            {
                this.SetProperty(ref this._maritalStatus, value, "MaritalStatus");
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this.SetProperty(ref this._address, value, "Address");
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this.SetProperty(ref this._city, value, "City");
            }
        }

        private string _state;
        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                this.SetProperty(ref this._state, value, "State");
            }
        }
        
        private string _zip;
        public string Zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                this.SetProperty(ref this._zip, value, "Zip");
            }
        }

        private string _telephone;
        public string Telephone
        {
            get
            {
                return this._telephone;
            }
            set
            {
                this.SetProperty(ref this._telephone, value, "Telephone");
            }
        }

        private string _emergency;
        public string Emergency
        {
            get
            {
                return this._emergency;
            }
            set
            {
                this.SetProperty(ref this._emergency, value, "Emergency");
            }
        }
        
        private string _imagePath;
        public string ImagePath
        {
            get
            {
                return this._imagePath;
            }
            set
            {
                this.SetProperty(ref this._imagePath, value, "ImagePath");
            }
        }

        private string _patientDiagnosis1;
        public string PatientDiagnosis1
        {
            get
            {
                return this._patientDiagnosis1;
            }
            set
            {
                this.SetProperty(ref this._patientDiagnosis1, value, "PatientDiagnosis1");
            }
        }

        private string _patientDiagnosis2;
        public string PatientDiagnosis2
        {
            get
            {
                return this._patientDiagnosis2;
            }
            set
            {
                this.SetProperty(ref this._patientDiagnosis2, value, "PatientDiagnosis2");
            }
        }

        private string _patientDiagnosis3;
        public string PatientDiagnosis3
        {
            get
            {
                return this._patientDiagnosis3;
            }
            set
            {
                this.SetProperty(ref this._patientDiagnosis3, value, "PatientDiagnosis3");
            }
        }

        private string _prescription1;
        public string Prescription1
        {
            get
            {
                return this._prescription1;
            }
            set
            {
                this.SetProperty(ref this._prescription1, value, "Prescription1");
            }
        }

        private string _prescription2;
        public string Prescription2
        {
            get
            {
                return this._prescription2;
            }
            set
            {
                this.SetProperty(ref this._prescription2, value, "Prescription2");
            }
        }
    }
}
