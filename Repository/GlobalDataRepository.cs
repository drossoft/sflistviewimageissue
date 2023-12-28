using sflistviewimageissue.Converters;
using sflistviewimageissue.Model;
using sflistviewimageissue.Services;
using sflistviewimageissue.ViewModels.ItemDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.Repository
{
    public class GlobalDataRepository
    {
        AccountImageIndexToImageSourceConverter _imageConverter;

        public DatabaseService DatabaseService { get; set; }

        public bool IsInitialized { get; set; }
            
        public GlobalDataRepository(DatabaseService databaseService, 
                                    AccountImageIndexToImageSourceConverter imageConverter) 
        { 
            DatabaseService = databaseService;
            _imageConverter = imageConverter;
        }

        public async Task InitializeAsync()
        {
            await DatabaseService.InitializeAsync();
            IsInitialized = true;
        }

        public async Task<List<AccountBalanceDisplay>> GetAccounts()
        {
            var accountItems = await DatabaseService.GetAccounts();

            List<AccountBalanceDisplay> accountBalanceDisplays =
                accountItems.Select(x => GetAccountBalanceDisplay(x)).ToList();

            return accountBalanceDisplays;
            
        }

        public AccountBalanceDisplay GetAccountBalanceDisplay(AccountItem accountItem)
        {
            AccountBalanceDisplay accountBalanceDisplay = new AccountBalanceDisplay();

            accountBalanceDisplay.AccountName = accountItem.Name;
            accountBalanceDisplay.AccountImage = (ImageSource)_imageConverter.Convert(accountItem.ImageIndex, typeof(int), null, System.Globalization.CultureInfo.CurrentCulture);
            accountBalanceDisplay.ImageNumber = accountItem.ImageIndex.ToString();

            return accountBalanceDisplay;
        }

        internal byte[] GetImageData(int imageIndex)
        {
            byte[] result = null;

            var imageItem = DatabaseService.GetImageItem(imageIndex);

            if (imageItem != null)
            {
                result = imageItem.ImageData;
            }

            return result;
        }
    }
}
