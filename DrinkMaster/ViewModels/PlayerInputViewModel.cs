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
    public string PlayerName { get; set; }

    public ICommand AddPlayerCommand { get; private set; }
    public ICommand DelPlayerCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }

    public PlayerInputViewModel()
    {
        INavigation navigation = App.Current.MainPage.Navigation;

        AddPlayerCommand = new Command(() =>
        {
            if (PlayerName == null || PlayerName == "")
            {
                return;
            }
            Players.Add(new Player(PlayerName));
            PlayerName = "";

        });
        DelPlayerCommand = new Command((Player) =>
        {
            string name = Player.ToString();
            foreach (Player player in Players)
            {
                if (player.Name == name)
                {
                    Players.Remove(player);
                    break;
                }
            }
        });

        NextPageCommand = new Command(async () => 
        {
            Game game = new()
            {
                Players = Players
            };
            await navigation.PushAsync(new DifficultyPage(game));
        });
    }
    public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    
    public ObservableCollection<Player> Players { get; } = new();
}