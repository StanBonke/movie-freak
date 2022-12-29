using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.HomeViewModels;
using MovieFreak.ViewModels.PersonViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    public class HomeController : Controller
    {
        private readonly MfContext _context;

        public HomeController(MfContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            Film film = _context.Films.FirstOrDefault();
            Genre genre = _context.Genres.Where(g => g.Id == film.GenreId).FirstOrDefault();

            List<Film> films = _context.Films
                .Include(g => g.Genre)
                .ToList();

            List<FilmTaal> filmTalen = _context.FilmTalen
                .Include(t => t.Taal)
                .ToList();

            if (film != null)
            {
                HomeViewModel vm = new HomeViewModel()
                {
                    Titel = film.Titel,
                    Omschrijving = film.Omschrijving,
                    Duurtijd = film.Duurtijd,
                    Trailerlink = film.Trailerlink,
                    Genre = genre,
                    Films = films,
                    FilmTalen = filmTalen
                };
                return View(vm);
            }
            else
            {
                return Index();
            }
        }

        // PRIVACY
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