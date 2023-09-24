namespace ToDoList_App;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		Container.Content = new Views.NoteView();
	}


	
}

