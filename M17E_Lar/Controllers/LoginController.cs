using M17E_Lar.Data;
using M17E_Lar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace M17E_Lar.Controllers
{
    public class LoginController : Controller
    {
        private M17E_LarContext db = new M17E_LarContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Utilizador utilizador)
        {
            if (utilizador.Nome != null && utilizador.Password != null)
            {
                //HASH PASSWORD
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 2 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                foreach (var u in db.Utilizadors.ToList())
                {
                    if (u.Nome.ToLower() == utilizador.Nome.ToLower() && u.Password == utilizador.Password)
                    {
                        //INICIAR SESSÃO
                        FormsAuthentication.SetAuthCookie(utilizador.Nome, false);
                        //redirecionar
                        if (Request.QueryString["ReturnUrl"] == null)
                        {
                            return RedirectToAction("Index", "Home");

                        }
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente Novamente.");
            return View(utilizador);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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