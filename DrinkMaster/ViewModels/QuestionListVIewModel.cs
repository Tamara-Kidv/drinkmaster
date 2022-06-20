namespace DrinkMaster.ViewModels;

public class QuestionListVIewModel : ContentView
{
	public QuestionListVIewModel()
	{
		Content = new StackLayout
		{
			Children = {
				new Label { Text = "Welcome to .NET MAUI!" }
			}
		};
	}
}