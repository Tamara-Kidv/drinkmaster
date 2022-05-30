namespace DrinkMaster.Pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

	private async void OnStartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
    }


}