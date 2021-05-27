using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileTestApp1.ViewModels
{
    public class MyAccountViewModel : BaseViewModel
    {
        public string NameText { get; set; }
        public int MyProperty { get; }
        public Command LoadedCommand { get; }

        public MyAccountViewModel()
        {
            Title = "My Account";
            NameText = "One";

            LoadedCommand = new Command(async() => await ExecuteCommand());
        }

        static HttpClient client = new HttpClient();

        async Task ExecuteCommand()
        {
            Debug.WriteLine("note A");
            HttpResponseMessage response = await client.GetAsync("https://vodafonecredittransfer20210525130039.azurewebsites.net/account/532543");

            Account_Details_TBL accout = JsonConvert.DeserializeObject<Account_Details_TBL>(await response.Content.ReadAsStringAsync());
            
            NameText = $"Two";
            Debug.WriteLine("note B " + NameText);
        }

        

        

        public class Account_Details_TBL
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
