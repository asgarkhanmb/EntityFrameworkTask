using EntityFrameworkPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Services.Interfaces
{
    internal interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task CreateCountriesAsync(Country counting);
        Task DeleteCountryAsync(int id);
        Task<Country> GetCountryByIdAsync(int id);
    }
}
