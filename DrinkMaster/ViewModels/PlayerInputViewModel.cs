using DrinkMaster.Model;
using DrinkMaster.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DrinkMaster.ViewModels;

public class PlayerInputViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private string _PlayerName;
    public string PlayerName
    {
        get => _PlayerName;
        set
        {
            _PlayerName = value;
            OnPropertyChanged(nameof(PlayerName));
        }
    }

    public ICommand AddPlayerCommand { get; private set; }
    public ICommand DelPlayerCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }

    public PlayerInputViewModel()
    {
        INavigation navigation = App.Current.MainPage.Navigation;

        // Add player to game
        AddPlayerCommand = new Command(() =>
        {
            if (PlayerName is null or "")
            {
                return;
            }
            Players.Add(new Player(PlayerName));
            PlayerName = "";

        });
        // Remove Player from the game
        DelPlayerCommand = new Command((Player) =>
        {
            string name = Player.ToString();
            foreach (Player player in Players)
            {
                if (player.Name == name)
                {
                    _ = Players.Remove(player);
                    break;
                }
            }
        });

        // Go to the next page
        NextPageCommand = new Command(async () =>
        {
            // Do nothing if there are no players.
            if (Players.Count == 0)
            {
                return;
            }
            // Create new game, and add players to game
            Game game = new()
            {
                Players = Players
            };
            // Navigate to the next page.
            await navigation.PushAsync(new DifficultyPage(game));
        });
    }
    public void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public ObservableCollection<Player> Players { get; } = new();
}