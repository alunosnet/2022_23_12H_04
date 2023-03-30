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
    public class MedicamentosController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();

        // GET: Medicamentos
        public ActionResult Index()
        {
            return View(db.Medicamentoes.ToList());
        }

        // GET: Medicamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Medicamento,Nome,Contra,Forma")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentoes.Add(medicamento);
                db.SaveChanges();
                HttpPostedFileBase fotografia_medicamento = Request.Files["fotografia"];
                if (fotografia_medicamento != null && fotografia_medicamento.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Medicamento/") + medicamento.ID_Medicamento + ".jpg";
                    fotografia_medicamento.SaveAs(nome);
                }
                return RedirectToAction("Index");
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Medicamento,Nome,Contra,Forma")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicamento medicamento = db.Medicamentoes.Find(id);
            db.Medicamentoes.Remove(medicamento);
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
