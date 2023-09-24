using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList_App.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoList_App.Data;

namespace ToDoList_App.ViewModels
{
    //Fields
    public partial class NoteViewModel : ObservableObject
    {
        
        [ObservableProperty]
         string noteTitle;
        [ObservableProperty]
        string noteDescription;
        
        Note selectedNote;
        [ObservableProperty]
        ObservableCollection<Note> noteCollection;

        private NoteEntity DataHelper;

        public NoteViewModel()
        {
           noteCollection = new ObservableCollection<Note>();
            DataHelper = new NoteEntity();
            LoadData();
        }

        public Note SelectedNote
        {
            get => selectedNote;
            set
            {
                if (selectedNote != value)
                {
                    selectedNote = value;
                    NoteTitle = selectedNote.Title;
                    NoteDescription = selectedNote.Description;
                    OnPropertyChanged();
                }
            }
        }
        [RelayCommand]
        async void AddNote() 
        {

            //Set New Note
            var note = new Note
            {
                
                Title = NoteTitle,
                Description = NoteDescription,
            };
          await DataHelper.AddDataAsync(note);
            LoadData();
            //Rest Values
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
        }
        [RelayCommand]
        async void DeleteNote()
        {
            if (selectedNote != null)
            {
              await DataHelper.DeleteDataAsync(selectedNote);
                LoadData();

                //Rest Value
                NoteTitle = string.Empty;
                NoteDescription = string.Empty; 
            }

        }

        [RelayCommand]
        void EditNote()
        {
            if (selectedNote != null)
            {
                   
                     //Set new note
                        var newNote = new Note
                        {
                            Id = SelectedNote.Id,
                            Title = NoteTitle,
                            Description = NoteDescription,

                        };

                //Remove note
                DataHelper.UpdateDataAsync(newNote);
                LoadData();


            }
        }

        public async void LoadData()
        {
            NoteCollection.Clear();
            foreach (var note in await DataHelper.GetAllAsync())
            {
                NoteCollection.Add(note);
            }

        }
    }

   



  
}
