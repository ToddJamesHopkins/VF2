using MobileTestApp1.Helpers;
using MobileTestApp1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                Loading.IsVisible = true;
                LoginButton.IsEnabled = false;

                var number = int.Parse(Phone_Number.Text);
                var password = Password.Text;
                var loginDetails = new LoginDetails
                {
                    Number = number,
                    Password = password
                };

                var data = JsonConvert.SerializeObject(loginDetails);
                var client = new HttpClient();
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{ApiHelper.BaseUrl}/account/login", content);
                var stringResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(stringResponse);
                if (result)
                {
                    Application.Current.Properties["number"] = number;
                    await Shell.Current.GoToAsync($"//MyAccount?number={number}");
                }
            }
            catch
            {
                // Do nothing
            }
            finally
            {
                Loading.IsVisible = false;
                LoginButton.IsEnabled = true;
            }
        }
    }
}