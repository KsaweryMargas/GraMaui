using System.Net.Http.Json;

namespace GraMaui
{
    public partial class MainPage : ContentPage
    {
        HttpClient klient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5092")
        };

        public MainPage()
        {
            InitializeComponent();
            DaneApi();
        }

        async void DaneApi()
        {
            PickerTagow.ItemsSource = await klient.GetFromJsonAsync<List<string>>("api/tags");
            ListaGier.ItemsSource = await klient.GetFromJsonAsync<List<ModelGry>>("api/games");
        }

        async void ZmianaTag(object sender, EventArgs e)
        {
            var tag = PickerTagow.SelectedItem.ToString();
            var url = $"api/games?tag={tag}";
            ListaGier.ItemsSource = await klient.GetFromJsonAsync<List<ModelGry>>(url);
        }
    }
}
