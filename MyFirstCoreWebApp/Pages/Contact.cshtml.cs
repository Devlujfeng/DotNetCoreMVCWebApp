using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstCoreWebApp.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete()
        {
            //2. HttpContext.Request.QueryString

            //3. SearchString property Bind


            //MyRestList = Irest.GetRestaurantByName(searchTerm);
            return Page();
        }
    }
}
