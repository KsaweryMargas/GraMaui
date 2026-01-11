using System.Net.Http.Json;

namespace GraMaui
{
    public partial class MainPage : ContentPage
    {
        // Konfiguracja połączenia z serwerem API
        HttpClient klient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5092")
        };

        public MainPage()
        {
            InitializeComponent();
            DaneApi(); // Pobierz dane na starcie
        }

        async void DaneApi()
        {
            // Pobierz listę tagów do Pickera
            PickerTagow.ItemsSource = await klient.GetFromJsonAsync<List<string>>("api/tags");
            // Pobierz wszystkie gry do listy
            ListaGier.ItemsSource = await klient.GetFromJsonAsync<List<ModelGry>>("api/games");
        }

        async void ZmianaTag(object sender, EventArgs e)
        {
            // Pobierz tekst wybranego tagu
            var tag = PickerTagow.SelectedItem.ToString();
            // Stwórz adres z filtrowaniem
            var url = $"api/games?tag={tag}";
            // Odśwież listę gier według tagu
            ListaGier.ItemsSource = await klient.GetFromJsonAsync<List<ModelGry>>(url);
        }
    }
}