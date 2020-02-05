using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using parknarkbeta2.Models;

namespace parknarkbeta2.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Connect()
        {

            ViewData["Title"] = "API Connectivity";

            try
            {
                var uri = "https://parknarkbetaapi/api/values";
                ViewData["ApiHit1Uri"] = uri;

                string responseBody = await client.GetStringAsync(uri);


                ViewData["ApiHit1Result"] = responseBody;
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
                ViewData["ApiHit1Result"] = e.Message;
            }

            try
            {
                var uri = "https://localhost:32770/api/values";
                ViewData["ApiHit2Uri"] = uri;

                string responseBody = await client.GetStringAsync(uri);


                ViewData["ApiHit2Result"] = responseBody;
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Caught!");
                Debug.WriteLine("Message :{0} ", e.Message);
                ViewData["ApiHit2Result"] = e.Message;
            }






            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
