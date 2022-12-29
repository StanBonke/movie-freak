using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieFreak.Areas.Identity.Data;
using MovieFreak.Data;
using MovieFreak.ViewModels.FilmViewModels;
using MovieFreak.ViewModels.UserViewModels;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFreak.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private readonly MfContext _context;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, MfContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            UsersViewModel viewModel = new UsersViewModel()
            {
                Users = _userManager.Users.ToList()
            };
            return View(viewModel);
        }

        // SEARCH
        [AllowAnonymous]
        public IActionResult Search(UsersViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.Search))
            {
                vm.Users = _context.Users
                    .Where(x => x.UserName
                    .Contains(vm.Search))
                    .ToList();
            }
            else
            {
                vm.Users = _context.Users.ToList();
            }
            return View("Index", vm);
        }

        // ADD
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser gebruiker = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                IdentityResult result = await _userManager.CreateAsync(gebruiker, viewModel.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        // DELETE

        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("Index", _userManager.Users.ToList());
        }

        // MANAGE USER ROLE
        public IActionResult UserRole()
        {
            UserRoleViewModel viewModel = new UserRoleViewModel()
            {
                Users = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Rollen = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRole(UserRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(viewModel.UserId);
                IdentityRole role = await _roleManager.FindByIdAsync(viewModel.RolId);
                if (user != null && role != null)
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                }
                else
                    ModelState.AddModelError("", "User or role Not Found");
            }
            return View(viewModel);
        }
    }
}