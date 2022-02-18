using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentitySample.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the IdentitySampleUser class
    public class IdentitySampleUser : IdentityUser
    {
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
    }
}
