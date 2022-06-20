using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class DifficultyPage : ContentPage
{
	public DifficultyPage(DifficultyPageViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
    private async void MakkelijkOnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
    }
    private async void GemiddeldOnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
	}
	private async void LastigOnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
	}
	private async void ZeerMoeilijkOnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
	}

}