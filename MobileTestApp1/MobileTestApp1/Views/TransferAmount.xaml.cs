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
    public partial class TransferAmount : ContentPage
    {
        public static int CredType = 0;
        public TransferAmount()
        {
            InitializeComponent();
        }

        private void PickerItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker selecteditem = (Picker)sender;
            CredType = selecteditem.SelectedIndex;
        }
    }
}