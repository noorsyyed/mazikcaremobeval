using MazikCare.MobEval.Common;

namespace MazikCare.MobEval.Datas
{
    public class CheckListItemSource : BindableBase
    {
        private string _id;
        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.SetProperty(ref this._id, value, "Id");
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

        private string _valueBeforePrecession;
        public string ValueBeforePrecession
        {
            get
            {
                return this._valueBeforePrecession;
            }
            set
            {
                this.SetProperty(ref this._valueBeforePrecession, value, "ValueBeforePrecession");
            }
        }

        private string _valueAfterPrecession;
        public string ValueAfterPrecession
        {
            get
            {
                return this._valueAfterPrecession;
            }
            set
            {
                this.SetProperty(ref this._valueAfterPrecession, value, "ValueAfterPrecession");
            }
        }

        private string _fieldName;
        public string FieldName
        {
            get
            {
                return this._fieldName;
            }
            set
            {
                this.SetProperty(ref this._fieldName, value, "FieldName");
            }
        }
    }
}
