using System.Collections.ObjectModel;

namespace DrinkMaster.Model
{
    public class Game
    {
        public ObservableCollection<Player> Players;
        public Difficulty Difficulty { get; set; }
        public List<Category> Categories { get; set; }

        public Game()
        {
            Players = new ObservableCollection<Player>();
            Categories = new List<Category>();
        }
    }
}
