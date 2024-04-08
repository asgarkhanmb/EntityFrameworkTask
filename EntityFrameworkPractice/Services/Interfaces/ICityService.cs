using EntityFrameworkPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Services.Interfaces
{
    internal interface ICityService
    {
        Task<List<City>> GetAllByCountrIdAsync(int id);
        Task<List<City>> GetAllCitiesAsync();
        Task CreateCitiesAsync(City citing);
        Task DeleteCitiesAsync(int id);
        Task<City> GetCityByIdAsync(int id);


    }
}
