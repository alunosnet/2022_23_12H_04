using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M17E_Lar.Data;
using M17E_Lar.Models;

namespace M17E_Lar.Controllers
{
    [Authorize]
    public class FamiliaresController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();

        // GET: Familiares
        public ActionResult Index()
        {
            var dados = db.Familiars.ToList();
            // Ordenar a lista alfabeticamente
            dados = dados.OrderBy(d => d.Nome).ToList();
            return View(dados);

            //return View(db.Familiars.ToList());
        }

        // GET: Familiares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiar familiar = db.Familiars.Find(id);
            if (familiar == null)
            {
                return HttpNotFound();
            }
            return View(familiar);
        }

        // GET: Familiares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Familiares/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamiliarID,Nome,Morada,Email,Telefone")] Familiar familiar)
        {
            if (ModelState.IsValid)
            {
                db.Familiars.Add(familiar);
                db.SaveChanges();
                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Public/") + familiar.FamiliarID + ".jpg";
                    fotografia.SaveAs(nome);
                }
                return RedirectToAction("Index");
            }

            return View(familiar);
        }

        // GET: Familiares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiar familiar = db.Familiars.Find(id);
            if (familiar == null)
            {
                return HttpNotFound();
            }
            return View(familiar);
        }

        // POST: Familiares/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamiliarID,Nome,Morada,Email,Telefone")] Familiar familiar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familiar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familiar);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Familiares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familiar familiar = db.Familiars.Find(id);
            if (familiar == null)
            {
                return HttpNotFound();
            }
            return View(familiar);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Familiares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Familiar familiar = db.Familiars.Find(id);
            db.Familiars.Remove(familiar);
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
