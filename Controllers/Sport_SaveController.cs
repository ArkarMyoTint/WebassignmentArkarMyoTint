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
    public class Sport_SaveController : Controller
    {
        private StarLightTicketsEntities db = new StarLightTicketsEntities();

        // GET: Sport_Save
        public ActionResult Index()
        {
            var sport_Save = db.Sport_Save.Include(s => s.Sport);
            return View(sport_Save.ToList());
        }

        // GET: Sport_Save/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport_Save sport_Save = db.Sport_Save.Find(id);
            if (sport_Save == null)
            {
                return HttpNotFound();
            }
            return View(sport_Save);
        }

        // GET: Sport_Save/Create
        public ActionResult Create(int cid, string cname, string Mname, string Local, DateTime Sdate, int Price)
        {
            ViewBag.SportID = new SelectList(db.Sports, "Id", "SportTheatre");
            Sport_Save sport_Save = new Sport_Save();

            //cinema_Save.CID_save = cinema_Save.CID_save + 1;
            //ViewData["Message"] = cinema_Save.CID_save;
            sport_Save.SportID = cid;
            sport_Save.UserName = User.Identity.Name;
            sport_Save.SportTheatre = cname;
            sport_Save.Sportname = Mname;
            sport_Save.Location = Local;
            sport_Save.ShowDate = Sdate;
            sport_Save.Price = Price;
            return View(sport_Save);
        }

        // POST: Sport_Save/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SID_save,SportID,UserName,SportTheatre,Sportname,Location,ShowDate,Quantity,Price,Toatal")] Sport_Save sport_Save)
        {
            if (ModelState.IsValid)
            {
                db.Sport_Save.Add(sport_Save);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SportID = new SelectList(db.Sports, "Id", "SportTheatre", sport_Save.SportID);
            return View(sport_Save);
        }

        // GET: Sport_Save/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport_Save sport_Save = db.Sport_Save.Find(id);
            if (sport_Save == null)
            {
                return HttpNotFound();
            }
            ViewBag.SportID = new SelectList(db.Sports, "Id", "SportTheatre", sport_Save.SportID);
            return View(sport_Save);
        }

        // POST: Sport_Save/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SID_save,SportID,UserName,SportTheatre,Sportname,Location,ShowDate,Quantity,Price,Toatal")] Sport_Save sport_Save)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sport_Save).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SportID = new SelectList(db.Sports, "Id", "SportTheatre", sport_Save.SportID);
            return View(sport_Save);
        }

        // GET: Sport_Save/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport_Save sport_Save = db.Sport_Save.Find(id);
            if (sport_Save == null)
            {
                return HttpNotFound();
            }
            return View(sport_Save);
        }

        // POST: Sport_Save/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sport_Save sport_Save = db.Sport_Save.Find(id);
            db.Sport_Save.Remove(sport_Save);
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
