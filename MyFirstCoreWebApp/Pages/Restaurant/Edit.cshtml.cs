using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Core;
using FirstApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFirstCoreWebApp.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RestaurantDS Rest { get; set; }

        public readonly IRestaurantData Irest;
        private readonly IHtmlHelper htmlHelper;
        public string stringTest = "this is a test string";
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData InterfaceRestaurant, IHtmlHelper htmlHelper)
        {
            this.Irest = InterfaceRestaurant;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(long restId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<ShopType>();
            if(restId == 00000)
            {
                Rest = new RestaurantDS();
            }
            else if(!restId.Equals(string.Empty))
            {
                Rest = Irest.GetRestuarantById(restId);
                Rest.PK = Rest.PartitionKey;
            }
            if (Rest == null)
            {
                return RedirectToPage("./List");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Cuisines = htmlHelper.GetEnumSelectList<ShopType>();
            Rest.PartitionKey = Rest.PK;
            if (Rest.RowKey == null)
            {
                string ID = Irest.GetCounts();
                Rest.RowKey = ID;
                Irest.Add(Rest);
                Irest.Commit();
            }
            else if(!Rest.RowKey.Equals(string.Empty))
            {
                Irest.Update(Rest);
                Irest.Commit();
            }
            TempData["Message"] = "Item saved!";
            return RedirectToPage("./Detail", new { restId = Rest.Id });
        }

    }
}