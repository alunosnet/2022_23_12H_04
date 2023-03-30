using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo
{
    public partial class recuperarpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                string password = tb_password.Text.Trim();
                if (password.Length == 0)
                    throw new Exception("Tem de indicar uma password");
                string guid = Server.UrlDecode(Request["id"].ToString());
                Models.Utilizador utilizador = new Models.Utilizador();
                lb_erro.Text = "Password atualizada com sucesso";
                // redirecionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);

            }
            catch (Exception erro)
            {
                lb_erro.Text = erro.Message;
            }
        }
    }
}