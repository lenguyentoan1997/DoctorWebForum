using DoctorsWebForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoctorsWebForum.Areas.Admin.Controllers
{
    public class ApplicationRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: Admin/ApplicationRole
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ApplicationRole/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ApplicationRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Role/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleName = new IdentityRole { Name = model.Name.ToLower() };
                IdentityResult result = await _roleManager.CreateAsync(roleName);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);

            }

            return View(model);
        }

        // GET: Admin/ApplicationRole/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ApplicationRole/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ApplicationRole/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ApplicationRole/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
