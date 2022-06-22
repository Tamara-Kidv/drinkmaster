using DrinkMaster.Model;
using DrinkMaster.ViewModels;

namespace DrinkMaster.Pages;

public partial class LeaderboardPage : ContentPage
{
	public LeaderboardPage(Game game)
	{
        LeaderboardViewModel viewModel = new();
        BindingContext = viewModel;
		InitializeComponent();
	}

    //public void getplayerscores_default_returnsscoresforallgameraces()
    //{
    //    var game = substitute.for<igame>();

    //    var race1 = substitute.for<irace>();
    //    var race2 = substitute.for<irace>();

    //    var player1 = substitute.for<iraceplayer>();
    //    var player2 = substitute.for<iraceplayer>();

    //    player1.position.returns(1);
    //    player2.position.returns(2);

    //    var players = new dictionary<character, iraceplayer>();
    //    players.add(character.mario, player1);
    //    players.add(character.luigi, player2);

    //    race1.players.returns(players);
    //    race2.players.returns(players);

    //    var races = new list<irace>() { race1, race2 };
    //    game.races.returns(races);

    //    var leaderboard = new leaderboard();
    //    var expectedscores = new dictionary<character, int>();

    //    expectedscores.add(character.mario, constants.firstplacepoints * 2);
    //    expectedscores.add(character.luigi, constants.secondplacepoints * 2);

    //    leaderboard.getplayerscores(game).shouldbeequivalentto(expectedscores);
    //}
}