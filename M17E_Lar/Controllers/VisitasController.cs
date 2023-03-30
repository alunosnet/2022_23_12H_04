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
    public class VisitasController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();

        // GET: Visitas
        public ActionResult Index(int id = 1)
        {

            var visitas = db.Visitas.Include(v => v.familiar).Include(v => v.idoso);
            return View(visitas.ToList());
            
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Familiars, "FamiliarID", "Nome");
            ViewBag.ID_Idoso = new SelectList(db.Idosoes.Where( q=> q.Estado==false), "ID_Idoso", "Nome");
            return View();
        }

        // POST: Visitas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Visita,ID,ID_Idoso,DataVisita,RelacaoFamiliar")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                //Estado
                var idoso = db.Idosoes.Find(visita.ID_Idoso);
                idoso.Estado = true;
                db.Entry(idoso).CurrentValues.SetValues(idoso);

                db.Visitas.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Familiars, "FamiliarID", "Nome", visita.ID);
            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome", visita.ID_Idoso);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Familiars, "FamiliarID", "Nome", visita.ID);
            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome", visita.ID_Idoso);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Visita,ID,ID_Idoso,DataVisita,RelacaoFamiliar")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Familiars, "FamiliarID", "Nome", visita.ID);
            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome", visita.ID_Idoso);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {


                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visitas.Find(id);
            db.Visitas.Remove(visita);
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
