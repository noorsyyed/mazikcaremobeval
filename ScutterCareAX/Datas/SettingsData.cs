using MazikCare.MobEval.Common;
using SQLite;
using System;

namespace MazikCare.MobEval.Datas
{
    public class SettingsData : BindableBase
    {
        private string _mRN;
        public string MRN
        {
            get
            {
                return this._mRN;
            }
            set
            {
                this.SetProperty(ref this._mRN, value, "MRN");
            }
        }

        [AutoIncrement, PrimaryKey]
        public int Id
        {
            get;
            set;
        }

        private string _doctorRecId;
        public string DoctorRecId
        {
            get
            {
                return this._doctorRecId;
            }
            set
            {
                this.SetProperty(ref this._doctorRecId, value, "DoctorRecId");
            }
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

        private string _cityState;
        public string CityState
        {
            get
            {
                return this._cityState;
            }
            set
            {
                this.SetProperty(ref this._cityState, value, "CityState");
            }
        }

        private string _contactPhone;
        public string ContactPhone
        {
            get
            {
                return this._contactPhone;
            }
            set
            {
                this.SetProperty(ref this._contactPhone, value, "ContactPhone");
                this.Skype = "skype:" + value + "?call";
            }
        }

        private string _skype;
        /// <summary>
        /// No need to explicitely save it or save it
        /// As soon as the contact phone is set it will get set automatically
        /// </summary>
        [Ignore]
        public string Skype
        {
            get
            {
                return this._skype;
            }
            set
            {
                this.SetProperty(ref this._skype, value, "Skype");
            }
        }

        private string _daddress;
        public string Daddress
        {
            get
            {
                return this._daddress;
            }
            set
            {
                this.SetProperty(ref this._daddress, value, "Daddress");
            }
        }

        private string _dcityState;
        public string DcityState
        {
            get
            {
                return this._dcityState;
            }
            set
            {
                this.SetProperty(ref this._dcityState, value, "DcityState");
            }
        }

        private string _woReportingComment;
        public string WoReportingComment
        {
            get
            {
                return this._woReportingComment;
            }
            set
            {
                this.SetProperty(ref this._woReportingComment, value, "WoReportingComment");
            }
        }

        private string _alertMsg1;
        public string AlertMsg1
        {
            get
            {
                return this._alertMsg1;
            }
            set
            {
                this.SetProperty(ref this._alertMsg1, value, "AlertMsg1");
            }
        }

        private string _alertMsg2;
        public string AlertMsg2
        {
            get
            {
                return this._alertMsg2;
            }
            set
            {
                this.SetProperty(ref this._alertMsg2, value, "AlertMsg2");
            }
        }

        private string _chiefComplaint;
        public string ChiefComplaint
        {
            get
            {
                return this._chiefComplaint;
            }
            set
            {
                this.SetProperty(ref this._chiefComplaint, value, "ChiefComplaint");
            }
        }

        private string _primaryCarePhysician;
        public string PrimaryCarePhysician
        {
            get
            {
                return this._primaryCarePhysician;
            }
            set
            {
                this.SetProperty(ref this._primaryCarePhysician, value, "PrimaryCarePhysician");
            }
        }

        private string _orthopedicsSpecialist;
        public string OrthopedicsSpecialist
        {
            get
            {
                return this._orthopedicsSpecialist;
            }
            set
            {
                this.SetProperty(ref this._orthopedicsSpecialist, value, "OrthopedicsSpecialist");
            }
        }

        private string _attendingNurse;
        public string AttendingNurse
        {
            get
            {
                return this._attendingNurse;
            }
            set
            {
                this.SetProperty(ref this._attendingNurse, value, "AttendingNurse");
            }
        }

        private string _tile2Title;
        public string Tile2Title
        {
            get
            {
                return this._tile2Title;
            }
            set
            {
                this.SetProperty(ref this._tile2Title, value, "Tile2Title");
            }
        }

        private string _tile2Content;
        public string Tile2Content
        {
            get
            {
                return this._tile2Content;
            }
            set
            {
                this.SetProperty(ref this._tile2Content, value, "Tile2Content");
            }
        }

        private string _serviceEndpoint;
        public string ServiceEndpoint
        {
            get
            {
                return this._serviceEndpoint;
            }
            set
            {
                this.SetProperty(ref this._serviceEndpoint, value, "ServiceEndpoint");
            }
        }

        private bool _isSyncWithAX;
        public bool IsSyncWithAX
        {
            get
            {
                return this._isSyncWithAX;
            }
            set
            {
                this.SetProperty(ref this._isSyncWithAX, value, "IsSyncWithAX");
            }
        }

        private bool _isShareStorageItemsHandlerAssigned;
        public bool IsShareStorageItemsHandlerAssigned
        {
            get
            {
                return this._isShareStorageItemsHandlerAssigned;
            }
            set
            {
                this.SetProperty(ref this._isShareStorageItemsHandlerAssigned, value, "IsShareStorageItemsHandlerAssigned");
            }
        }

        public string CurrentDate
        {
            get
            {
                return DateTime.Today.ToString("MM/dd/yyyy");
            }
        }

        private string _heightInFeet;
        public string HeightInFeet
        {
            get
            {
                return this._heightInFeet;
            }
            set
            {
                this.SetProperty(ref this._heightInFeet, value, "HeightInFeet");
            }
        }

        private string _heightInInches;
        public string HeightInInches
        {
            get
            {
                return this._heightInInches;
            }
            set
            {
                this.SetProperty(ref this._heightInInches, value, "HeightInInches");
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

        public static SettingsData LoadDefault()
        {
            return new SettingsData()
            {
                Name = "LK Prasad",
                Address = "3424 Kimble Dr",
                CityState = "Plano, TX - 75025",
                ContactPhone = "+16086955867",
                Daddress = "2930 Ashok Nagar, Jublee Hills, Hyderabad",
                DcityState = "Irving, TX - 75038",
                WoReportingComment = "I have no problem getting through doorways and sitting the tables",
                AlertMsg1 = "Jazzy select installation class",
                AlertMsg2 = "Shoprider installation class",
                ChiefComplaint = "multiple sclerosis",
                PrimaryCarePhysician = "Dr.RadhaKishan",
                OrthopedicsSpecialist = "Dr.Himanshu",
                AttendingNurse = "Nancy Young",

                Tile2Title = "Sales Quote-Confirmation",
                Tile2Content = "Iansoprazole 15 mg tablets – take 1 tablet once a day",
                HeightInFeet = "5",
                HeightInInches = "5",
                Weight = "140",
            };
        }
    }
}
