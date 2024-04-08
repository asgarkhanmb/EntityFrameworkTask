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
    internal class CountryService : ICountryService
    {
        private readonly AppDbContext _context;

        public CountryService()
        {
            _context = new AppDbContext();
        }
        public async Task CreateCountriesAsync(Country counting)
        {
            await _context.Countries.AddAsync(counting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(int id)
        {
            var data = _context.Countries.FirstOrDefault(m => m.Id == id);

            if (data is null) throw new NotFoundException("Data notfound");

            _context.Countries.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return _context.Countries.FirstOrDefault(m => m.Id == id);
        }
    }
}
