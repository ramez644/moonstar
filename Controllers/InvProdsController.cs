using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoonStar.Models;

namespace MoonStar.Controllers
{
    public class InvProdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvProds
        public ActionResult Index()
        {
            var invProds = db.InvProds.Include(i => i.invoice).Include(i => i.product);
            return View(invProds.ToList());
        }

        // GET: InvProds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvProd invProd = db.InvProds.Find(id);
            if (invProd == null)
            {
                return HttpNotFound();
            }
            return View(invProd);
        }

        // GET: InvProds/Create
        public ActionResult Create()
        {
            ViewBag.InvId = new SelectList(db.Invs, "Id", "inname");
            ViewBag.ProductId = new SelectList(db.Prods, "Id", "ProductName");
            return View();
        }

        // POST: InvProds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustName,ProductId,InvId")] InvProd invProd)
        {
            if (ModelState.IsValid)
            {
                db.InvProds.Add(invProd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvId = new SelectList(db.Invs, "Id", "inname", invProd.InvId);
            ViewBag.ProductId = new SelectList(db.Prods, "Id", "ProductName", invProd.ProductId);
            return View(invProd);
        }




//        public ActionResult Add()
//        {
//            //ViewBag.InvId = new SelectList(db.Invs, "Id", "inname");
//            //ViewBag.ProductId = new SelectList(db.Prods, "Id", "ProductName");
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Add([Bind(Include = "Id,CustName,ProductId,InvId")] InvProd invProd)
//        {
//            int x = 1;

//            for (int i= 0;i<x; i++)
//                {
//if (ModelState.IsValid)
//            {
//                    x +=1;
                
       
//                    db.InvProds.Add(invProd);
//                    db.SaveChanges();
//                    return RedirectToAction("Index");
//                }
//                x = 1;
//                ViewBag.InvId = new SelectList(db.Invs, "Id", "inname", invProd.InvId);
//                ViewBag.ProductId = new SelectList(db.Prods, "Id", "ProductName", invProd.ProductId);
//                return View(invProd);
//            }
//        }

        // GET: InvProds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvProd invProd = db.InvProds.Find(id);
            if (invProd == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvId = new SelectList(db.Invs, "Id", "inname", invProd.InvId);
            ViewBag.ProductId = new SelectList(db.Prods, "Id", "ProductName", invProd.ProductId);
            return View(invProd);
        }

        // POST: InvProds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustName,ProductId,InvId")] InvProd invProd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invProd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvId = new SelectList(db.Invs, "Id", "inname", invProd.InvId);
            ViewBag.ProductId = new SelectList(db.Prods, "Id", "ProductName", invProd.ProductId);
            return View(invProd);
        }

        // GET: InvProds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvProd invProd = db.InvProds.Find(id);
            if (invProd == null)
            {
                return HttpNotFound();
            }
            return View(invProd);
        }

        // POST: InvProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvProd invProd = db.InvProds.Find(id);
            db.InvProds.Remove(invProd);
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
