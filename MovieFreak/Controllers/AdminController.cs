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

        // INDEX
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

        // GENRES
        public IActionResult Genres()
        {
            List<Genre> genres = _context.Genres.ToList();

            GenresViewModel vm = new GenresViewModel()
            {
                Genres = genres
            };

            return View(vm);
        }

        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGenre(AddGenreViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Genre()
                {
                    FilmGenre = vm.FilmGenre
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Genres));
            }
            return View(vm);
        }

        // LANGUAGES
        public IActionResult Languages()
        {
            List<Taal> talen = _context.Talen.ToList();

            LanguagesViewModel vm = new LanguagesViewModel()
            {
                Talen = talen
            };

            return View(vm);
        }

        public IActionResult AddLanguage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLanguage(AddLanguageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Taal()
                {
                    GesprokenTaal = vm.GesprokenTaal
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Languages));
            }
            return View(vm);
        }

        // DATALINK
        public IActionResult Datalink()
        {
            List<Film> films = _context.Films.ToList();
            List<Persoon> personen = _context.Personen.ToList();
            List<Genre> genres = _context.Genres.ToList();
            List<Taal> talen = _context.Talen.ToList();

            DatalinkViewModel vm = new DatalinkViewModel()
            {
                Films = films,
                Personen = personen,
                Genres = genres,
                Talen = talen
            };

            return View(vm);
        }
    }
}