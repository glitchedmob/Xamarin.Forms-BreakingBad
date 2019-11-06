using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var request = await _httpClient.GetAsync("https://www.breakingbadapi.com/api/characters/");
            var response = await request.Content.ReadAsStringAsync();

            var characters = JsonConvert.DeserializeObject<List<Character>>(response);
        }
    }
}