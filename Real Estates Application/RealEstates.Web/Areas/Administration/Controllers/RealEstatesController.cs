using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstates.Data;
using RealEstates.Model;
using Microsoft.AspNet.Identity;

namespace RealEstates.Web.Areas.Administration.Controllers
{
    public class RealEstatesController : Controller
    {
        private RealEstatesDbContext db = new RealEstatesDbContext();

        // GET: Administration/RealEstates
        public ActionResult Index()
        {
            var realEstates = db.RealEstates.Include(r => r.City).Include(r => r.User);
            return View(realEstates.ToList());
        }

        // GET: Administration/RealEstates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = db.RealEstates.Find(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            return View(realEstate);
        }

        // GET: Administration/RealEstates/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "ImageURL");
            return View();
        }

        // POST: Administration/RealEstates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Address,Contact,ConstructionYear,SellingPrice,RentingPrice,Type,CreatedOn,Bedrooms,SquareMeter,UserId,CityId")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                realEstate.CreatedOn = DateTime.Now;
                realEstate.UserId = this.User.Identity.GetUserId();
                db.RealEstates.Add(realEstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", realEstate.CityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "ImageURL", realEstate.UserId);
            return View(realEstate);
        }

        // GET: Administration/RealEstates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = db.RealEstates.Find(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", realEstate.CityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "ImageURL", realEstate.UserId);
            return View(realEstate);
        }

        // POST: Administration/RealEstates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Address,Contact,ConstructionYear,SellingPrice,RentingPrice,Type,CreatedOn,Bedrooms,SquareMeter,UserId,CityId")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realEstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", realEstate.CityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "ImageURL", realEstate.UserId);
            return View(realEstate);
        }

        // GET: Administration/RealEstates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = db.RealEstates.Find(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            return View(realEstate);
        }

        // POST: Administration/RealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RealEstate realEstate = db.RealEstates.Find(id);
            db.RealEstates.Remove(realEstate);
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
