namespace DrinkMaster.Model
{
    public class Category
    {
        public Category(string name, Color colour)
        {
            Name = name;
            Colour = colour;
            Questions = new List<Question>();
            IsSelected = false;
        }
        public string Name { get; set; }
        public Color Colour { get; set; }
        public Color BorderColour { get; set; }
        public List<Question> Questions { get; set; }

        // Used to see visible toggle in view.
        private bool _IsSelected;

        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                _IsSelected = value;
                BorderColour = value ? Colors.White : Colors.Black;
            }
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}
