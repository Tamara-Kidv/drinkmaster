namespace DrinkMaster.Model
{
    public class Answer
    {
        public Answer(string Answer, Boolean IsCorrect)
        {
            Value = Answer;
            this.IsCorrect = IsCorrect;
        }
        public string Value { get; private set; }
        public bool IsCorrect { get; private set; }
    }
}
