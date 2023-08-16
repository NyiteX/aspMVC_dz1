using aspMVC_dz1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace aspMVC_dz1.Controllers
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

        [HttpPost]
        public IActionResult Index(string name,string date, string adres, IFormFile image)
        {
            ViewData["name"] = name;
            ViewData["date"] = date;
            ViewData["adres"] = adres;

            if(image != null)
            {
                string base64Image = ConvertToBase64(image);
                ViewData["image"] = base64Image;
            }
            else Console.WriteLine("image = null");



            return View("final");
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


        private string ConvertToBase64(IFormFile image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}