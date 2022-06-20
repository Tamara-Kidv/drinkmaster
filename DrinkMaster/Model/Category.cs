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
            this.Name = name;
            this.Colour = colour;
            this.Questions = new List<Question>();

            List<Answer> answers = new()
            {
                new("4", true),
                new("6", false),
                new("8", false),
                new("10", false)
            };
            Question one = new("Hoeveel zijdes heeft een dobbelsteen?", answers);
            Questions.Add(one);
            answers = new()
            {
                new("Altijd LaagDrempelig Inkopen", false),
                new("Albrecht Discount", true),
                new("Actie Levenslange Discount Inkopen", false),
                new("Alzeit Lebensmittelen Discount Immer kaufen", false)
            };
            Question two = new("Waarvoor staat de afkorting Aldi, het voordelige supermarktbedrijf?", answers);
            Questions.Add(two);

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
