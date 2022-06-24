using DrinkMaster.Model;

namespace DrinkMaster.ViewModels;

public class LeaderboardViewModel : ContentView
{
    public List<Player> LeaderBoard { get; set; }
    public LeaderboardViewModel(Game game)
    {
        LeaderBoard = game.Players.OrderByDescending(p => p.Score).ToList();
    }
}