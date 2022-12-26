using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.FilmViewModels;
using MovieFreak.ViewModels.PersonViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    public class FilmController : Controller
    {
        private readonly MfContext _context;

        public FilmController(MfContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Film> films = _context.Films
                .Include(g => g.Genre)
                .ToList();

            List<Personage> personages = _context.Personages
                .Include(p => p.Persoon)
                .ToList();

            Genre genre = _context.Genres
                .FirstOrDefault();

            FilmViewModel vm = new FilmViewModel()
            {
                Films = films,
                Personages = personages,
                Genre = genre
            };

            return View(vm);
        }

        [AllowAnonymous]
        public IActionResult FilmDetails(int id)
        {
            Film film = _context.Films.Where(f => f.Id == id).FirstOrDefault();
            Genre genre = _context.Genres.Where(g => g.Id == film.GenreId).FirstOrDefault();

            List<Personage> personages = _context.Personages
                .Include(p => p.Persoon)
                .ToList();

            List<FilmTaal> filmTalen = _context.FilmTalen
                .Include(t => t.Taal)
                .ToList();

            if (film != null)
            {
                FilmDetailsViewModel vm = new FilmDetailsViewModel()
                {
                    Id = id,
                    Titel = film.Titel,
                    Omschrijving = film.Omschrijving,
                    Duurtijd = film.Duurtijd,
                    Trailerlink = film.Trailerlink,
                    Genre = genre,

                    Personages = personages,
                    FilmTalen = filmTalen
                };
                return View(vm);
            }
            else
            {
                return Index();
            }
        }

        [Authorize(Roles = "admin")]
        public IActionResult Films()
        {
            List<FilmTaal> filmTalen = _context.FilmTalen
                .Include(t => t.Taal)
                .Include(f => f.Film)
                .Include(g => g.Film.Genre)
                .ToList();

            Genre genre = _context.Genres
                .FirstOrDefault();

            FilmsViewModel vm = new FilmsViewModel()
            {
                Genre = genre,
                FilmTalen = filmTalen
            };
            return View(vm);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddFilm()
        {
            List<Genre> genres = _context.Genres.ToList();

            AddFilmViewModel vm = new AddFilmViewModel()
            {
                Genres = genres
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFilm(AddFilmViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Film()
                {
                    GenreId = vm.GenreId,
                    Titel = vm.Titel,
                    Omschrijving = vm.Omschrijving,
                    Duurtijd = vm.Duurtijd,
                    Trailerlink = vm.Trailerlink
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Films));
            }

            return View(vm);
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditFilm()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteFilm()
        {
            return View();
        }
    }
}