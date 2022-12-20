using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    public class AdminController : Controller
    {
        private readonly MfContext _context;

        public AdminController(MfContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Film> films = _context.Films
                .ToList();

            AdminViewModel vm = new AdminViewModel()
            {
                Films = films
            };

            return View(vm);
        }
    }
}