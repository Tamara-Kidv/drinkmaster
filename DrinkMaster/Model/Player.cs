namespace DrinkMaster.Model
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
        }
        public string Name { get; set; }
        public int Score { get; set; }
    }

}
