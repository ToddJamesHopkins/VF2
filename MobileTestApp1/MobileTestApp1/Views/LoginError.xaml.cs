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
    public partial class LoginError : ContentPage
    {
        public LoginError()
        {
            InitializeComponent();
            BindingContext = new LoginErrorViewModel();
        }
    }
}