using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;

namespace EndToEnd.Controllers
{
    public class CMSAdminsController : Controller
    {
        private CMS_DatabaseEntities db = new CMS_DatabaseEntities();

        // GET: CMSAdmins
        public ActionResult Index()
        {
            return View(db.CMSAdmins.ToList());
        }

        // GET: CMSAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMSAdmin cMSAdmin = db.CMSAdmins.Find(id);
            if (cMSAdmin == null)
            {
                return HttpNotFound();
            }
            return View(cMSAdmin);
        }

        // GET: CMSAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMSAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,BOD,ContactNo,Email")] CMSAdmin cMSAdmin)
        {
            if (ModelState.IsValid)
            {
                db.CMSAdmins.Add(cMSAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMSAdmin);
        }

        // GET: CMSAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMSAdmin cMSAdmin = db.CMSAdmins.Find(id);
            if (cMSAdmin == null)
            {
                return HttpNotFound();
            }
            return View(cMSAdmin);
        }

        // POST: CMSAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,BOD,ContactNo,Email")] CMSAdmin cMSAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMSAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMSAdmin);
        }

        // GET: CMSAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMSAdmin cMSAdmin = db.CMSAdmins.Find(id);
            if (cMSAdmin == null)
            {
                return HttpNotFound();
            }
            return View(cMSAdmin);
        }

        // POST: CMSAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMSAdmin cMSAdmin = db.CMSAdmins.Find(id);
            db.CMSAdmins.Remove(cMSAdmin);
            db.SaveChanges();
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
