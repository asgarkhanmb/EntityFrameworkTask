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
    internal class SettingService : ISettingService
    {
        private readonly AppDbContext _context;

        public SettingService()
        {
            _context = new AppDbContext();
        }

        public async Task CreateAsync(Setting setting)
        {
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Settings.FirstOrDefault(m => m.Id == id);

            if (data is null) throw new NotFoundException("Data notfound");
            
            _context.Settings.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return  _context.Settings.FirstOrDefault(m=>m.Id == id);
        }

        public Task UpdateAsync(Setting setting)
        {
            throw new NotImplementedException();
        }
    }
}
