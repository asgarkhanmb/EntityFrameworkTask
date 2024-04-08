using EntityFrameworkPractice.Migrations.Exceptions;
using EntityFrameworkPractice.Models;
using EntityFrameworkPractice.Services;
using EntityFrameworkPractice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Controllers
{
    internal class CityController
    {
       private readonly ICityService _cityService;

        public CityController()
        {
            _cityService = new CityService();
        }

        public async Task GetAllByCountryId()
        {
            Console.WriteLine("Add country id");

            int countryId = int.Parse(Console.ReadLine());

            var cities = await _cityService.GetAllByCountrIdAsync(countryId);

            foreach(var item in cities)
            {
                string data = $"Name:{item.Name}, CountryId: {item.Country.Name}";
                Console.WriteLine(data);
            }
        }


        public async Task GetAllCitiesAsync()
        {
            var datas = await _cityService.GetAllCitiesAsync();

            foreach (var item in datas)
            {
                string data = $"Name:{item.Name}, CountryId:{item.CountryId}";
                Console.WriteLine(data);
            }
        }

        public async Task GetCityByIdAsync()
        {
            Console.WriteLine("Add setting id");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var data = await _cityService.GetCityByIdAsync(id);

                if (data is null)
                {
                    throw new NotFoundException("Data notfound");
                }


                string result = $"Name:{data.Name}, CountryId: {data.CountryId}";
                Console.WriteLine(data);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        public async Task CreateCitiesAsync()
        {
            Console.WriteLine("Add name:");

            string name = Console.ReadLine();

            await _cityService.CreateCitiesAsync(new City { Name = name});
        }

        public async Task DeleteCitiesAsync()
        {
            Console.WriteLine("Add city id");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _cityService.DeleteCitiesAsync(id);
                Console.WriteLine("City deleted");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


    }
}
