using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Login
{
    public partial class Logar : System.Web.UI.Page
    {
        protected static string senha;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtSenha.TextMode = TextBoxMode.Password;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        protected void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            string Password = txtSenha.Text;
            txtSenha.Attributes.Add("value", Password);

            if (chkMostrarSenha.Checked)
            {
                txtSenha.TextMode = TextBoxMode.SingleLine;
            }
            else
            {   
                txtSenha.TextMode = TextBoxMode.Password;
            }
        }
    }
}