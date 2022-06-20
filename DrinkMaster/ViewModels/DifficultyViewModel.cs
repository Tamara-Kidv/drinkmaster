using DrinkMaster.Model;
using DrinkMaster.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DrinkMaster.ViewModels;
public class DifficultyViewModel
{
    public DifficultyViewModel(Game game)
    {
        INavigation navigation = App.Current.MainPage.Navigation;
        SetDifficultyCommand = new Command(async (difficulty) =>
        {
            //Difficulty difficulty = Difficulty.Normal;
            switch (difficulty)
            {
                case "Easy":
                    game.Difficulty = Difficulty.Easy;
                    break;
                case "Normal":
                    game.Difficulty = Difficulty.Normal;
                    break;
                case "Hard":
                    game.Difficulty = Difficulty.Hard;
                    break;
                case "VeryHard":
                    game.Difficulty = Difficulty.VeryHard;
                    break;
                default:
                    break;
            }
            await navigation.PushAsync(new StartPage());
        });
    }

    public Command SetDifficultyCommand { get; private set; }
}