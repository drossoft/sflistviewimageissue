namespace sflistviewimageissue.Views;

public partial class ReportsPage : ContentPage
{
	ReportsViewModel _viewModel;

	public ReportsPage(ReportsViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnNavigated();
    }

}