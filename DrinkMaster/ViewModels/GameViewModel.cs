using DrinkMaster.Model;
using DrinkMaster.Pages;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Timer = System.Timers.Timer;

namespace DrinkMaster.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _CurrentPlayerName;
        public string CurrentPlayerName
        {
            get => _CurrentPlayerName;
            set
            {
                _CurrentPlayerName = value;
                OnPropertyChanged(nameof(CurrentPlayerName));
            }
        }
        private Question _CurrentQuestion;
        public Question CurrentQuestion
        {
            get => _CurrentQuestion;
            set
            {
                _CurrentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }
        private int _Timer;

      
        public int Timer
        {
            get => _Timer;
            set
            {
                _Timer = value;
                OnPropertyChanged(nameof(Timer));
            }
            
           

        }
       

        public Timer gameTimer;
        private Stack<Question> Questions { get; set; }
        private int Count { get; set; }
        public Command AnswerCommand { get; }
        public Command NextQuestionCommand { get; }

        public GameViewModel(Game game)
        {
            INavigation navigation = App.Current.MainPage.Navigation;

            int CurrentPlayerId = 0,
                CurrentQuestionId = 0,
                CurrentCategoryId = 0;
            Timer = 30;
            SetTimer();
     
            Questions = getRandomQuestions();
            CurrentPlayerName = game.Players[CurrentPlayerId].Name;
            CurrentQuestion = game.Categories[CurrentCategoryId].Questions[CurrentQuestionId];

       


            void NextQuestion()
            {
                Timer = 30;
                SetTimer();
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
                    _ = navigation.PushAsync(new LeaderboardPage(game));
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
                Timer = 0;
                gameTimer.Stop();
                // Find correct answer
                string CorrectAnswer = "error";
                foreach (Answer answer in CurrentQuestion.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        CorrectAnswer = answer.Value;
                        break;
                    }
                }

                _ = navigation.PushAsync(new AnswerPage(CurrentQuestion.Content, CorrectAnswer, (bool)isCorrect));
            });

            // Next question button command to prevent timer from starting when navigation is at the next page. TODO: Find a way to freeze the timer / restart on re entry of page!
            NextQuestionCommand = new Command(() =>
            {
                NextQuestion();
            });

            // Randomize questions into a stack.
            Stack<Question> getRandomQuestions()
            {
                Random random = new();
                // Create list with all questions from all categories.
                List<Question> questions = new();
                foreach (Category category in game.Categories)
                {
                    foreach (Question question in category.Questions)
                    {
                        // Randomize order of answers
                        question.Answers = question.Answers.OrderBy(_ => random.Next()).ToList();
                        questions.Add(question);
                    }
                }
                // Randomize question order
                List<Question> randomQuestions = questions.OrderBy(_ => random.Next()).ToList();
                // Convert to stack and return
                return new Stack<Question>(randomQuestions);

            }
            // Set timer voor 1 sec, en add +1 tot de timer 30 bereikt.
            void SetTimer()
            {
                gameTimer = new(1000);
                gameTimer.Elapsed += (sender, e) => HandleTimer();
                gameTimer.Start();
            }

        

            void HandleTimer()
            {
                if (Timer <= 0)
                {
                    NextQuestion();
                    return;
                }
                Timer--;
                gameTimer.Start();
            }

        }
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

