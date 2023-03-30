using M17E_Lar.Data;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M17E_Lar.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper,
            System.Security.Principal.IPrincipal utilzador)
        {
            string iduser = "";
            using (var context = new M17E_LarContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT Id FROM Utilizadors WHERE nome = @p0",
                    utilzador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }
            return iduser;
        }
    }
}