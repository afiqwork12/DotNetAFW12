using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMCVTogetherApp.Models
{
    public class UserCustomer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name="Re-Type Password")]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Range(18, 55, ErrorMessage = "Invalid Age")]
        public int Age { get; set; }
        public override string ToString()
        {
            return Username + " " + Password + " " + Name + " " + Role + " " + Age;
        }
    }
}
