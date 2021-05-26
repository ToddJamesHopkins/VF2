using MobileTestApp1.Helpers;
using MobileTestApp1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferNewPerson : ContentPage
    {
        public TransferNewPerson()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                Loading.IsVisible = true;
                ConfirmButton.IsEnabled = false;

                var number = int.Parse(Phone_Number.Text);
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync($"{ApiHelper.BaseUrl}/account/{number}"))
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Account>(stringResponse);
                        if (result.Number != default)
                        {
                            await Shell.Current.GoToAsync($"TransferAmount?number={result.Number}");
                        }
                    }
                }
            }
            catch
            {
                // Do nothing
            }
            finally
            {
                Loading.IsVisible = false;
                ConfirmButton.IsEnabled = true;
            }
        }
    }
}