using DrinkMaster.Model;
using DrinkMaster.Pages;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

namespace DrinkMaster.ViewModels;
public class CategoryViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public ICommand NextPageCommand { get; private set; }
    public ICommand AddCategoryCommand { get; private set; }
    public List<Category> Categories { get; set; }
    public List<Category> ChosenCategories { get; set; }
    public CategoryViewModel(Game game)
    {
        
        INavigation navigation = App.Current.MainPage.Navigation;

        // Go to next page
        NextPageCommand = new Command(async () =>
        {
            // If no categories are selected, do nothing.
            if (ChosenCategories.Count == 0)
            {
                return;
            }
            // Load questions from JSON
            List<QuestionsModel> allQuestions = await CategoryViewModel.LoadQuestions();

            // Import all questions of which the categories are currently selected
            foreach (QuestionsModel question in allQuestions)
            {
                foreach (Category category in ChosenCategories)
                {

                    if (question.category == category.Name)
                    {
                        AddQuestion(question, category);
                    }
                }
            }
            // Set categories in the game
            game.Categories = ChosenCategories;
            // Navigate to the next page
            await navigation.PushAsync(new GamePage(game));
        });

        // Toggle category selected
        AddCategoryCommand = new Command((name) =>
        {
            string categoryName = name.ToString();
            foreach (Category category in Categories)
            {
                if (category.Name == categoryName)
                {
                    category.IsSelected = true;
                    foreach (Category chosenCategory in ChosenCategories)
                    {
                        // If already in the list, remove
                        if (category.Name == chosenCategory.Name)
                        {
                            ChosenCategories.Remove(chosenCategory);
                            break;
                        }
                    }
                    // Set values in view
                    category.Colour = Colors.Gray;
                    ChosenCategories.Add(category);
                    break;
                }
            }
        });

        Categories = new List<Category>
            {
                new Category("Dieren", Colors.Red),
                new Category("Algemeen", Colors.Orange),
                new Category("Sport", Colors.Green),
                new Category("Films en Series", Colors.Blue),
                new Category("Eigen Lijst", Colors.Purple),
            };
        ChosenCategories = new List<Category>();


    }

    private static void AddQuestion(QuestionsModel question, Category category)
    {
        List<Answer> answers = new()
                        {
                            new(question.correctAnswer, true)
                        };
        foreach (string incorrectAnswer in question.incorrectAnswers)
        {
            Answer wrongAnswer = new(incorrectAnswer, false);
            answers.Add(wrongAnswer);
        }
        category.AddQuestion(new(question.question, answers));
    }

    private static async Task<List<QuestionsModel>> LoadQuestions()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("questions.json");
        using var reader = new StreamReader(stream);
        string json = reader.ReadToEnd();
        try
        {
            List<QuestionsModel> questions = JsonSerializer.Deserialize<List<QuestionsModel>>(json);
            return questions;

        }
        catch (JsonException ex)
        {
            Debug.WriteLine(ex);
        }
        return null;

    }
}

