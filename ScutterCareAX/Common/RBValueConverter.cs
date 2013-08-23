using System;
using Windows.UI.Xaml.Data;

namespace MazikCare.MobEval.Common
{
    public class RBValueConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null) return value;
            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return parameter.ToString();
        }

        #endregion
    }
}
