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
    public class IdososController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();

        // GET: Idosos
        public ActionResult Index()
        {
            // Obter a lista de dados do seu model
            var dados = db.Idosoes.ToList();
            // Ordenar a lista alfabeticamente
            dados = dados.OrderBy(d => d.Nome).ToList();
            return View(dados);
            //return View(db.Idosoes.ToList());
           
        }

        // GET: Idosos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idoso idoso = db.Idosoes.Find(id);
            if (idoso == null)
            {
                return HttpNotFound();
            }
            return View(idoso);
        }

        // GET: Idosos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idosos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Idoso,Nome,Data_Nasc,Doenças,NUtenteSaude,Estado")] Idoso idoso)
        {
            if (idoso.Data_Nasc.Year >= 1980)
            {
                ModelState.AddModelError("Data_Nasc", "A data de Nascimento tem de ser inferior a 1980");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Idosoes.Add(idoso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            

            return View(idoso);
        }

        // GET: Idosos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idoso idoso = db.Idosoes.Find(id);
            if (idoso == null)
            {
                return HttpNotFound();
            }
            return View(idoso);
        }

        // POST: Idosos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Idoso,Nome,Data_Nasc,Doenças,NUtenteSaude,Estado")] Idoso idoso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idoso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idoso);
        }

        // GET: Idosos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idoso idoso = db.Idosoes.Find(id);
            if (idoso == null)
            {
                return HttpNotFound();
            }
            return View(idoso);
        }

        // POST: Idosos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idoso idoso = db.Idosoes.Find(id);
            db.Idosoes.Remove(idoso);
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
