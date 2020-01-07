using System;
using FirstApp.Core;

namespace TestConsole
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetKeyVault GetKey = new GetKeyVault();
            await GetKey.OnGetAsync();
            Console.WriteLine(GetKey.Message);
            Console.ReadLine();
        }
    }
}
