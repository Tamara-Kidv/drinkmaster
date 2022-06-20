using DrinkMaster.Model;
using DrinkMaster.ViewModels;
using System.Windows.Input;

namespace DrinkMaster.Pages;

public partial class DifficultyPage : ContentPage
{
    public ICommand SetDifficultyCommand { get; private set; }
    public DifficultyPage(Game game)
    {
		DifficultyPageViewModel viewModel = new(game);
        BindingContext = viewModel;
        InitializeComponent();
    }

    private async void MakkelijkOnClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
    }
    private async void GemiddeldOnClicked(object sender, EventArgs e)
	{
		//await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
	}
	private async void LastigOnClicked(object sender, EventArgs e)
	{
		//await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
	}
	private async void ZeerMoeilijkOnClicked(object sender, EventArgs e)
	{
		//await Navigation.PushAsync(new DifficultyPage(new ViewModels.DifficultyPageViewModel())); //Change to your page.
	}

}