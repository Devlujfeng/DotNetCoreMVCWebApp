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
    public class RestaurantModel : PageModel
    {
        public IEnumerable<RestaurantDS> MyRestList { get; set; }
        public readonly IRestaurantData Irest;
        [BindProperty(SupportsGet =true)]
        public string searchTerm { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        private readonly IHtmlHelper htmlHelper;
        public RestaurantModel(IRestaurantData rest, IHtmlHelper htmlHelper)
        {
            this.Irest = rest;
            this.htmlHelper = htmlHelper;
        }


        //1. public void OnGet(string searchTerm) this is querystring 
        public void OnGet()
        {
            //2. HttpContext.Request.QueryString

            //3. SearchString property Bind
            Cuisines = htmlHelper.GetEnumSelectList<ShopType>();

            MyRestList = Irest.GetRestaurantByName(searchTerm);
        }

        public ActionResult OnPost()
        {
            return Page();
        }

        public ActionResult OnGetDelete(int? shopId)
        {
            //2. HttpContext.Request.QueryString

            //3. SearchString property Bind


            MyRestList = Irest.GetRestaurantByName(searchTerm);
            return Page();
        }

        //public ActionResult Index(string id)
        //{
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        // Get particular student info  
        //        TableManager TableManagerObj = new TableManager("person"); // 'person' is the name of the table  
        //                                                                   // pass query where RowKey eq value of id
        //        List<Student> SutdentListObj = TableManagerObj.RetrieveEntity<Student>("RowKey eq '" + id + "'");
        //        Student StudentObj = SutdentListObj.FirstOrDefault();
        //        return View(StudentObj);
        //    }
        //    return View(new Student());
        //}

        //[HttpPost]
        //public ActionResult Index(string id, FormCollection formData)
        //{
        //    Student StudentObj = new Student();
        //    StudentObj.Name = formData["Name"] == "" ? null : formData["Name"];
        //    StudentObj.Department = formData["Department"] == "" ? null : formData["Department"];
        //    StudentObj.Email = formData["Email"] == "" ? null : formData["Email"];

        //    // Insert  
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        StudentObj.PartitionKey = "Student";
        //        StudentObj.RowKey = Guid.NewGuid().ToString();

        //        TableManager TableManagerObj = new TableManager("person");
        //        TableManagerObj.InsertEntity<Student>(StudentObj, true);
        //    }
        //    // Update  
        //    else
        //    {
        //        StudentObj.PartitionKey = "Student";
        //        StudentObj.RowKey = id;

        //        TableManager TableManagerObj = new TableManager("person");
        //        TableManagerObj.InsertEntity<Student>(StudentObj, false);
        //    }
        //    return RedirectToAction("Get");
        //}
    }
}