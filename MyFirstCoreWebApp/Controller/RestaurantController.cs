using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Core;
using FirstApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstCoreWebApp.ControllerSpace
{
    [Route("api/[controller]/[action]", Name = "[controller][action]")]
    //localhost:5001/api/Restaurant/test
    public class RestaurantController : Controller
    {
        public IEnumerable<RestaurantDS> MyRestList { get; set; }
        public readonly IRestaurantData Irest;
        public string searchTerm { get; set; }
        public RestaurantController(IRestaurantData rest)
        {
            this.Irest = rest;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListRes()
        {
            MyRestList = Irest.GetRestaurantByName(searchTerm);
            return View(MyRestList);
        }
    }
}