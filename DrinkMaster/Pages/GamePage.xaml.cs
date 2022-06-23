using DrinkMaster.Model;
using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class GamePage : ContentPage
{
    public GamePage(Game game)
    {
        GameViewModel viewModel = new(game);
        BindingContext = viewModel;
        InitializeComponent();
    }
}