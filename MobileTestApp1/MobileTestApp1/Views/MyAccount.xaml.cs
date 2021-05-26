using MobileTestApp1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [QueryProperty(nameof(NumberValue), "number")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccount : ContentPage
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        public int NumberValue { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();

            try
            {
                var number = NumberValue;

                var client = new HttpClient();
                var response = await client.GetAsync($"https://vodafonecredittransfer20210525130039.azurewebsites.net/account/{number}");
                var stringResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Account>(stringResponse);
                Number.Text = $"Number: {number}";
                Credit.Text = $"Credit: ${result.Credit_Balance_}";
            }
            catch
            {
                // Finally
            }
            finally
            {
                Loading.IsVisible = false;
                Details.IsVisible = true;
            }
        }
    }
}