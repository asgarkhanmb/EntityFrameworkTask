using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Models
{
    internal class Country:BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Population { get; set; }
        public List<City> Cities { get; set; }  
    }
}
