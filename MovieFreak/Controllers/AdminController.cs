using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.AdminViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    [Authorize(Roles = "admin")]
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

        public IActionResult AddLanguage()
        {
            return View();
        }
    }
}