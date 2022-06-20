using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class CategoryPage : ContentPage
{
	public CategoryPage(CategoryViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
	}
}