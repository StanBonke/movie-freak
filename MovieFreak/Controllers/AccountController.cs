using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.AccountViewModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MovieFreak.Controllers
{
    [Authorize(Roles = "user")]
    public class AccountController : Controller
    {
        private readonly MfContext _context;

        public AccountController(MfContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            List<Film> films = _context.Films
                .Include(g => g.Genre)
                .ToList();

            Genre genre = _context.Genres
                .FirstOrDefault();

            FavoritesViewModel vm = new FavoritesViewModel()
            {
                Films = films,
                Genre = genre
            };

            return View(vm);
        }

        // SEARCH
        public IActionResult Search(FavoritesViewModel vm)
        {
            // MULTIPLE PROPERTY SEARCH

            var query = _context.Films.AsQueryable();

            if (!string.IsNullOrWhiteSpace(vm.Search))
            {
                string[] search = vm.Search.Split(' ', ',');
                foreach (var item in search)
                {
                    query = query.Where(x =>
                        x.Titel.Contains(item) ||
                        x.Genre.FilmGenre.Contains(item))
                        .Include(g => g.Genre);
                }

                vm.Films = query.ToList();
            }
            else
            {
                vm.Films = query.Include(g => g.Genre).ToList();
            }

            return View("Index", vm);
        }
    }
}