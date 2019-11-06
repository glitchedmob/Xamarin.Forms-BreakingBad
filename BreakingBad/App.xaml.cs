using System.Net.Http;
using BreakingBad.Views;
using Xamarin.Forms;

namespace BreakingBad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<HttpClient>();

            MainPage = new NavigationPage(new CharactersPage())
            {
                BarBackgroundColor = Color.FromHex("#146335"),
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
