using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class duckController : Controller
    {
        private testContext db = new testContext();

        //
        // GET: /duck/

        public ActionResult Index()
        {
            return View(db.patitoes.ToList());
        }

        //
        // GET: /duck/Details/5

        public ActionResult Details(int id = 0)
        {
            patito patito = db.patitoes.Find(id);
            if (patito == null)
            {
                return HttpNotFound();
            }
            return View(patito);
        }

        //
        // GET: /duck/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /duck/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(patito patito)
        {
            if (ModelState.IsValid)
            {
                db.patitoes.Add(patito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patito);
        }

        //
        // GET: /duck/Edit/5

        public ActionResult Edit(int id = 0)
        {
            patito patito = db.patitoes.Find(id);
            if (patito == null)
            {
                return HttpNotFound();
            }
            return View(patito);
        }

        //
        // POST: /duck/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(patito patito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patito);
        }

        //
        // GET: /duck/Delete/5

        public ActionResult Delete(int id = 0)
        {
            patito patito = db.patitoes.Find(id);
            if (patito == null)
            {
                return HttpNotFound();
            }
            return View(patito);
        }

        //
        // POST: /duck/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patito patito = db.patitoes.Find(id);
            db.patitoes.Remove(patito);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}