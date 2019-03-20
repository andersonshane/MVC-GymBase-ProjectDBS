using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_GymBase_ProjectDBS.Models;

namespace MVC_GymBase_ProjectDBS.Controllers
{
    public class FacilitiesController : Controller
    {
        static DataSet ds;
        static DataTable dt;

        public ActionResult Contact()
        {
            if (System.IO.File.Exists(Server.MapPath("~/App_Data/facilities.xml")))
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/facilities.xml"));
                dt = ds.Tables["user_contact"];
            }
            else
            {
                ds = new DataSet("contact");
                dt = new DataTable("user_contact");
                DataColumn name_col = new DataColumn("name");
                DataColumn email_col = new DataColumn("email");
                DataColumn comments_col = new DataColumn("comments");
                dt.Columns.Add(name_col);
                dt.Columns.Add(email_col);
                dt.Columns.Add(comments_col);
                ds.Tables.Add(dt);
            }
            return View(Index());
        }

        [HttpPost]
        public ActionResult Contact(string name, string email, string comments)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                row["name"] = name;
                row["email"] = email;
                row["comments"] = comments;
                dt.Rows.Add(row);
                ds.AcceptChanges();
                ds.WriteXml(Server.MapPath("~/App_Data/facilities.xml"));
                return View("StatusC");
            }

            else return View("Index");
        }
    
private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facilities
        public ActionResult Index()
        {
            return View(db.Facilities.ToList());
        }

        // GET: Facilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facilities facilities = db.Facilities.Find(id);
            if (facilities == null)
            {
                return HttpNotFound();
            }
            return View(facilities);
        }

        // GET: Facilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacilityIDModels,Name")] Facilities facilities)
        {
            if (ModelState.IsValid)
            {
                db.Facilities.Add(facilities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facilities);
        }

        // GET: Facilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facilities facilities = db.Facilities.Find(id);
            if (facilities == null)
            {
                return HttpNotFound();
            }
            return View(facilities);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacilityIDModels,Name")] Facilities facilities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facilities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facilities);
        }

        // GET: Facilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facilities facilities = db.Facilities.Find(id);
            if (facilities == null)
            {
                return HttpNotFound();
            }
            return View(facilities);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facilities facilities = db.Facilities.Find(id);
            db.Facilities.Remove(facilities);
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
