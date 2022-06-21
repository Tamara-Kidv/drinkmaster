using DrinkMaster.Model;
using DrinkMaster.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        //GetXml();
        //var questions = GetXml().ToString();
        //XmlDocument doc = new()
        //{
        //    PreserveWhitespace = true
        //};
        //doc.LoadXml(questions);

        //XmlNode root = doc.FirstChild;


    }
    private async Task<DataQuestions> GetXml()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("questions.xml");
        using var reader = new StreamReader(stream);
        DataQuestions dataQuestions = Deserialize<DataQuestions>(reader.ReadToEnd());
        return dataQuestions;
    }

    public static T Deserialize<T>(string xmlString)
    {
        if (xmlString == null) return default;
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = new StringReader(xmlString))
        {
            return (T)serializer.Deserialize(reader);
        }
    }

    private class DataQuestions
    {
        private List<vraag> vragen { get; set; }
        private class vraag {
            private string tekst { get; set; }
            private List<string> antwoorden { get; set; }
        }
    }
}