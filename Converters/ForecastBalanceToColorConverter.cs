
namespace sflistviewimageissue.Converters
{
    public class ForecastBalanceToColorConverter : IValueConverter
    {
        #region Convert
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return InternalConvert(value, targetType, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private methods
        private object InternalConvert(object value, Type targetType, object parameter)
        {
            if (value == null || !(value is double))
            {
                return null;
            }

            Color result = Colors.White;

            ResourceDictionary colorDictionary = Application.Current.Resources.MergedDictionaries.Where(md => md.Source != null && md.Source.OriginalString.Contains("Styles/Colors.xaml")).FirstOrDefault();

            if (colorDictionary != null)
            {
                string themeText = string.Empty;

                if (App.Current.RequestedTheme == AppTheme.Dark)
                {
                    themeText = "Dark";
                }
                else
                {
                    themeText = "Light";
                }

                if ((double)value > 0)
                    result = (Color)colorDictionary[$"NormalTextColor_{themeText}"];
                else if ((double)value == 0)
                    result = (Color)colorDictionary[$"ZeroBalanceColor_{themeText}"];
                else
                    result = (Color)colorDictionary[$"NegativeBalanceColor_{themeText}"];
            }

            return result;

        } 
        #endregion
    }
}
