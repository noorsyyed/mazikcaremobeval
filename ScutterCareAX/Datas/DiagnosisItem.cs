using MazikCare.MobEval.Common;

namespace MazikCare.MobEval.Datas
{
    class DiagnosisItem : BindableBase
    {
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
    }
}
