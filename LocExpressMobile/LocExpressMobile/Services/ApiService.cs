using LocExpressMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocExpressMobile.Services
{
    class ApiService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        Uri baseUri = new Uri("http://localhost:5000/api/");

        public ObservableCollection<RentalAd> RentalAds { get; private set; }

        public ApiService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<RentalAd>> GetAllRentalAdsAsync()
        {
            var RentalAds = new ObservableCollection<RentalAd>();
            //Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(baseUri.AbsoluteUri + "ads");
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    RentalAds = JsonSerializer.Deserialize<ObservableCollection<RentalAd>>(content, _serializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return RentalAds;
        }

        public async Task<RentalAd> GetByIdAsync(int id)
        {
            RentalAd ad = new RentalAd();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(baseUri.AbsoluteUri + $"ads/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ad = JsonSerializer.Deserialize<RentalAd>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ad;
        }
    }
}
