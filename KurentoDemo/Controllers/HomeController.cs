using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurento.NET;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KurentoDemo.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HelloWorld()
        {
            return View();
        }
        public IActionResult Room()
        {
            return View();
        }
    }
}