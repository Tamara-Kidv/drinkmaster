using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class AnswerPage : ContentPage
{
    public AnswerPage(string Question, string CorrectAnswer, bool IsCorrect)
    {
        AnswerViewModel viewModel = new(Question, CorrectAnswer, IsCorrect);
        BindingContext = viewModel;
        InitializeComponent();
    }
}