using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class PlayerInputPage : ContentPage
{
    public PlayerInputPage(PlayerInputViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}