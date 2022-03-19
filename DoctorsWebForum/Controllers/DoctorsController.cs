using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorsWebForum.Models;
using DoctorsWebForum.Models.Forum;

namespace DoctorsWebForum.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public async Task<ActionResult> Index()
        {
            var doctors = db.Doctors.Include(d => d.ApplicationUser).Include(d => d.Expertise);
            return View(await doctors.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //// GET: Doctors/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email");
        //    ViewBag.ExpertiseId = new SelectList(db.Expertises, "Id", "Name");
        //    return View();
        //}

        //// POST: Doctors/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,DOB,Gender,Workplace,Qualification,Achievement,DateCreate,Confirm,ExpertiseId")] Doctor doctor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Doctors.Add(doctor);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", doctor.Id);
        //    ViewBag.ExpertiseId = new SelectList(db.Expertises, "Id", "Name", doctor.ExpertiseId);
        //    return View(doctor);
        //}

        //// GET: Doctors/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Doctor doctor = await db.Doctors.FindAsync(id);
        //    if (doctor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", doctor.Id);
        //    ViewBag.ExpertiseId = new SelectList(db.Expertises, "Id", "Name", doctor.ExpertiseId);
        //    return View(doctor);
        //}

        //// POST: Doctors/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DOB,Gender,Workplace,Qualification,Achievement,DateCreate,Confirm,ExpertiseId")] Doctor doctor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(doctor).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", doctor.Id);
        //    ViewBag.ExpertiseId = new SelectList(db.Expertises, "Id", "Name", doctor.ExpertiseId);
        //    return View(doctor);
        //}

        // GET: Doctors/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Doctor doctor = await db.Doctors.FindAsync(id);
            db.Doctors.Remove(doctor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
