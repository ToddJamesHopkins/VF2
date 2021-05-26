using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTestApp1.Views
{
    [QueryProperty(nameof(Amount), "amount")]
    [QueryProperty(nameof(NumberValue), "number")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransAccepted : ContentPage
    {
        public TransAccepted()
        {
            InitializeComponent();
        }

        public int Amount { get; set; }
        public int NumberValue { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Yield();

            Loading.IsVisible = false;
            Details.IsVisible = true;
            DetailsLabel.Text = $"${Amount} transferred to {NumberValue}";
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.Navigation.PopToRootAsync(false);
            await Shell.Current.GoToAsync($"//MyAccount", false);
        }
    }
}