using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name cannot be empty")]
        public string Name { get; set; }
        [Range(18,55,ErrorMessage = "Invalid Age")]
        public int Age { get; set; }
    }
}
