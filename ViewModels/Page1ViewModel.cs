using sflistviewimageissue.Contracts.Enums;
using sflistviewimageissue.Repository;
using sflistviewimageissue.ViewModels.ItemDisplay;

namespace sflistviewimageissue.ViewModels;

public partial class Page1ViewModel : BaseViewModel
{
    public Page1ViewModel(GlobalDataRepository globalData)
    {
    }


    [RelayCommand]
    public async Task NavigateToReports()
    {
        string route = $"{nameof(ReportsPage)}";
        await Shell.Current.GoToAsync(route);
    }
}
