using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class Categories : ContentPage
{
	public Categories(CategoryViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
    }
}