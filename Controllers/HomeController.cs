using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProCoding.Demos.ASPNETCore.Session.Models;

namespace ProCoding.Demos.ASPNETCore.Session.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> SetSession(string sessionValue)
        {
            await HttpContext.Session.LoadAsync();
            HttpContext.Session.SetString("MySession", sessionValue);
            return Ok();
        }
        public async Task<IActionResult> ViewSession()
        {
            await HttpContext.Session.LoadAsync();
            return Content(HttpContext.Session.GetString("MySession"));
        }

        public IActionResult Index()
        {
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
