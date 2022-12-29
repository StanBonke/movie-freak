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

        // INDEX
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

        // SEARCH
        [AllowAnonymous]
        public IActionResult Search(FilmViewModel vm)
        {
            // MULTIPLE PROPERTY SEARCH

            var query = _context.Films.AsQueryable();
            var query2 = _context.Personages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(vm.FilmSearch))
            {
                string[] search = vm.FilmSearch.Split(' ', ',');
                foreach (var item in search)
                {
                    query = query.Where(x =>
                        x.Titel.Contains(item) ||
                        x.Genre.FilmGenre.Contains(item))
                        .Include(g => g.Genre);
                }

                vm.Films = query.ToList();

                vm.Personages = _context.Personages
                    .Include(p => p.Persoon)
                    .ToList();
            }
            else
            {
                vm.Films = query.Include(g => g.Genre).ToList();

                vm.Personages = _context.Personages
                    .Include(p => p.Persoon)
                    .ToList();
            }

            return View("Index", vm);

            // SINGLE PROPERTY SEARCH

            //if (!string.IsNullOrWhiteSpace(vm.FilmSearch))
            //{
            //    vm.Films = _context.Films
            //        .Where(x => x.Titel
            //        .Contains(vm.FilmSearch))
            //        .Include(g => g.Genre)
            //        .ToList();

            //    vm.Personages = _context.Personages
            //        .Include(p => p.Persoon)
            //        .ToList();
            //}
            //else
            //{
            //    vm.Films = _context.Films
            //        .Include(g => g.Genre)
            //        .ToList();

            //    vm.Personages = _context.Personages
            //        .Include(p => p.Persoon)
            //        .ToList();
            //}
            //return View("Index", vm);
        }

        // FILM DETAILS
        [Authorize]
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

        // FILMS
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

        // ADD
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

        // EDIT
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditFilm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film f = await _context.Films.FindAsync(id);
            if (f == null)
            {
                return NotFound();
            }

            List<Genre> genres = _context.Genres.ToList();

            EditFilmViewModel vm = new EditFilmViewModel()
            {
                Id = f.Id,
                Titel = f.Titel,
                Duurtijd = f.Duurtijd,
                Trailerlink = f.Trailerlink,
                Omschrijving = f.Omschrijving,
                GenreId = f.Genre.Id,

                Genres = genres
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFilm(int id, EditFilmViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Film f = new Film()
                    {
                        Id = vm.Id,
                        Titel = vm.Titel,
                        Duurtijd = vm.Duurtijd,
                        Trailerlink = vm.Trailerlink,
                        Omschrijving = vm.Omschrijving,
                        GenreId = vm.GenreId,
                    };
                    _context.Update(f);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Films.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Films));
            }
            return View(vm);
        }

        // DELETE
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteFilm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film f = await _context.Films.FirstOrDefaultAsync(f => f.Id == id);
            if (f == null)
            {
                return NotFound();
            }

            DeleteFilmViewModel vm = new DeleteFilmViewModel()
            {
                Id = f.Id,
                Titel = f.Titel,
                Duurtijd = f.Duurtijd,
                Trailerlink = f.Trailerlink,
                Omschrijving = f.Omschrijving,
                GenreId = f.GenreId,
            };
            return View(vm);
        }

        [HttpPost, ActionName("DeleteFilm")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Film f = await _context.Films.FindAsync(id);
            _context.Films.Remove(f);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Films));
        }
    }
}