﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstCoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Message = "Hello World";
        public void OnGet()
        {

        }
    }
}
