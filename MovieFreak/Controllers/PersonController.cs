using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFreak.Data;
using MovieFreak.Models;
using MovieFreak.ViewModels.PersonViewModels;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index()
        {
            List<Persoon> personen = _context.Personen.ToList();

            PersonsViewModel vm = new PersonsViewModel()
            {
                Personen = personen
            };
            return View(vm);
        }

        // ADD PERSON
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
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // CREATE PERSON
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

        // DELETE PERSON
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