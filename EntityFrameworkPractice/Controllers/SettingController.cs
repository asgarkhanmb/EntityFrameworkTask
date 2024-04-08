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
    internal class SettingController
    {
        private readonly ISettingService _settingService;

        public SettingController()
        {
            _settingService = new SettingService();
        }

        public async Task GetAllAsync()
        {
            var datas = await _settingService.GetAllAsync();

            foreach (var item in datas)
            {
                string data = $"Name:{item.Name}, Email:{item.Email}, Phone:{item.Phone}, Address:{item.Address}";
                Console.WriteLine(data);
            }
        }
        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add setting id");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var data = await _settingService.GetByIdAsync(id);

                if(data is null)
                {
                    throw new NotFoundException("Data notfound");
                }


                string result = $"Name:{data.Name}, Email:{data.Email}, Phone:{data.Phone}, Address:{data.Address}";
                Console.WriteLine(data);

            }
            catch (Exception ex)
            {

               Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Add name:");

            string name = Console.ReadLine();


            Console.WriteLine("Add address:");

            string address = Console.ReadLine();

            Console.WriteLine("Add email:");

            string email = Console.ReadLine();

            Console.WriteLine("Add phone:");

            string phone = Console.ReadLine();


            await _settingService.CreateAsync(new Setting { Name = name, Email = email, Address = address, Phone = phone });
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add setting id");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                await _settingService.DeleteAsync(id);
                Console.WriteLine("Data deleted");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
      
    }
}
