using DrinkMaster.Model;
using DrinkMaster.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace DrinkMaster.ViewModels;
public class CategoryViewModel
{
    public ICommand NextPageCommand { get; private set; }
    public ICommand AddCategoryCommand { get; private set; }
    public List<Category> Categories { get; set; }
    public List<Category> ChosenCategories { get; set; }
    public CategoryViewModel(Game game)
    {
        INavigation navigation = App.Current.MainPage.Navigation;
        NextPageCommand = new Command(async () =>
        {
            List<QuestionsModel> allQuestions = await LoadQuestions();

            // TODO: fix 3x foreach loop? mogelijk QuestionsDataModel aanpassen, zodat de rest deze classes gebruikt.
            foreach (QuestionsModel question in allQuestions)
            {
                foreach(Category category in ChosenCategories)
                {

                    if (question.category == category.Name)
                    {
                        addQuestion(question, category);
                    }
                }            
            }

            game.Categories = ChosenCategories;
            await navigation.PushAsync(new GamePage(game));
        });


        AddCategoryCommand = new Command((name) =>
        {
            string categoryName = name.ToString();
            foreach (Category category in Categories)
            {
                if (category.Name == categoryName)
                {
                    foreach (Category chosenCategory in ChosenCategories)
                    {
                        if (category.Name == chosenCategory.Name)
                        {
                            ChosenCategories.Remove(chosenCategory);
                            break;
                        }
                    }
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

    private static void addQuestion(QuestionsModel question, Category category)
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

    private async Task<List<QuestionsModel>> LoadQuestions()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("questions.json");
        using var reader = new StreamReader(stream);
        string json = reader.ReadToEnd();
        try
        {
            List<QuestionsModel> questions = JsonSerializer.Deserialize<List<QuestionsModel>>(json);
            Debug.WriteLine(questions);
            return questions;

        }
        catch (JsonException ex)
        {
            Debug.WriteLine(ex);
        }
        return null;

    }
}

