using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;

namespace MvvmNotesApp.Droid
{
    /// <summary>
    /// Set the splash screen as the main launcher
    /// </summary>
    [Activity(Theme = "@style/MainTheme.Splash",
              MainLauncher = true,
              NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
