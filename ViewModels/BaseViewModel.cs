namespace sflistviewimageissue.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    protected bool _isDataUpToDate;

    public async virtual Task OnNavigated()
    {
        if (!_isDataUpToDate)
        {
            await UpdateData();
            _isDataUpToDate = true;
        }
    }

    public virtual Task UpdateData()
    {
        return Task.CompletedTask;
    }

}
