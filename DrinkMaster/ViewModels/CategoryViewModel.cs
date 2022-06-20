using DrinkMaster.Model;
using DrinkMaster.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrinkMaster.ViewModels;
public class CategoryViewModel
{
    public ICommand NextPageCommand { get; private set; }
    public ICommand AddCategoryCommand { get; private set; }
    public List<Category> Categories { get; set; }
    public List<Category> ChosenCategories { get; set; }
    public CategoryViewModel()
    {
        INavigation navigation = App.Current.MainPage.Navigation;
        NextPageCommand = new Command(async () => await navigation.PushAsync(new GamePage()));
        AddCategoryCommand = new Command((name) =>
        {
            string categoryName = name.ToString();
            foreach (Category category in Categories)
            {
                if (category.Name == categoryName)
                {
                    ChosenCategories.Add(category);
                    break;
                }
            }
        });

        Categories = new List<Category>
            {
                new Category("Dieren", "Red"),
                new Category("Algemeen", "Yellow"),
                new Category("Sport", "Green"),
                new Category("Films en Series", "Blue"),
                new Category("Eigen Lijst", "Purple"),
            };
        ChosenCategories = new List<Category>();
    }
   
}