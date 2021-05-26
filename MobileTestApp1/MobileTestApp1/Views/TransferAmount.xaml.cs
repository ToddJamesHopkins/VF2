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
                await Shell.Current.GoToAsync($"TransAccepted?amount=10&number={NumberValue}");
                return;

                Loading.IsVisible = true;
                ConfirmButton.IsEnabled = false;

                var number = NumberValue;
                var amount = int.Parse(Amount.Text);
                var transfer = new Transfer
                {
                    Amount = amount,
                    FromNumber = number
                };
                var data = JsonConvert.SerializeObject(transfer);

                var client = new HttpClient();
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{ApiHelper.BaseUrl}/transfer/{number}", content);
                var stringResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<bool>(stringResponse);
                if (result)
                {
                    await Shell.Current.GoToAsync($"TransAccepted?amount={amount}&number={number}");
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