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
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSenha.MaxLength = 6;
            txtSenha.TextMode = TextBoxMode.Password;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarSenha.Checked)
                txtSenha.TextMode = TextBoxMode.SingleLine; 
            else
                txtSenha.TextMode = TextBoxMode.Password;
        }
    }
}