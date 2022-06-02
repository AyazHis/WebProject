using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace WebProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WPUser class
public class WPUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? PostIndex { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? House { get; set; }
}
