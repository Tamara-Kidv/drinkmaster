using DrinkMaster.Model;
using DrinkMaster.Pages;
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
        private string _CurrentPlayerName;
        public string CurrentPlayerName
        {
            get 
            {
                 return _CurrentPlayerName;
            }
            set 
            {
                _CurrentPlayerName = value;
                OnPropertyChanged(nameof(CurrentPlayerName));
            }
        }
        private Question _CurrentQuestion;
        public Question CurrentQuestion
        {
            get
            {
                return _CurrentQuestion;
            }
            set
            {
                _CurrentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }
        private Stack<Question> Questions { get; set; }
        private int Count { get; set; }

        public GameViewModel(Game game)
        {
            INavigation navigation = App.Current.MainPage.Navigation;

            int CurrentPlayerId = 0, 
                CurrentQuestionId = 0, 
                CurrentCategoryId = 0;
            Questions = getRandomQuestions();
            CurrentPlayerName = game.Players[CurrentPlayerId].Name; //TODO: players in volgorde
            CurrentQuestion = game.Categories[CurrentCategoryId].Questions[CurrentQuestionId];

            void NextQuestion()
            {
                Random random = new();
                // Go to next player, and add count if all players have answered a question.
                CurrentPlayerId++;
                if (CurrentPlayerId >= game.Players.Count)
                {
                    CurrentPlayerId = 0;
                    Count++;
                }
                // If no more questions are left or 5 questions are asked, go to leaderboard!
                if (Questions.Count == 0 || Count >= 5)
                {
                    navigation.PushAsync(new LeaderboardPage(game));
                    return;
                }
                // Next question!
                Question currentQuestion = Questions.Pop();

                // Set values to View.
                CurrentPlayerName = game.Players[CurrentPlayerId].Name;
                CurrentQuestion = currentQuestion;

            }

            // Check if answer is correct.
            AnswerCommand = new Command((isCorrect) =>
            {
                if ((bool)isCorrect)
                {
                    game.Players[CurrentPlayerId].Score++;
                }
                NextQuestion();
            });

            // Randomize questions into a stack.
            Stack<Question> getRandomQuestions()
            {
                // Create list with all questions from all categories.
                List<Question> questions = new();
                foreach(Category category in game.Categories)
                {
                    foreach(Question question in category.Questions)
                    {
                        questions.Add(question);
                    }
                }
                Random random = new();
                List<Question> randomQuestions = questions.OrderBy(_ => random.Next()).ToList();
                return new Stack<Question>(randomQuestions);

            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}

