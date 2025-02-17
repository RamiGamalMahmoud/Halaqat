using System;
using System.Globalization;
using System.Windows.Data;

namespace Halaqat.Resources.Converters
{
    public class RowIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (parameter is not CollectionViewSource) return 0;

                CollectionViewSource models = (CollectionViewSource)parameter;
                CollectionView view = models.View as CollectionView;


                return view.IndexOf(value) + 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
