using DrinkMaster.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DrinkMaster.ViewModels;
public class DifficultyPageViewModel
{
    public DifficultyPageViewModel()
    {
    
    }
    public void ZeerMoeilijkOnClicked(object sender, EventArgs e)
    {
        new ViewModels.DifficultyPageViewModel(); //Change to your page.
    }

}