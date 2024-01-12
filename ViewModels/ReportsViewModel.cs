using sflistviewimageissue.Contracts.Enums;
using sflistviewimageissue.Repository;
using sflistviewimageissue.ViewModels.ItemDisplay;

namespace sflistviewimageissue.ViewModels;

public partial class ReportsViewModel : BaseViewModel
{
    private GlobalDataRepository _globalData;

    [ObservableProperty]
    private List<AccountBalanceDisplay> _accountBalances;

    [ObservableProperty]
    private ReportPage _currentPage = ReportPage.Settings;

    public ReportsViewModel(GlobalDataRepository globalData)
    {
        _globalData = globalData;
    }


    public async override Task UpdateData()
    {
        AccountBalances = await _globalData.GetAccounts();
    }


    [RelayCommand]
    public void GoToSettings()
    {
        CurrentPage = ReportPage.Settings;
    }

    [RelayCommand]
    public void GoToAccounts()
    {
        CurrentPage = ReportPage.Accounts;
    }

    [RelayCommand]
    public void GoToCategories()
    {
        CurrentPage = ReportPage.Categories;
    }

    [RelayCommand]
    public void GoToData()
    {
        CurrentPage = ReportPage.Data;
    }

    [RelayCommand]
    public void GoToCharts()
    {
        CurrentPage = ReportPage.Charts;
    }

}
