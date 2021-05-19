using MobileTestApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsError : ContentPage
    {
        public NotificationsError()
        {
            InitializeComponent();
            BindingContext = new NotificationsErrorViewModel2();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}