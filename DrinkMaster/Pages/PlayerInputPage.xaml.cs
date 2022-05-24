namespace DrinkMaster.Pages;

public partial class PlayerInputPage : ContentPage
{
	public PlayerInputPage()
	{
		InitializeComponent();

        BindingContext = new PlayerInputViewModel();
	}


	private void AddButtonClicked(object sender, EventArgs e)
    {
        
    }

    private async void goToCategories(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Categories(new ViewModels.CategoryViewModel()));
    }

    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

	public class PlayerInputViewModel
    {
		public PlayerInputViewModel()
        {
            Players = new List<Player>
            {
                new Player("jeffrey"),
                new Player("Test"),
            };
        }

        public List<Player> Players { get; set; }
    }
}