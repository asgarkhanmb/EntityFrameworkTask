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
    internal class CountryController
    {
        private readonly ICountryService _countryService;


        public CountryController()
        {
            _countryService = new CountryService();
        }


        public async Task GetAllCountriesAsync()
        {
            var datas = await _countryService.GetAllCountriesAsync();

            foreach (var item in datas)
            {
                string data = $"Name:{item.Name}, CountryId:{item.Id}";
                Console.WriteLine(data);
            }
        }

        public async Task GetCountriesByIdAsync()
        {
            Console.WriteLine("Add country id");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var data = await _countryService.GetCountryByIdAsync(id);

                if (data is null)
                {
                    throw new NotFoundException("Data notfound");
                }


                string result = $"Name:{data.Name}, CountryId: {data.Id}";
                Console.WriteLine(data);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        public async Task CreateCountryAsync()
        {
            Console.WriteLine("Add name:");

            string name = Console.ReadLine();

            await _countryService.CreateCountriesAsync(new Country { Name = name });
        }

        public async Task DeleteCountriesAsync()
        {
            Console.WriteLine("Add country id");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _countryService.DeleteCountryAsync(id);
                Console.WriteLine("Country deleted");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
    

}
