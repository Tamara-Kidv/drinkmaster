using DrinkMaster.Model;
using DrinkMaster.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            INavigation navigation = App.Current.MainPage.Navigation;
            NexPageCommand = new Command(async () => await NavigationEventArgs.PushAsynch(new StartPage()));

            Categories = new List<Category>
            {
                new Category("Dieren", "Red"),
                new Category("Algemeen", "Yellow"),
                new Category("Sport", "Green"),
                new Category("Films en Series", "Blue"),
                new Category("Eigen Lijst", "Purple"),
            };
        }

        public List<Category> Categories { get; set; }

        public void NextPage() {
            
        }
    }
}
