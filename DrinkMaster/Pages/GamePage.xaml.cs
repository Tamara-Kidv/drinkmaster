using DrinkMaster.Model;
using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class GamePage : ContentPage
{
	public GamePage(Game game)
	{
		InitializeComponent();
        GameViewModel viewModel = new(game);
        BindingContext = viewModel;
	}
}