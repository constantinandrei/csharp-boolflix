using csharp_boolflix.Areas.Contents.Data;
using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public BoolflixDBRepository data;

        public HomeController(ILogger<HomeController> logger, BoolflixDBRepository _data)
        {
            _logger = logger;
            data = _data;
        }

        public IActionResult Index()
        {
            data.TestInsert();
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