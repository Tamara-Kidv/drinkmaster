using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Question
    {
        public Question(string Question, List<Answer> Answers)
        {
            Content = Question;
            this.Answers = Answers;
        }
        public string Content { get; set; }
        public List<Answer> Answers { get; }

    }
}
