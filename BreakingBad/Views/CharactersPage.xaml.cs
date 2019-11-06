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
            var url = "https://gist.githubusercontent.com/glitchedmob/373e1ebf69d2c90cbf1a98322b0d77b7/raw/2ab6ab26f6dd9b763ff9fe725454ed7e4492f80d/breakingbadcharacters.json";
            var request = await _httpClient.GetAsync(url);
            var charactersJson = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Character>>(charactersJson);
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCharacter = (Character) e.SelectedItem;

            await Navigation.PushAsync(new CharacterDetailPage(selectedCharacter));
        }
    }
}