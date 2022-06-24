namespace DrinkMaster.Model
{
    public class Answer
    {
        public Answer(string Answer, bool IsCorrect)
        {
            Value = Answer;
            this.IsCorrect = IsCorrect;
        }
        public string Value { get; private set; }
        public bool IsCorrect { get; private set; }
    }
}
