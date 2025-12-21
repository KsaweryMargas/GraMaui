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
        }
    }
}
