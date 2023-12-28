namespace sflistviewimageissue.Views;

public partial class Page2Page : ContentPage
{
    Page2ViewModel _viewModel;


    public Page2Page(Page2ViewModel viewModel)
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
