using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarLight_Ticket;
using StarLight_Ticket.Models;

namespace StarLight_Ticket.Controllers
{
    public class Cinema_SaveController : Controller
    {
        private StarLightTicketsEntities db = new StarLightTicketsEntities();

        // GET: Cinema_Save
        public ActionResult Index()
        {
            var cinema_Save = db.Cinema_Save.Include(c => c.Cinema);
            return View(cinema_Save.ToList());
        }

        //GET: Cinema_Save/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema_Save cinema_Save = db.Cinema_Save.Find(id);
            if (cinema_Save == null)
            {
                return HttpNotFound();
            }
            return View(cinema_Save);
        }
        [Authorize]
        // GET: Cinema_Save/Create
        public ActionResult Create(int cid,string cname, string Mname, string Local, DateTime Sdate, int Price)
        {
            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "CinemaName");

            Cinema_Save cinema_Save = new Cinema_Save();

            //cinema_Save.CID_save = cinema_Save.CID_save + 1;
            //ViewData["Message"] = cinema_Save.CID_save;
            cinema_Save.CinemaID = cid;
            cinema_Save.UserName = User.Identity.Name;
            cinema_Save.CinemaName = cname;
            cinema_Save.MovieName = Mname;
            cinema_Save.Location = Local;
            cinema_Save.ShowDate = Sdate;
            cinema_Save.Price = Price;
            return View(cinema_Save);
        }

        //// POST: Cinema_Save/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CID_save,CinemaID,UserName,CinemaName,MovieName,Location,ShowDate,Quantity,Price,Toatal")] Cinema_Save cinema_Save)
        {
            if (ModelState.IsValid)
            {
                //int i = cinemalist.Count();
                //cs.CID_save = i + 1;
                //cinemalist.Add(cs);

                //int i = cinema_Save.CID_save.ToString().Count();
                //cinema_Save.CID_save = i+1 ;


                db.Cinema_Save.Add(cinema_Save);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "CinemaName", cinema_Save.CinemaID);
            return View(cinema_Save);
        }

        // GET: Cinema_Save/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema_Save cinema_Save = db.Cinema_Save.Find(id);
            if (cinema_Save == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "CinemaName", cinema_Save.CinemaID);
            return View(cinema_Save);
        }

        // POST: Cinema_Save/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CID_save,CinemaID,UserName,CinemaName,MovieName,Location,ShowDate,Quantity,Price,Toatal")] Cinema_Save cinema_Save)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinema_Save).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "CinemaName", cinema_Save.CinemaID);
            return View(cinema_Save);
        }

        // GET: Cinema_Save/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema_Save cinema_Save = db.Cinema_Save.Find(id);
            if (cinema_Save == null)
            {
                return HttpNotFound();
            }
            return View(cinema_Save);
        }

        // POST: Cinema_Save/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinema_Save cinema_Save = db.Cinema_Save.Find(id);
            db.Cinema_Save.Remove(cinema_Save);
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
