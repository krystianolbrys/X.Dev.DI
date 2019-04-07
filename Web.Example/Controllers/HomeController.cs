using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Example.CQRS.Requests;
using Web.Example.Interfaces;
using Web.Example.Models;

namespace Web.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var result = _service.CalculateSum(1, 2);
            TempData["data"] = result;

            return View();
        }

        public IActionResult Privacy()
        {
            var result = _service.ExceptionMethod();
            TempData["data"] = result;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
