namespace DrinkMaster.Pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

	private async void OnStartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuestionPage(new ViewModels.QuestionViewModel())); //Change to your page.
    }


}