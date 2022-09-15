namespace DrinkMaster.Model
{
    public class Player
    {
        public Player(string name, string avatar)
        {
            Name = name;
            Score = 0;
            Avatar = avatar;
        }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Avatar { get; set; }

        public Color BackgroundColor
        {
            get => Appcolours.GetRandomColor();
        }

        public Char FirstCharOfName
        {
            get => !string.IsNullOrWhiteSpace(Name) ? Name.ToCharArray()[0] : ' ';
        }
    }

}
