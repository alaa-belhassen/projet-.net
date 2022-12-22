using projdotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace projdotnet.Controllers
{
    public class PanierController : Controller
    {
        private Database1Entities17 db = new Database1Entities17();
        // GET: Panier
        public ActionResult ajouterPanier()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ajouterPanier([Bind(Include = "idpanier,idclient,qte_prod,ref_produit,urlproduit,prix")] panier panier)
        {
            if (ModelState.IsValid)
            {
                db.panier.Add(panier);
                db.SaveChanges();
                return RedirectToAction("Index","product");
            }

            return View(panier);
            
        }
        public ActionResult getpanier(int? id)
        {
            List<panier> panier2 = new List<panier>();
            foreach (panier i in db.panier.ToList())
            {
                if (i.idclient == id)
                {
                    panier2.Add(i);
                }
            }
           
            
            return View(panier2);
        }
        
        public ActionResult deletepanier(int? id)
        {
            panier panier = db.panier.Find(id);
            db.panier.Remove(panier);
            db.SaveChanges();
            return RedirectToAction("getPanier/" + Session["userId"]);
        }

        public double acheter(int? id)
        {
            List<panier> panier2 = new List<panier>();
            foreach (panier i in db.panier.ToList())
            {
                if (i.idclient == id)
                {
                    panier2.Add(i);
                }
            }
            double somme = 0;
            foreach(panier i in panier2)
            {
                somme = (double)(i.prix * i.qte_prod + somme);
            }

            return somme;
         
        }

    }
}