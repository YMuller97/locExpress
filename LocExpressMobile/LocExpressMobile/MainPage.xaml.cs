using LocExpressMobile.Models;
using LocExpressMobile.Services;
using LocExpressMobile.ViewModels;
using System.Windows.Input;

namespace LocExpressMobile
{
    public partial class MainPage : ContentPage
    {

        private readonly MainViewModel _viewModel;
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await _viewModel.InitializeAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        protected async void Refresh(object sender, EventArgs e)
        {
            await _viewModel.InitializeAsync();
            Console.WriteLine("click");
        } 
    }
}
