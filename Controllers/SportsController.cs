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
    public class SportsController : Controller
    {
        private StarLightTicketsEntities db = new StarLightTicketsEntities();

        // GET: Sports
        public ActionResult Index()
        {
            var sports = db.Sports.Include(s => s.Sport_fix);
            return View(sports.ToList());
        }

        public ActionResult Select(string id, string name, string mname, string loca, DateTime sdate, int price)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Create", "Sport_Save", new { cid = id, cname = name, Mname = mname, Local = loca, Sdate = sdate, Price = price });
        }

        // GET: Sports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport sport = db.Sports.Find(id);
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        // GET: Sports/Create
        public ActionResult Create()
        {
            ViewBag.Sid = new SelectList(db.Sport_fix, "SID", "SID");
            return View();
        }

        // POST: Sports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sid,SportTheatre,ShowDate,Quantity,Play,Price")] Sport sport)
        {
            if (ModelState.IsValid)
            {
                db.Sports.Add(sport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sid = new SelectList(db.Sport_fix, "SID", "SID", sport.Sid);
            return View(sport);
        }

        // GET: Sports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport sport = db.Sports.Find(id);
            if (sport == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sid = new SelectList(db.Sport_fix, "SID", "SID", sport.Sid);
            return View(sport);
        }

        // POST: Sports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sid,SportTheatre,ShowDate,Quantity,Play,Price")] Sport sport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sid = new SelectList(db.Sport_fix, "SID", "SID", sport.Sid);
            return View(sport);
        }

        // GET: Sports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport sport = db.Sports.Find(id);
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        // POST: Sports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sport sport = db.Sports.Find(id);
            db.Sports.Remove(sport);
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
