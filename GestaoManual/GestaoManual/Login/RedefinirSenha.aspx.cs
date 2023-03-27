using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Login
{
    public partial class RedefinirSenha1 : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if(ValidarSenha() == true)
            {
                var dados = new Classes.Dados();
                dados.Id = Convert.ToInt32(Session["RegistroRedef"]);
                dados.Senha = txtSenha2.Text;
                new Negocio.Dados().UpdateSenha(dados);

                Response.Redirect("index.aspx");
            }
            else
            {
                SiteMaster.AlertPersonalizado(this, "As senhas não conferem");
            }
        }

        public bool ValidarSenha()
        {
            if(txtSenha1.Text == txtSenha2.Text)
            {
                return true;
            }
            else
            {
                SiteMaster.AlertPersonalizado(this, "As senhas não conferem");
                return false;
            }
        }
    }
}