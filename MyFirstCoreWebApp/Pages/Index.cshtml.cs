using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;

namespace MyFirstCoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Message = "Hello World";
        private readonly ILogger _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Message = "IP Addr ----- " + ip + Environment.NewLine;
            _logger.LogInformation("Message displayed: {Message}", Message);
            WriteLog(Message);
        }


        public static void WriteLog(string ex)
        {
            StringBuilder sb = new StringBuilder();
            string path = @"D:\Deployment\";
            sb.Append(ex);
            System.IO.File.AppendAllText(path + "log.txt", sb.ToString());
            sb.Clear();

        }
    }
}
