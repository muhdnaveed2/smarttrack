using Xamarin.Forms;

namespace smarttrack
{
	public class App : Application
	{
		public static bool IsUserLoggedIn { get; set; }
        public static string UserToken { get; set; }

		public App ()
		{
			if (!IsUserLoggedIn) {
				MainPage = new NavigationPage (new LoginPage ());
			} else {
				MainPage = new NavigationPage (new smarttrack.MainPage ());
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

