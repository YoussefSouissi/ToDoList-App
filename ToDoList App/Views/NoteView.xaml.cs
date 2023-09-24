using ToDoList_App.ViewModels;

namespace ToDoList_App.Views;

public partial class NoteView : ContentView
{
	public NoteView()
	{
		InitializeComponent();
		BindingContext = new NoteViewModel();
    }
}