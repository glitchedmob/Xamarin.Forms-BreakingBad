using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BreakingBad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {
        private HttpClient _httpClient;

        public CharactersPage()
        {
            _httpClient = DependencyService.Get<HttpClient>();
            InitializeComponent();
        }
    }
}