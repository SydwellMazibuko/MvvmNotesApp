using MvvmNotesApp.Models;
using MvvmNotesApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmNotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPageViewModel ViewModel => BindingContext as NoteEntryPageViewModel;

        public NoteEntryPage()
        {
            InitializeComponent();
            if (BindingContext == null)
                BindingContext = new NoteEntryPageViewModel();
        }

        public NoteEntryPage(Note note) : this()
        {
            BindingContext = new NoteEntryPageViewModel(note);
        }

    }
}
