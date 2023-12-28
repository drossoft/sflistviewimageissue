using sflistviewimageissue.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        private GlobalDataRepository _globalData;
        public LoadingViewModel(GlobalDataRepository globalData) 
        {
            _globalData = globalData;
        }

        public async Task InitializeAsync()
        {
            if (!_globalData.IsInitialized)
            {
                await _globalData.InitializeAsync();
            }

            Application.Current.MainPage = new AppShell();
        }

    }
}
