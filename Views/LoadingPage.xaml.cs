using sflistviewimageissue.Helpers;
using sflistviewimageissue.Repository;

namespace sflistviewimageissue.Views;

public partial class LoadingPage : ContentPage
{
    LoadingViewModel _viewModel;

    public LoadingPage()
	{
        GlobalDataRepository globalData = ServiceHelper.Current.GetService<GlobalDataRepository>();

        InitializeComponent();

        _viewModel = new LoadingViewModel(globalData);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}