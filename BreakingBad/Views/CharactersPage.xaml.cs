using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BreakingBad.Model;
using Newtonsoft.Json;
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

        protected async override void OnAppearing()
        {
            ListView.ItemsSource = await GetCharacters();
        }

        private async Task<List<Character>> GetCharacters()
        {
            var charactersJson = "";
            
            if (Application.Current.Properties.ContainsKey("characters"))
            {
                charactersJson = Application.Current.Properties["characters"] as string;
            }
            else
            {
                var request = await _httpClient.GetAsync("https://www.breakingbadapi.com/api/characters/");
                charactersJson = await request.Content.ReadAsStringAsync();
                Application.Current.Properties["characters"] = charactersJson;
                await Application.Current.SavePropertiesAsync();
            }

            return JsonConvert.DeserializeObject<List<Character>>(charactersJson);
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCharacter = (Character) e.SelectedItem;

            await Navigation.PushAsync(new CharacterDetailPage(selectedCharacter));
        }
    }
}