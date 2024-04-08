﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Models
{
    internal class Setting : BaseEntity
    {
        public string Address { get; set; } 
        public string Email { get; set; }   
        public string Phone  { get; set; }
        public  string Name { get; set; }
    }
}
