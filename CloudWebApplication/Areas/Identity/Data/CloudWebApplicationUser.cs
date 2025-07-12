using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CloudWebApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CloudWebApplicationUser class
public class CloudWebApplicationUser : IdentityUser
{
    [PersonalData]
    public string ? CustomerName { get; set; }

    [PersonalData]
    public int age { get; set; }

}

