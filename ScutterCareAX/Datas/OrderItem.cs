using MazikCare.MobEval.Common;

namespace MazikCare.MobEval.Datas
{
    public class OrderItem : BindableBase
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

        private string _image;
        public string Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this.SetProperty(ref this._image, value, "Image");
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
