using DrinkMaster.Model;
using DrinkMaster.ViewModels;
using System.Windows.Input;

namespace DrinkMaster.Pages;

public partial class DifficultyPage : ContentPage
{
    public DifficultyPage(Game game)
    {
		DifficultyViewModel viewModel = new(game);
        BindingContext = viewModel;
        InitializeComponent();
    }
}