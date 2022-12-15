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

        public IActionResult FilmDetails()
        {
            return View();
        }
    }
}