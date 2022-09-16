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
    private string _PlayerAvatar;
    public string avatarOne { get; set; } = "avatar1.jpg";
    public string avatarTwo { get; set; } = "avatar2.jpg";
    public string avatarThree { get; set; } = "avatar3.jpg";
    public string avatarFour { get; set; } = "avatar4.jpg";
    public string avatarFive { get; set; } = "avatar5.jpg";
    public string avatarSix { get; set; } = "avatar6.jpg";

    public string PlayerName
    {
        get => _PlayerName;
        set
        {
            _PlayerName = value;
            OnPropertyChanged(nameof(PlayerName));
        }
    }

    public string PlayerAvatar
    {
        get => _PlayerAvatar;
        set
        {
            _PlayerAvatar = value;
            OnPropertyChanged(nameof(PlayerAvatar));
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
            Players.Add(new Player(PlayerName, PlayerAvatar));
            PlayerName = "";
            PlayerAvatar = "";

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