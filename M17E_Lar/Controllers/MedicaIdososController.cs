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
    public class MedicaIdososController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();

        // GET: MedicaIdosos
        public ActionResult Index()
        {
            var medicaIdosoes = db.MedicaIdosoes.Include(m => m.idoso).Include(m => m.medicamento);
            return View(medicaIdosoes.ToList());
        }

        // GET: MedicaIdosos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicaIdoso medicaIdoso = db.MedicaIdosoes.Find(id);
            if (medicaIdoso == null)
            {
                return HttpNotFound();
            }
            return View(medicaIdoso);
        }

        // GET: MedicaIdosos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome");
            ViewBag.ID_Medicamento = new SelectList(db.Medicamentoes, "ID_Medicamento", "Nome");
            return View();
        }

        // POST: MedicaIdosos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MedicaIdoso,ID_Medicamento,ID_Idoso,data_inicio,data_fim,Dose,Obs")] MedicaIdoso medicaIdoso)
        {
            if(medicaIdoso.data_inicio > medicaIdoso.data_fim)
            {
                ModelState.AddModelError("data_inicio", "A data de inicio não pode ser superior à data final.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.MedicaIdosoes.Add(medicaIdoso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            

            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome", medicaIdoso.ID_Idoso);
            ViewBag.ID_Medicamento = new SelectList(db.Medicamentoes, "ID_Medicamento", "Nome", medicaIdoso.ID_Medicamento);
            return View(medicaIdoso);
        }

        // GET: MedicaIdosos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicaIdoso medicaIdoso = db.MedicaIdosoes.Find(id);
            if (medicaIdoso == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome", medicaIdoso.ID_Idoso);
            ViewBag.ID_Medicamento = new SelectList(db.Medicamentoes, "ID_Medicamento", "Nome", medicaIdoso.ID_Medicamento);
            return View(medicaIdoso);
        }

        // POST: MedicaIdosos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MedicaIdoso,ID_Medicamento,ID_Idoso,data_inicio,data_fim,Dose,Obs")] MedicaIdoso medicaIdoso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicaIdoso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Idoso = new SelectList(db.Idosoes, "ID_Idoso", "Nome", medicaIdoso.ID_Idoso);
            ViewBag.ID_Medicamento = new SelectList(db.Medicamentoes, "ID_Medicamento", "Nome", medicaIdoso.ID_Medicamento);
            return View(medicaIdoso);
        }

        // GET: MedicaIdosos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicaIdoso medicaIdoso = db.MedicaIdosoes.Find(id);
            if (medicaIdoso == null)
            {
                return HttpNotFound();
            }
            return View(medicaIdoso);
        }

        // POST: MedicaIdosos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicaIdoso medicaIdoso = db.MedicaIdosoes.Find(id);
            db.MedicaIdosoes.Remove(medicaIdoso);
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
