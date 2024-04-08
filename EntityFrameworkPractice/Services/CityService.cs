using EntityFrameworkPractice.Data;
using EntityFrameworkPractice.Migrations.Exceptions;
using EntityFrameworkPractice.Models;
using EntityFrameworkPractice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Services
{
    internal class CityService : ICityService
    {
        private readonly AppDbContext _context;

        public CityService()
        {
            _context = new AppDbContext();
        }

        public async Task CreateCitiesAsync(City citing)
        {
            await _context.Cities.AddAsync(citing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCitiesAsync(int id)
        {
            var data = _context.Cities.FirstOrDefault(m => m.Id == id);

            if (data is null) throw new NotFoundException("Data notfound");

            _context.Cities.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllByCountrIdAsync(int id)
        {
            var cities = await _context.Cities.Include(m=>m.Country).Where(m => m.CountryId == id).ToListAsync();
            return cities;
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return _context.Cities.FirstOrDefault(m => m.Id == id);
        }
    }
    
}
