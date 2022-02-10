﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
