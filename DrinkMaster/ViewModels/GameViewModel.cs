using DrinkMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command AnswerCommand { get; private set; }
        //public string CurrentPlayerName { get; private set; }
        private string _CurrentPlayerName;
        public string CurrentPlayerName
        {
        get {
                return _CurrentPlayerName;
            }
        set {
                _CurrentPlayerName = value;
                OnPropertyChanged(nameof(CurrentPlayerName));
            }
        }



public Question CurrentQuestion { get; private set; }

        public GameViewModel(Game game)
        {
            INavigation navigation = App.Current.MainPage.Navigation;

            int CurrentPlayerId = 0, 
                CurrentQuestionId = 0, 
                CurrentCategoryId = 0;
            CurrentPlayerName = game.Players[CurrentPlayerId].Name; //TODO: players in volgorde
            CurrentQuestion = game.Categories[CurrentCategoryId].Questions[CurrentQuestionId];

            void NextQuestion()
            {
                if (CurrentPlayerId+1 >= game.Players.Count)
                {
                    CurrentPlayerId = 0;
                } else
                {
                    CurrentPlayerId++;
                }

                if (CurrentCategoryId+1 >= game.Categories.Count)
                {
                    CurrentCategoryId = 0;
                } else
                {
                    CurrentCategoryId++;
                }

                if (CurrentQuestionId+1 >= game.Categories[CurrentCategoryId].Questions.Count)
                {
                    CurrentQuestionId = 0;
                } else
                {
                    CurrentQuestionId++;
                }
                CurrentPlayerName = game.Players[CurrentPlayerId].Name;
                CurrentQuestion = game.Categories[CurrentCategoryId].Questions[CurrentQuestionId];

            }
            AnswerCommand = new Command((isCorrect) =>
            {
                if ((bool)isCorrect)
                {
                    game.Players[CurrentPlayerId].Score++;
                }
                NextQuestion();
            });
            }
            public void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}

