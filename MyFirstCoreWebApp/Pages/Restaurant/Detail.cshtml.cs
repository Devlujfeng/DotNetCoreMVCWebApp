using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FirstApp.Data;

namespace MyFirstCoreWebApp.Pages.Restaurant
{
    public class DetailModel : PageModel
    {

        public RestaurantDS Rest { get; set; }
        public readonly IRestaurantData Irest;
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData InterfaceRestaurant)
        {
          this.Irest = InterfaceRestaurant;
        }

        //public void OnGet(long restId)
        public IActionResult OnGet(long restId)
        {
            Rest = Irest.GetRestuarantById(restId);
            if(Rest == null)
            {
                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}