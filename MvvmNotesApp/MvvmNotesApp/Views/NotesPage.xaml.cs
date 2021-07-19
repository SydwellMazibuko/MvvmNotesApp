using MvvmNotesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmNotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        // private NotesPageViewModel ViewModel => BindingContext as NotesPageViewModel;

        public NotesPage()
        {
            InitializeComponent();
            // this.BindingContext = new NotesPageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Get all the notes from the database, and set them as the
            // data source for the listView. 
            listView.ItemsSource = await App.Database.GetNotesAsync();

        } 

    }
}
