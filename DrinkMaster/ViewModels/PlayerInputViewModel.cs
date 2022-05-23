using DrinkMaster.Model;
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
   
    public PlayerInputViewModel()
    {
        // AddPlayerCommand = new Command(() => Players.Add(new Player(PlayerName)));
        AddPlayerCommand = new Command(() => Players.Add(new Player("Jeffrey")));
    }
    public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public ObservableCollection<Player> Players { get; } = new();

}