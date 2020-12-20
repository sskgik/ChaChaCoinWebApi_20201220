using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChaChaCoin.Models;

namespace ChaChaCoin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
         //Developer Page
        public IActionResult  Developer()
        {
            return View();
        }
        //Product page
        public IActionResult Product()
        {
            return View();
        }
        //BrockChain Explorer Page(ChaChaCoin)
        public IActionResult  DemoSAKURAApp()
        {
            return View();
        }
        //ChaChaMobileDemoPage
        public IActionResult DemoChaChaApp()
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
