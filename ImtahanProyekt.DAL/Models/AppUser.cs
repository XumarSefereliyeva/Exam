﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.DAL.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        
    }
}
