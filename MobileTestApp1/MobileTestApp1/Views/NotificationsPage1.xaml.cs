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
    public partial class NotificationsPage1 : ContentPage
    {
        public NotificationsPage1()
        {
            InitializeComponent();
            this.BindingContext = new NotificationsErrorViewModel2();
          
         
        }
    }
}