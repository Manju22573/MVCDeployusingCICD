using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCDeploy.Models;

namespace MVCDeploy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetData()
        {
            var data = new
            {
                Message = "Hello from Controller",
                Timestamp = DateTime.Now,
                Items = new[] { "Item 1", "Item 2", "Item 3" },
                Count = 3
            };
            
            return Json(data);
        }

        public IActionResult GetWorcesterTemperature()
        {
            var random = new Random();
            var temperature = random.Next(-5, 30);
            
            var weatherData = new
            {
                City = "Worcester",
                State = "Massachusetts",
                Country = "USA",
                Temperature = temperature,
                TemperatureUnit = "°C",
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Condition = temperature > 20 ? "Warm" : temperature > 10 ? "Mild" : "Cool"
            };
            
            return Json(weatherData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
