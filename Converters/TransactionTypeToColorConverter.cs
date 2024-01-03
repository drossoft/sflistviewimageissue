

using sflistviewimageissue.Contracts.Enums;

namespace sflistviewimageissue.Converters
{
    public class TransactionTypeToColorConverter : IValueConverter
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
            if (value == null || !(value is TransactionType))
            {
                return null;
            }

            Color result = Color.FromArgb("ffffc20a");

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

                if ((TransactionType)value == TransactionType.Income)
                    result = (Color)colorDictionary[$"IncomeColor_{themeText}"];
                else if ((TransactionType)value == TransactionType.Expense)
                    result = (Color)colorDictionary[$"ExpenseColor_{themeText}"];
                else if ((TransactionType)value == TransactionType.Transfer)
                    result = (Color)colorDictionary[$"TransferColor_{themeText}"];
                else if ((TransactionType)value == TransactionType.Loan || (TransactionType)value == TransactionType.LoanAmortization)
                    return (Color)colorDictionary[$"LoanColor_{themeText}"];

            }


            return result;

        } 
        #endregion
    }
}
