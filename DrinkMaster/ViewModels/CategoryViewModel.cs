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
                new Category("Dieren"),
                new Category("Algemeen"),
                new Category("Sport"),
                new Category("Films en Series"),
                new Category("Algemeen"),
                new Category("Eigen Lijst"),
            };
        }

        public List<Category> Categories { get; set; }
    }
}
