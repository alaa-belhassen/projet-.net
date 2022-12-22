using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projdotnet.Models;

namespace projdotnet.Controllers
{
    public class productController : Controller
    {
        private Database1Entities17 db = new Database1Entities17();

        // GET: product
        public ActionResult Index()
        {  
            var usr = db.produit.Where(u => u.category == "Top" );
            List<produit> list = new List<produit>();
           
            list = usr.ToList();
         
            return View(list);
        }
        public ActionResult produit()
        {
            var usr = db.produit.Where(u => u.category == "sport");
            List<produit> list = new List<produit>();

            list = usr.ToList();

            return View(list);
        }

        public ActionResult Electronics()
        {
            var usr = db.produit.Where(u => u.category == "electronics");
            List<produit> list = new List<produit>();

            list = usr.ToList();

            return View(list);
        }
        public ActionResult beauty()
        {
            var usr = db.produit.Where(u => u.category == "beautyproduct");
            List<produit> list = new List<produit>();

            list = usr.ToList();

            return View(list);
        }

        public ActionResult garden()
        {
            var usr = db.produit.Where(u => u.category == "homeandgarden");
            List<produit> list = new List<produit>();

            list = usr.ToList();

            return View(list);
        }
        // GET: product/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: product/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ref_produit,nom,category,prix,urlproduit")] produit produit)
        {
            if (ModelState.IsValid)
            {
                db.produit.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index","Tables");
            }

            return View(produit);
        }

        // GET: product/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: product/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ref_produit,nom,category,prix")] produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }

        // GET: product/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            produit produit = db.produit.Find(id);
            db.produit.Remove(produit);
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
