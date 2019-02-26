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
    public class Theatre_SaveController : Controller
    {
        private StarLightTicketsEntities db = new StarLightTicketsEntities();

        // GET: Theatre_Save
        public ActionResult Index()
        {
            var theatre_Save = db.Theatre_Save.Include(t => t.Theatre);
            return View(theatre_Save.ToList());
        }

        // GET: Theatre_Save/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre_Save theatre_Save = db.Theatre_Save.Find(id);
            if (theatre_Save == null)
            {
                return HttpNotFound();
            }
            return View(theatre_Save);
        }
        [Authorize]
        // GET: Theatre_Save/Create
        public ActionResult Create(int cid, string cname, string Mname, string Local, DateTime Sdate, int Price)
        {
            ViewBag.TheatreID = new SelectList(db.Theatres, "Id", "TheatreName");

            Theatre_Save theatre_Save = new Theatre_Save();

            //cinema_Save.CID_save = cinema_Save.CID_save + 1;
            //ViewData["Message"] = cinema_Save.CID_save;
            theatre_Save.TheatreID = cid;
            theatre_Save.UserName = User.Identity.Name;
            theatre_Save.TheatreName = cname;
            theatre_Save.Play = Mname;
            theatre_Save.Location = Local;
            theatre_Save.ShowDate = Sdate;
            theatre_Save.Price = Price;
            return View(theatre_Save);
        }

        // POST: Theatre_Save/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TID_save,TheatreID,UserName,TheatreName,Play,Location,ShowDate,Quantity,Price,Toatal")] Theatre_Save theatre_Save)
        {
            if (ModelState.IsValid)
            {
                db.Theatre_Save.Add(theatre_Save);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TheatreID = new SelectList(db.Theatres, "Id", "TheatreName", theatre_Save.TheatreID);
            return View(theatre_Save);
        }

        // GET: Theatre_Save/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre_Save theatre_Save = db.Theatre_Save.Find(id);
            if (theatre_Save == null)
            {
                return HttpNotFound();
            }
            ViewBag.TheatreID = new SelectList(db.Theatres, "Id", "TheatreName", theatre_Save.TheatreID);
            return View(theatre_Save);
        }

        // POST: Theatre_Save/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TID_save,TheatreID,UserName,TheatreName,Play,Location,ShowDate,Quantity,Price,Toatal")] Theatre_Save theatre_Save)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theatre_Save).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TheatreID = new SelectList(db.Theatres, "Id", "TheatreName", theatre_Save.TheatreID);
            return View(theatre_Save);
        }

        // GET: Theatre_Save/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theatre_Save theatre_Save = db.Theatre_Save.Find(id);
            if (theatre_Save == null)
            {
                return HttpNotFound();
            }
            return View(theatre_Save);
        }

        // POST: Theatre_Save/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theatre_Save theatre_Save = db.Theatre_Save.Find(id);
            db.Theatre_Save.Remove(theatre_Save);
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
