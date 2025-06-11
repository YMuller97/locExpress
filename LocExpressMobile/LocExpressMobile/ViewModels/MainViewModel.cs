using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocExpressMobile.Models;
using LocExpressMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocExpressMobile.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        private ObservableCollection<RentalAd> _adList;
        public ObservableCollection<RentalAd> AdList
        {
            get => _adList;
            set 
            { 
                _adList = value; 
                OnPropertyChanged(); 
            }
        }




        //[ObservableProperty]
        //List<RentalAd> ads;

        //[ObservableProperty, AllowNull]
        public string input;



        public MainViewModel()
        {
            AdList = new();
            _apiService = new();
        }

        //private async Task GetRentalAds()
        //{
            
        //}

        public async Task InitializeAsync()
        {
            var list = await _apiService.GetAllRentalAdsAsync();
            AdList = new ObservableCollection<RentalAd>(list);
        }

    }
}
