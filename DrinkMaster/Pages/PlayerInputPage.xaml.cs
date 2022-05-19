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