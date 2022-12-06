using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieFreak.Controllers
{
    public class FilmController : Controller
    {
        private readonly ILogger<FilmController> _logger;

        public FilmController(ILogger<FilmController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FilmDetails()
        {
            return View();
        }
    }
}