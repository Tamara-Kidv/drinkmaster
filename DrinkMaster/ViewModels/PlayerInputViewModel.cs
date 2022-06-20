using DrinkMaster.Model;
using DrinkMaster.Pages;
using DrinkMaster.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DrinkMaster.ViewModels;

public class PlayerInputViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string PlayerName { get; set; }
    //public IObservable<string> PlayerName;

    public ICommand AddPlayerCommand { get; private set; }
    public ICommand DelPlayerCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }

    public PlayerInputViewModel()
    {
        INavigation navigation = App.Current.MainPage.Navigation;

        AddPlayerCommand = new Command(() =>
        {
            Players.Add(new Player(PlayerName));
            PlayerName = null;

        });
        DelPlayerCommand = new Command((Player) =>
        {
            string name = Player.ToString();
            Players.Remove(new Player(name));
        });

        NextPageCommand = new Command(async () => await navigation.PushAsync(new StartPage()));
    }
    public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    
    public ObservableCollection<Player> Players { get; } = new();
}