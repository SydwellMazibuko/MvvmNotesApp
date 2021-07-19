using MvvmNotesApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xamarin.Forms;

namespace MvvmNotesApp.ViewModels
{
    public class NoteEntryPageViewModel : BindableBase, IConfirmNavigation
    {
        private readonly Note _note;

        public NoteEntryPageViewModel()
        {
            _note = new Note();
        }

        public NoteEntryPageViewModel(Note note)
        {
            _note = note;
        }

        [Required]
        public string Title
        {
            get => _note.Title;
            set
            {
                _note.Title = value;
            }
        }

        [Required]
        public string Text
        {
            get => _note.Text;
            set
            {
                _note.Text = value;
            }
        }

        private DelegateCommand _saveCommand;

        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(Save));

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(Delete));


        private async void Save()
        {
            if(_note.Text != null & _note.Title != null)
            {
                _note.Date = DateTime.Now;

                await App.Database.SaveNoteAsync(_note);

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Value cannot be empty", "OK");
            }

            
        }

        private async void Delete()
        {
            await App.Database.DeleteNoteAsync(_note);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
