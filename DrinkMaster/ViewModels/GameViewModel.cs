using DrinkMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.ViewModels
{
    public class GameViewModel
    {
        public Command AnswerCommand { get; private set; }
        public int CurrentQuestionNumber { get; private set; }
        public string CurrentPlayerName { get; private set; }
        public string CurrentQuestion { get; private set; }
        public List<Question> CurrentAnswers { get; private set; }
        public GameViewModel(Game game)
        {
            INavigation navigation = App.Current.MainPage.Navigation;
            AnswerCommand = new Command((answer) =>
            {

            });
            CurrentQuestionNumber = 1;
            CurrentPlayerName = "Jeffrey";
            CurrentQuestion = "Waarom zijn bananen krom?";

        }

    }
}
