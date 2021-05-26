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
            Routing.RegisterRoute(nameof(NotificationsError), typeof(NotificationsError));
            Routing.RegisterRoute(nameof(TransAccepted), typeof(TransAccepted));
            Routing.RegisterRoute(nameof(TransError), typeof(TransError));
            Routing.RegisterRoute(nameof(RequestSent), typeof(RequestSent));
            Routing.RegisterRoute(nameof(RequestError), typeof(RequestError));
            Routing.RegisterRoute(nameof(LoginError), typeof(LoginError));
            Routing.RegisterRoute(nameof(TransferPage), typeof(TransferPage));
            Routing.RegisterRoute(nameof(RequestTransfer), typeof(RequestTransfer));
            Routing.RegisterRoute(nameof(TransferNewPerson), typeof(TransferNewPerson));
            Routing.RegisterRoute(nameof(RequestNewPerson), typeof(RequestNewPerson));
            Routing.RegisterRoute(nameof(TransferAmount), typeof(TransferAmount));
            Routing.RegisterRoute(nameof(RequestAmount), typeof(RequestAmount));
            Routing.RegisterRoute(nameof(MyAccount), typeof(MyAccount));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(TransferFavourites), typeof(TransferFavourites));
            Routing.RegisterRoute(nameof(RequestFavourites), typeof(RequestFavourites));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
            FlyoutIsPresented = false;
        }
    }
}
