using MobileTestApp1.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
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
            this.BindingContext = new MyAccountViewModel();
        }

        private async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://vodafonecredittransfer20210525130039.azurewebsites.net/account/532543");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result>(stringResponse);
            Credit.Text = result.Credit_Balance_.ToString();
        }

        private class Result
        {
            public int CustomerID { get; set; }
            public int Mobile_or_Landline_Number_ { get; set; }
            public string Account_Password_ { get; set; }
            public decimal Credit_Balance_ { get; set; }
            public int Minutes_Balance { get; set; }
            public int Data_Balance_In_MB { get; set; }
            public bool Allow_Credit_transfer_request { get; set; }
            public bool On_contract { get; set; }
            public bool Allow_Notifications { get; set; }
            public int Current_Notification_Count { get; set; }
            public bool Is_Transfer_Verified { get; set; }
        }
    }
}