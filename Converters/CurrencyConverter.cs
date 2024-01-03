
using System.Text.RegularExpressions;

namespace sflistviewimageissue.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        #region Convert
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CultureInfo cultureInfo;

            cultureInfo = CultureInfo.CurrentCulture;

            if (value is double dVal && !double.IsInfinity(dVal) && !double.IsNaN(dVal))
            {
                double roundedValue = Math.Round(dVal, 6);


                return Decimal.Parse(roundedValue.ToString("0.000000")).ToString("C", cultureInfo);
            }
            else
            {
                return "Error";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0m;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0m;

            if (valueLong <= 0)
                return 0m;

            return valueLong / 100m;
        } 
        #endregion
    }
}
