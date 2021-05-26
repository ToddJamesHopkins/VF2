using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestAmount : ContentPage
    {
        public static int CredType = 0;

        public RequestAmount()
        {
            InitializeComponent();
        }

        private void PickerItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecteditem = (Picker)sender;
            CredType = selecteditem.SelectedIndex;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}