﻿using MobileTestApp1.ViewModels;
using MobileTestApp1.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileTestApp1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(Test2), typeof(Test2));
            Routing.RegisterRoute(nameof(NotificationsError), typeof(NotificationsError));
            Routing.RegisterRoute(nameof(TransAccepted), typeof(TransAccepted));
            Routing.RegisterRoute(nameof(TransError), typeof(TransError));
            Routing.RegisterRoute(nameof(RequestSent), typeof(RequestSent));
            Routing.RegisterRoute(nameof(RequestError), typeof(RequestError));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
