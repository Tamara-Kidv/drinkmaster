namespace DrinkMaster.Model
{

    public class QuestionsModel
    {
        public string category { get; set; }
        public string correctAnswer { get; set; }
        public string[] incorrectAnswers { get; set; }
        public string question { get; set; }
        public string difficulty { get; set; }
    }



}
