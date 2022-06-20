using System.Collections;

namespace DrinkMaster.Pages;

public partial class QuestionsListPage : ContentPage
{
	public QuestionsListPage()
	{
		InitializeComponent();

        var arrayListQuestions = new ArrayList();
		arrayListQuestions.Add("Vraag1");
        arrayListQuestions.Add("Vraag2");
        arrayListQuestions.Add("Vraag3");
        arrayListQuestions.Add("Vraag4");
        arrayListQuestions.Add("Vraag5");
        arrayListQuestions.Add("Vraag6");
    }
}