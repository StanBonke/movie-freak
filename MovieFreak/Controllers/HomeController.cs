using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
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

        public IActionResult Index()
        {
            Film film = _context.Films.FirstOrDefault();
            Genre genre = _context.Genres.FirstOrDefault();

            List<Film> films = _context.Films.ToList();

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