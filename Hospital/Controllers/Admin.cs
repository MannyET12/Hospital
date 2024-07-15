using Hospital.Data;
using Hospital.Models;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class Admin : Controller
    {
        private ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        public Admin(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }
        // GET: Admin

        public ActionResult Index()
        {
            var transferData = new AdminViewModel();
            transferData.users = new List<UserData>();

            var users = _context.Users.ToList();

            foreach (ApplicationUser user in users)
            {
                var userData = new UserData();

                var ID = user.Id;
                var roleIDs = _context.Roles.Where(u => u.Id == ID);

                List<string> roleIDStrings = new List<string>();
                foreach (var roleID in roleIDs)
                {
                    roleIDStrings.Add(roleID.Id.ToString());
                }

                List<string> roleNames = new List<string>();
                foreach(var roleID in roleIDStrings)
                {
                    var role = _context.Roles.FirstOrDefault(r => r.Id == roleID);
                    var roleName = role.Name;
                    roleNames.Add(roleName);
                }

                userData.Id = ID;
                userData.FirstName = user.FirstName;
                userData.LastName = user.LastName;
                user.UserName = user.FirstName + user.LastName;
                userData.UserRoles = roleNames;

                transferData.users.Add(userData);
            }
            return View(transferData);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
