using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MovieFreak.Controllers
{
    [AllowAnonymous]
    public class FilmController : Controller
    {
        private readonly MfContext _context;

        public FilmController(MfContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Film> films = _context.Films
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
    }
}