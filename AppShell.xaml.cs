namespace sflistviewimageissue;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ReportsPage), typeof(ReportsPage));
    }
}
