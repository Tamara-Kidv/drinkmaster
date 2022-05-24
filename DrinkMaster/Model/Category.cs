using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
            this.QuestionList = new List<Question>();
        }
        public string Name { get; set; }
        public List<Question> QuestionList { get; set; }

        public void addQuestion(Question question)
        {
            this.QuestionList.Add(question);
        }
    }
}
