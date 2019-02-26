using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarLight_Ticket;

namespace StarLight_Ticket.Controllers
{
    public class TheatresController : Controller
    {
        private StarLightTicketsEntities db = new StarLightTicketsEntities();

        // GET: Theatres
        public ActionResult Index()
        {
            var theatres = db.Theatres.Include(t => t.Theatre_fix);
            return View(theatres.ToList());
        }

        public ActionResult Select(string id, string name, string mname, string loca, DateTime sdate, int price)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Create", "Theatre_Save", new { cid = id, cname = name, Mname = mname, Local = loca, Sdate = sdate, Price = price });
        }


        // GET: Theatres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre theatre = db.Theatres.Find(id);
            if (theatre == null)
            {
                return HttpNotFound();
            }
            return View(theatre);
        }

        // GET: Theatres/Create
        public ActionResult Create()
        {
            ViewBag.Tid = new SelectList(db.Theatre_fix, "TID", "TID");
            return View();
        }

        // POST: Theatres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tid,TheatreName,ShowDate,Quantity,Play,Price")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                db.Theatres.Add(theatre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tid = new SelectList(db.Theatre_fix, "TID", "TID", theatre.Tid);
            return View(theatre);
        }

        // GET: Theatres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre theatre = db.Theatres.Find(id);
            if (theatre == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tid = new SelectList(db.Theatre_fix, "TID", "TID", theatre.Tid);
            return View(theatre);
        }

        // POST: Theatres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tid,TheatreName,ShowDate,Quantity,Play,Price")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theatre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tid = new SelectList(db.Theatre_fix, "TID", "TID", theatre.Tid);
            return View(theatre);
        }

        // GET: Theatres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre theatre = db.Theatres.Find(id);
            if (theatre == null)
            {
                return HttpNotFound();
            }
            return View(theatre);
        }

        // POST: Theatres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theatre theatre = db.Theatres.Find(id);
            db.Theatres.Remove(theatre);
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
