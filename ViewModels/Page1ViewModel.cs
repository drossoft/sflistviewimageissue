using sflistviewimageissue.Repository;
using sflistviewimageissue.ViewModels.ItemDisplay;

namespace sflistviewimageissue.ViewModels;

public partial class Page1ViewModel : BaseViewModel
{
    private GlobalDataRepository _globalData;

    [ObservableProperty]
    private List<AccountBalanceDisplay> _accountBalances;

    public Page1ViewModel(GlobalDataRepository globalData)
    {
        _globalData = globalData;
    }


    public async override Task UpdateData()
    {
        AccountBalances = await _globalData.GetAccounts();
    }

}
