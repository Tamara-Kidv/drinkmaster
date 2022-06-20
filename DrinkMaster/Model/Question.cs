using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Question
    {
        public Question(String content)
        {
            this.Content = content;
        }
        public string Content { get; set; }
    }
}
