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
        public List<Answer> Answers { get; set; }

    }
}
