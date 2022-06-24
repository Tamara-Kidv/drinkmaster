using DrinkMaster.Model;
using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class LeaderboardPage : ContentPage
{
    public LeaderboardPage(Game game)
    {
        LeaderboardViewModel viewModel = new(game);
        BindingContext = viewModel;
        InitializeComponent();
    }
}