using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using projdotnet.Models;

namespace projdotnet.Controllers
{
    public class TablesController : Controller
    {
        private Database1Entities17 db = new Database1Entities17();

        // GET: Tables
      
        public ActionResult Index()
        {
            return View(db.client.ToList());
        }
            
        // GET: Tables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            panier panier = db.panier.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // GET: Tables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tables/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,prenom,tel,email,user,password,role")] client client)
        {

            
            if (ModelState.IsValid)
            {
                db.client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(client);
        }

        // GET: Tables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Tables/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,prenom,tel,email,role,money,user,password")] client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Tables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client table = db.client.Find(id);
            db.client.Remove(table);
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(client model)
        {
            if (ModelState.IsValid)
            {
                // bool isValid = db.client.Any(u => u.user == model.user && u.password == model.password);
                var usr = db.client.Where(u => u.user == model.user && u.password == model.password).FirstOrDefault();
                if (usr != null)
                {
                    Session["userId"] = usr.Id.ToString();
                    Session["solde"] = usr.money.ToString();
                    if (usr.role == "client")
                    {
                        Session["role"] = "client";
                        return RedirectToAction("Index", "Product");
                    }else if (usr.role == "admin")
                    {
                        Session["role"] = "admin";
                        return RedirectToAction("Index", "Tables");
                    }
                  
                    
                }
            }
            ModelState.AddModelError("", "Invalid Username/Password!");
            return View();
        }
        public void logout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.cshtml");
        }
        public ActionResult loggedIn()

        {
            if (Session["userId"] != null) {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
         
        }   
            
        
    }
}
