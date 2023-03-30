using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using M17E_Lar.Data;
using M17E_Lar.Models;
using Microsoft.Ajax.Utilities;

namespace M17E_Lar.Controllers
{
    
    public class UtilizadoresController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();
        [Authorize(Roles = "Administrador")]
        // GET: Utilizadores
        public ActionResult Index(int id = 1)
        {
            var dados = db.Utilizadors.ToList();
            if (id == 1)
            {
                dados = dados.OrderBy(d => d.Nome).ToList();
            }
            else if(id == 2){
                dados = dados.OrderBy(d => d.Perfil).ToList();

            }
            
            return View(dados);
            //return View(db.Utilizadors.ToList());
        }
        [Authorize(Roles = "Administrador")]
        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            var utilizador = new Utilizador();
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="0", Text="Administrador"},
                new SelectListItem{Value="1", Text="Funcionário"}
            };
            return View(utilizador);
        }

        // POST: Utilizadores/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Email,Password,Perfil")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="0", Text="Administrador"},
                new SelectListItem{Value="1", Text="Funcionário"}
            };
            if (ModelState.IsValid)
            {
                //Verificar se o nome de utilizador já existe
                var temp = db.Utilizadors.Where(u => u.Nome == utilizador.Nome).ToList();
                if (temp != null && temp.Count > 0)
                {
                    ModelState.AddModelError("Nome", "Já existe um utilizador com esse nome");
                    return View(utilizador);
                }
                //Validar a password
                if (utilizador.Password.Trim().Length < 5)
                {
                    ModelState.AddModelError("Password", "A palavra passe deve ter pleo menos 5 letras");
                    return View(utilizador);
                }
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }
        [Authorize]
        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Administrador"))
            {
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="0", Text="Administrador"},
                    new SelectListItem{Value="1", Text="Funcionário"}
                };
            }
            else
            {
                var temp = db.Utilizadors.Where(u => u.Nome == User.Identity.Name).FirstOrDefault();
                utilizador = temp;
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Funcionário"}
                };
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Email,Password,Perfil")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="0", Text="Administrador"},
                new SelectListItem{Value="1", Text="Funcionário"}
            };

            if (ModelState.IsValid)
            {
                if (utilizador.Password.Trim().Length < 5)
                {
                    ModelState.AddModelError("Password", "A palavra passe deve ter pleo menos 5 letras");
                    return View(utilizador);
                }
                //Hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Administrador"))
                    return RedirectToAction("Index","Utilizadores");
                else
                    return RedirectToAction("Index");
            }
            if (User.IsInRole("Administrador") == false)
            {
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Funcionário"}
                };
            }
            return View(utilizador);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Utilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            db.Utilizadors.Remove(utilizador);
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
