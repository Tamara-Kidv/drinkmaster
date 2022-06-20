using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class QuestionPage : ContentPage
{
	public QuestionPage(QuestionViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
	}

    private async void TrueButtonOnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuestionPage(new ViewModels.QuestionViewModel())); //Change to your page.
    }
    private async void FalseButtonOnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuestionPage(new ViewModels.QuestionViewModel())); //Change to your page.
    }
}