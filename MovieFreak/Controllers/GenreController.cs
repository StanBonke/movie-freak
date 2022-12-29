using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.FilmViewModels;
using MovieFreak.ViewModels.GenreViewModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    [Authorize(Roles = "admin")]
    public class GenreController : Controller
    {
        private readonly MfContext _context;

        public GenreController(MfContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            List<Genre> genres = _context.Genres.ToList();

            GenresViewModel vm = new GenresViewModel()
            {
                Genres = genres
            };

            return View(vm);
        }

        // SEARCH
        public IActionResult Search(GenresViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.Search))
            {
                vm.Genres = _context.Genres
                    .Where(x => x.FilmGenre == vm.Search)
                    .ToList();
            }
            else
            {
                vm.Genres = _context.Genres
                    .ToList();
            }
            return View("Index", vm);
        }

        // ADD
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
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // EDIT
        public async Task<IActionResult> EditGenre(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre g = await _context.Genres.FindAsync(id);
            if (g == null)
            {
                return NotFound();
            }

            EditGenreViewModel vm = new EditGenreViewModel()
            {
                Id = g.Id,
                FilmGenre = g.FilmGenre
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGenre(int id, EditGenreViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Genre g = new Genre()
                    {
                        Id = vm.Id,
                        FilmGenre = vm.FilmGenre
                    };
                    _context.Update(g);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Personen.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // DELETE
        public async Task<IActionResult> DeleteGenre(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre g = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (g == null)
            {
                return NotFound();
            }

            DeleteGenreViewModel vm = new DeleteGenreViewModel()
            {
                Id = g.Id,
                FilmGenre = g.FilmGenre
            };
            return View(vm);
        }

        [HttpPost, ActionName("DeleteGenre")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Genre g = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(g);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}