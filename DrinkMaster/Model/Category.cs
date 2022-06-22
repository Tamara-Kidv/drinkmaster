using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Category
    {
        public Category(string name, Color colour)
        {
            Name = name;
            Colour = colour;
            Questions = new List<Question>();

        }
        public string Name { get; set; }
        public Color Colour { get; set; }
        public List<Question> Questions { get; set; }

        public void AddQuestion(Question question)
        {
            this.Questions.Add(question);
        }
    }
}
