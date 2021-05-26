using MobileTestApp1.Helpers;
using MobileTestApp1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccount : ContentPage
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();

            try
            {
                var number = int.Parse(Application.Current.Properties["number"].ToString());
                var client = new HttpClient();
                var response = await client.GetAsync($"{ApiHelper.BaseUrl}/account/{number}");
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