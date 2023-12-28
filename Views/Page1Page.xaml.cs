namespace sflistviewimageissue.Views;

public partial class Page1Page : ContentPage
{
    Page1ViewModel _viewModel;


    public Page1Page(Page1ViewModel viewModel)
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
