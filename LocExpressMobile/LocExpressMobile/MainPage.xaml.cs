using LocExpressApi.Shared.Models;

namespace LocExpressMobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        List<RentalAd> list = new List<RentalAd>();


        public MainPage()
        {
            InitializeComponent();

        }


        public async Task GetRentalAds()
        {

        }
        //private void OnCounterClicked(object? sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }
}
