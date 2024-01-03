using sflistviewimageissue.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.ViewModels.ItemDisplay
{
    public partial class AccountBalanceDisplay : ObservableObject
    {
        public AccountType AccountType { get; set; }

        [ObservableProperty]
        private ImageSource _accountImage;

        [ObservableProperty]
        private string _accountName;

        [ObservableProperty]
        private string _imageNumber;

        #region Upcoming payments
        public bool HasUpcoming { get; set; }
        public string InitialUpcomingText { get; set; }
        public ImageSource UpcomingImage { get; set; }
        public TransactionType UpcomingTransactionType { get; set; }
        public string FinalUpcomingText { get; set; }
        #endregion

        #region Indicators

        public bool IsBalanceNotSynced { get; set; }
        public bool IsAnyNotEnough { get; set; }
        public bool IsAnyOverdue { get; set; }
        #endregion

        #region Totals

        public double CurrentBalance { get; set; }
        public double ForecastBalance { get; set; }
        public double AvailableBalance { get; set; }
        public bool IsAnyForecast { get; set; }
        public bool IsAnyForecastOrCard { get; set; }
        #endregion
    }
}
