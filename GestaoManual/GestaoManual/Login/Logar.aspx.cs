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
        //string senha = txtSenha;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSenha.MaxLength = 6;
            txtSenha.TextMode = TextBoxMode.Password;
            txtSenha.Text = txtSenha.Text.Trim();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
                

            if (chkMostrarSenha.Checked)
            {
                txtSenha.TextMode = TextBoxMode.SingleLine;
                senha = txtSenha.Text;
            }

            else
            {   
                txtSenha.Text = senha;
                txtSenha.TextMode = TextBoxMode.Password;
            }
            
                
        }
    }
}