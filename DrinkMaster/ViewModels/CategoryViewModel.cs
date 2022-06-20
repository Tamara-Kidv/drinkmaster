using DrinkMaster.Model;
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
    }
}
