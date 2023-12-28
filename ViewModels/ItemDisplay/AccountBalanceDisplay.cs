using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.ViewModels.ItemDisplay
{
    public partial class AccountBalanceDisplay : ObservableObject
    {
        [ObservableProperty]
        private ImageSource _accountImage;

        [ObservableProperty]
        private string _accountName;

        [ObservableProperty]
        private string _imageNumber;
    }
}
