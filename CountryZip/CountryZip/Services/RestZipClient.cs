using CountryZip.Configurations;
using CountryZip.Helpers;
using CountryZip.Models;
using CountryZip.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Services
{
    public class RestZipClient : IRestZipClient
    {
        private readonly IServiceProvider _provider;
        public RestZipClient(IServiceProvider provider)
        {
            _provider = provider;
        }

        // открываем файл из Rest файла
        public byte[] GetFileCountries()
        {
            var client = new RestClient(FileHelper.nameHttp);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            try
            {
                var list = JsonConvert.DeserializeObject<CountriesConfiguration>(response.Content);

                CountryZp countries = new CountryZp();

                var scope = _provider.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<ObjCountryDBContext>();
                var _countryZp = scope.ServiceProvider.GetRequiredService<ICountryZpRepositories>();
                var _placeZp = scope.ServiceProvider.GetRequiredService<IPlaceZpRepositories>();

                //Формируем строку для вставки в т. CountryZp
                countries.PostCode = list.postCode;
                countries.Country = list.country;
                countries.CountryAbbreviation = list.countryAbbreviation;

                // определяем CountryNsiId =CountryNsi.Id
                CountryNsi countrynsi = _context.CountriesNsi.Where(countryn => countryn.Country == countries.Country).First();
                if (countrynsi != null)
                {
                    countries.CountryNsiId = countrynsi.Id;
                }

                //Делаем вставку строки в т. CountryZp, если нет по ключу CountryNsiId
                try
                {
                    CountryZp countryzp = _context.CountriesZp.Where(countryz => countryz.CountryNsiId == countries.CountryNsiId).First();
                }
                catch (Exception)
                {
                    _countryZp.AddCountryZp(countries);

                    //Формируем строку для вставки в т. PlaceZp
                    CountryZp countryzp = _context.CountriesZp.Where(countryz => countryz.CountryNsiId == countries.CountryNsiId).First();
                    if (countryzp != null)
                    {
                        foreach (var obj in list.places)
                        {
                            PlaceZp place = new PlaceZp();
                            place.PlaceName = obj.placeName;
                            place.Longitude = obj.longitude;
                            place.State = obj.state;
                            place.StateAbbreviation = obj.stateAbbreviation;
                            place.Latitude = obj.latitude;
                            place.CountryZpId = countryzp.Id;

                            //Делаем вставку строки в т. PlaceZp
                            _placeZp.AddPlaceZp(place);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                var message = e.Message;
            }

            var context = response.RawBytes;
            return context;
        }

        // открываем файл из Rest файла в кеш
        public byte[] GetFileCountriesCache(string nameHttp)
        {
            try
            {
                var client = new RestClient(nameHttp);
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);

                var context = response.RawBytes;
                return context;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }
        }

    }
}
