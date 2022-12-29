using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.GenreViewModels;
using MovieFreak.ViewModels.LanguageViewModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    [Authorize(Roles = "admin")]
    public class LanguageController : Controller
    {
        private readonly MfContext _context;

        public LanguageController(MfContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            List<Taal> talen = _context.Talen.ToList();

            LanguagesViewModel vm = new LanguagesViewModel()
            {
                Talen = talen
            };

            return View(vm);
        }

        // SEARCH
        public IActionResult Search(LanguagesViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.Search))
            {
                vm.Talen = _context.Talen
                    .Where(x => x.GesprokenTaal == vm.Search)
                    .ToList();
            }
            else
            {
                vm.Talen = _context.Talen
                    .ToList();
            }
            return View("Index", vm);
        }

        // ADD
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
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // EDIT
        public async Task<IActionResult> EditLanguage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Taal t = await _context.Talen.FindAsync(id);
            if (t == null)
            {
                return NotFound();
            }

            EditLanguageViewModel vm = new EditLanguageViewModel()
            {
                Id = t.Id,
                GesprokenTaal = t.GesprokenTaal
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLanguage(int id, EditLanguageViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Taal t = new Taal()
                    {
                        Id = vm.Id,
                        GesprokenTaal = vm.GesprokenTaal
                    };
                    _context.Update(t);
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
        public async Task<IActionResult> DeleteLanguage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Taal t = await _context.Talen.FirstOrDefaultAsync(t => t.Id == id);
            if (t == null)
            {
                return NotFound();
            }

            DeleteLanguageViewModel vm = new DeleteLanguageViewModel()
            {
                Id = t.Id,
                GesprokenTaal = t.GesprokenTaal
            };
            return View(vm);
        }

        [HttpPost, ActionName("DeleteLanguage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Taal t = await _context.Talen.FindAsync(id);
            _context.Talen.Remove(t);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}