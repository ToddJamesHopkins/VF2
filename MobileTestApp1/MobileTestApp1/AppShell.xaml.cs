using MobileTestApp1.Views;
using System;
using Xamarin.Forms;

namespace MobileTestApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TransferNewPerson), typeof(TransferNewPerson));
            Routing.RegisterRoute(nameof(TransferAmount), typeof(TransferAmount));
            Routing.RegisterRoute(nameof(TransAccepted), typeof(TransAccepted));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
            FlyoutIsPresented = false;
        }
    }
}
