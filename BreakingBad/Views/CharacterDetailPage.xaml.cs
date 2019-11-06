using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakingBad.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BreakingBad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
        private readonly Character _character;

        public CharacterDetailPage(Character character)
        {
            _character = character;
            InitializeComponent();

            BindingContext = _character;

            Occupation.Text = $"Occupations: {string.Join(", ", _character.Occupation)}";
        }
    }
}