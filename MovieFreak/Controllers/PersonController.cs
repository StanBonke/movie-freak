using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.PersonViewModels;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    [Authorize(Roles = "admin")]
    public class PersonController : Controller
    {
        private readonly MfContext _context;

        public PersonController(MfContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            List<Persoon> personen = _context.Personen.ToList();

            PersonsViewModel vm = new PersonsViewModel()
            {
                Personen = personen
            };
            return View(vm);
        }

        // SEARCH
        public IActionResult Search(PersonsViewModel vm)
        {
            var query = _context.Personen.AsQueryable();

            if (!string.IsNullOrWhiteSpace(vm.PersonSearch))
            {
                string[] search = vm.PersonSearch.Split(' ', ',');
                foreach (var item in search)
                {
                    query = query.Where(x =>
                    x.Voornaam.Contains(item)
                    || x.Achternaam.Contains(item));
                }

                vm.Personen = query.ToList();
            }
            else
            {
                vm.Personen = query.ToList();
            }

            return View("Index", vm);
        }

        // ADD
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson(AddPersonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Persoon()
                {
                    Voornaam = vm.Voornaam,
                    Achternaam = vm.Achternaam,
                    Geboortedatum = vm.Geboortedatum,
                    Geboorteplaats = vm.Geboorteplaats,
                    Geboorteland = vm.Geboorteland,
                    Biografie = vm.Biografie,
                    Rol = vm.Rol
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddPerson));
            }
            return View(vm);
        }

        // EDIT
        public async Task<IActionResult> EditPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persoon p = await _context.Personen.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            EditPersonViewModel vm = new EditPersonViewModel()
            {
                Id = p.Id,
                Voornaam = p.Voornaam,
                Achternaam = p.Achternaam,
                Geboortedatum = p.Geboortedatum,
                Geboorteplaats = p.Geboorteplaats,
                Geboorteland = p.Geboorteland,
                Biografie = p.Biografie,
                Rol = p.Rol
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerson(int id, EditPersonViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Persoon p = new Persoon()
                    {
                        Id = vm.Id,
                        Voornaam = vm.Voornaam,
                        Achternaam = vm.Achternaam,
                        Geboortedatum = vm.Geboortedatum,
                        Geboorteplaats = vm.Geboorteplaats,
                        Geboorteland = vm.Geboorteland,
                        Biografie = vm.Biografie,
                        Rol = vm.Rol
                    };
                    _context.Update(p);
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
        public async Task<IActionResult> DeletePerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persoon p = await _context.Personen.FirstOrDefaultAsync(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }

            DeletePersonViewModel vm = new DeletePersonViewModel()
            {
                Id = p.Id,
                Voornaam = p.Voornaam,
                Achternaam = p.Achternaam,
                Geboortedatum = p.Geboortedatum,
                Geboorteplaats = p.Geboorteplaats,
                Geboorteland = p.Geboorteland,
                Biografie = p.Biografie,
                Rol = p.Rol
            };
            return View(vm);
        }

        [HttpPost, ActionName("DeletePerson")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Persoon p = await _context.Personen.FindAsync(id);
            _context.Personen.Remove(p);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}