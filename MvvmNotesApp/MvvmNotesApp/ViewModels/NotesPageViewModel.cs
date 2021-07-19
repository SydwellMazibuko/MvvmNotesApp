using MvvmNotesApp.Models;
using MvvmNotesApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MvvmNotesApp.ViewModels
{
    public class NotesPageViewModel : BindableBase, IConfirmNavigation
    {
        public ObservableCollection<Note> Notes { get; set; }

        private Note _selectedNote;
        public Note SelectedNote
        {
            get => _selectedNote;
            set => SetProperty(ref _selectedNote, value);
        }

        // Register your type for navigation
        private DelegateCommand _addNoteCommand;
        private readonly INavigationService _navigationService;

        // Get the navigation service
        public NotesPageViewModel(INavigationService navigationService)
        {
            Notes = new ObservableCollection<Note>();
            _navigationService = navigationService;
        }


        public DelegateCommand AddNoteCommand =>
            _addNoteCommand ?? (_addNoteCommand = new DelegateCommand(AddNote));

        private DelegateCommand _loadNotesCommand;

        public DelegateCommand LoadNotesCommand => 
            _loadNotesCommand ?? (_loadNotesCommand = new DelegateCommand(LoadNotes));

        private DelegateCommand<object> _selectCommand;
        public DelegateCommand<object> SelectCommand => 
            _selectCommand ?? (_selectCommand = new DelegateCommand<object>(SelectNote));


        private async void LoadNotes()
        {

            // Notes.Clear();

            var notes = await App.Database.GetNotesAsync();

            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }

        private async void SelectNote(object eveArgs)
        {
            if (eveArgs is SelectedItemChangedEventArgs arg && arg.SelectedItem is Note note)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new NoteEntryPage(note));
                ///await _navigationService.NavigateAsync("NoteEntryPage");

            }

            SelectedNote = null;
        }

        private async void AddNote()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NoteEntryPage());
            // await _navigationService.NavigateAsync("NoteEntryPage");
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
