using DrinkMaster.Model;
using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class CategoryPage : ContentPage
{
    public CategoryPage(Game game)
    {
        CategoryViewModel viewModel = new(game);
        BindingContext = viewModel;
        InitializeComponent();
    }
}