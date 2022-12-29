using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.AdminViewModels;
using MovieFreak.ViewModels.PersonViewModels;
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

        // LINK PERSON TO MOVIE
        public IActionResult AddCharacter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCharacter(AddCharacterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Personage()
                {
                    VoornaamPersonage = vm.VoornaamPersonage,
                    AchternaamPersonage = vm.AchternaamPersonage,
                    FilmId = vm.FilmId,
                    PersoonId = vm.PersoonId
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddCharacter));
            }
            return View(vm);
        }

        // LINK LANGUAGE TO MOVIE
        public IActionResult AddFilmLanguage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFilmLanguage(AddFilmLanguageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new FilmTaal()
                {
                    FilmId = vm.FilmId,
                    TaalId = vm.TaalId
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddFilmLanguage));
            }

            return View(vm);
        }
    }
}