using M17E_Lar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M17E_Lar.Controllers
{
    [Authorize(Roles ="Administrador")]
    public class ConsultasController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();
        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult PesquisaFamiliar()
        {
            string nome = Request.Form["tbNome"];
            var familiares = db.Familiars.Where(c => c.Nome.Contains(nome));
            return View("PesquisaFamiliar", familiares.ToList());
        }
        public ActionResult PesquisaDinamica()
        {
            return View();
        }
        public JsonResult PesquisaNome(string nome)
        {
            var familiares = db.Familiars.Where(c => c.Nome.Contains(nome)).ToList();
            var lista = new List<Campos>();
            foreach (var c in familiares)
                lista.Add(new Campos() { nome = c.Nome });
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MaisVisFamiliar()
        {
            string sql = @"SELECT Familiars.nome,count(ID_Visita) as [Nº Visitas]
                            FROM Visitas INNER JOIN Familiars
                            ON Visitas.ID=Familiars.FamiliarID
                            GROUP BY Visitas.ID,Familiars.nome";

            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }
        public ActionResult VisitasDeUmFamiliar()
        {

            return View();
        }
        [HttpPost]
        //VER PROBLEMA DO ID
        public ActionResult VisitasDeUmFamiliar(string nome)
        {
            string sql = @"Select nome,count(*) as N_Visitas
                            from Visitas INNER JOIN Familiars
                            ON Visitas.ID=Familiars.FamiliarID
                            where nome like @p0
                            GROUP By nome";

            // SqlParameter parametro = new SqlParameter("@p1", "%" + nome + "%");
            var visitas = db.Database.SqlQuery<Campos>(sql, "%" + nome + "%");

            if (visitas != null && visitas.ToList().Count > 0)
                ViewBag.visitas = visitas.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.visitas = temp;
            }
            return View();
        }
        public class Campos
        {
            public string nome { get; set; }
            //public decimal valor { get; set; }
            public int n_visitas { get; set; }
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