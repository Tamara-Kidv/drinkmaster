using DrinkMaster.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DrinkMaster.Views
{
    public class PlayerInputView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string PlayerName { get; set; }
        public ICommand RemPlayerCommand { get; private set; }

        public PlayerInputView(string playerName)
        {
            PlayerName = playerName;
            RemPlayerCommand = new Command(() =>
            {
                PlayerName = "removed.";

            });
        }
        public void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
