using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocExpressMobile.Models;
using LocExpressMobile.Services;

using System.Collections.ObjectModel;


namespace LocExpressMobile.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ApiService _apiService;
        //public ObservableCollection<RentalAd> AdList { get; set; }


        private ObservableCollection<CardModel> adCardsList;
        public ObservableCollection<CardModel> AdCardsList
        {
            get => adCardsList;
            set
            {
                adCardsList = value;
                OnPropertyChanged();
            }
        }

        //[ObservableProperty, AllowNull]
        public string input;



        public MainViewModel()
        {
            AdCardsList = new();
            _apiService = new();
        }

        public async Task InitializeAsync()
        {
            var list = await _apiService.GetAllRentalAdsAsync();
            //AdList = new ObservableCollection<RentalAd>(list);
            foreach (var ad in list)
            {
                AdCardsList.Add(new CardModel
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    City = ad.City,
                    PostCode = ad.PostCode,
                    Surface = ad.Surface,
                    RoomsNumber = ad.RoomsNumber,
                    BedroomsNumber = ad.BedroomsNumber,
                    Rent = ad.Rent + ad.RentalCharges,
                    Description = ad.Description,
                    OwnerId = ad.OwnerId,
                    TypeId = ad.TypeId,
                    CreationDate = ad.CreationDate,
                    EnergyCategoryId = ad.EnergyCategoryId,
                });
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

    }
}
