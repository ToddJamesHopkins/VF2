using MobileTestApp1.Helpers;
using MobileTestApp1.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [QueryProperty(nameof(NumberValue), "number")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferAmount : ContentPage
    {
        public TransferAmount()
        {
            InitializeComponent();
        }

        public int NumberValue { get; set; }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Loading.IsVisible = true;
                ConfirmButton.IsEnabled = false;

                var number = NumberValue;
                var fromNumber = int.Parse(Application.Current.Properties["number"].ToString());
                var amount = decimal.Parse(Amount.Text);

                using (var client = new HttpClient())
                {
                    using (var accountResponse = await client.GetAsync($"{ApiHelper.BaseUrl}/account/{fromNumber}"))
                    {
                        var stringAccountResponse = await accountResponse.Content.ReadAsStringAsync();
                        var accountResult = JsonConvert.DeserializeObject<Account>(stringAccountResponse);
                        if (accountResult.Balance < amount)
                        {
                            throw new Exception("Not enough balance");
                        }
                    }

                    var transfer = new Transfer
                    {
                        Amount = amount,
                        FromNumber = fromNumber
                    };
                    var data = JsonConvert.SerializeObject(transfer);
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync($"{ApiHelper.BaseUrl}/transfer/{number}", content))
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<bool>(stringResponse);
                        if (result)
                        {
                            await Shell.Current.GoToAsync($"TransAccepted?amount={amount}&number={fromNumber}");
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