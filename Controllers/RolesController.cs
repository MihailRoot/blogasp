using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using testaundit.Models;
using System.Collections.Generic;
using System.Linq;
namespace testaundit.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _usermanager;
        
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> usermanager)
        {
            _roleManager = roleManager;
            _usermanager = usermanager;
        }
        // GET: RolesController
        public ActionResult Index() => View(_roleManager.Roles.ToList());


        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create() => View();

        // POST: RolesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        // GET: RolesController/Edit/5

        // POST: RolesController/Edit/5
        public async Task <ActionResult> Edit(string UserId)
        {
            ApplicationUser user = await _usermanager.FindByIdAsync(UserId);
            if (user != null)
            {
                //список ролей пользователя
                var userRoles = await _usermanager.GetRolesAsync(user);
                var AllRoles = _roleManager.Roles.ToList();

                Roles model = new Roles
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = AllRoles,
                };
                return View(model);
            }
            return NotFound();
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string UserId, List<string> roles)
        {
            //список пользователей из бд
            ApplicationUser user = await _usermanager.FindByIdAsync(UserId);
            if(user!= null)
            {
                //список пользователей
                var userRoles = await _usermanager.GetRolesAsync(user);
                //список ролей
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var Removed = userRoles.Except(roles);
                await _usermanager.AddToRolesAsync(user, addedRoles);
                await _usermanager.RemoveFromRolesAsync(user, Removed);
                return RedirectToAction("UserList");
            }
            return NotFound();
        }

        // GET: RolesController/Delete/5
        public IActionResult UserList() => View(_usermanager.Users.ToList());

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id) 
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}
