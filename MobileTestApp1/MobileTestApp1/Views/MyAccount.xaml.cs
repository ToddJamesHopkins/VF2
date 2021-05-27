using MobileTestApp1.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            this.BindingContext = new MyAccountViewModel();
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    string a = await GetProductAsync(@"https://vodafonecredittransfer20210525130039.azurewebsites.net/account/532543");
        //}

        //static HttpClient client = new HttpClient();

        //async Task<string> GetProductAsync(string path)
        //{
        //    HttpResponseMessage response = await client.GetAsync(path);

        //    Account_Details_TBL accout = JsonConvert.DeserializeObject<Account_Details_TBL>(await response.Content.ReadAsStringAsync());

        //    return $"name: {accout.Mobile_or_Landline_Number_}";

        //}

        //public class Account_Details_TBL
        //{
        //    public int CustomerID { get; set; }
        //    public int Mobile_or_Landline_Number_ { get; set; }
        //    public string Account_Password_ { get; set; }
        //    public decimal Credit_Balance_ { get; set; }
        //    public int Minutes_Balance { get; set; }
        //    public int Data_Balance_In_MB { get; set; }
        //    public bool Allow_Credit_transfer_request { get; set; }
        //    public bool On_contract { get; set; }
        //    public bool Allow_Notifications { get; set; }
        //    public int Current_Notification_Count { get; set; }
        //    public bool Is_Transfer_Verified { get; set; }
        //}
    }
}