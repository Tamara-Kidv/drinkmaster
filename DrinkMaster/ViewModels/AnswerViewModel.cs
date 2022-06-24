using System.Windows.Input;

namespace DrinkMaster.ViewModels
{
    internal class AnswerViewModel
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public ICommand NextPageCommand { get; private set; }
        public AnswerViewModel(string Question, string CorrectAnswer, bool IsCorrect)
        {
            this.Question = Question;
            this.CorrectAnswer = CorrectAnswer;
            this.IsCorrect = IsCorrect;

            INavigation navigation = App.Current.MainPage.Navigation;

            NextPageCommand = new Command(async () =>
            {
                _ = await navigation.PopAsync();
            });
        }
    }
}
