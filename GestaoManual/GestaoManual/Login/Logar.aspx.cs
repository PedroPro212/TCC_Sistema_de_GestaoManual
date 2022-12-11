using MySqlConnector;
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
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSenha.MaxLength = 6;
            if (!IsPostBack)
                txtSenha.TextMode = TextBoxMode.Password;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "SELECT * FROM login WHERE registro=@registro AND senha=@senha AND (id_acesso=1 OR id_acesso=2)";
            comando.Parameters.AddWithValue("@registro", txtRegistro.Text);
            comando.Parameters.AddWithValue("@senha", txtSenha.Text);
            MySqlDataReader dr;
            Session["Login"] = txtRegistro.Text;
            try
            {
                comando.Connection = connection;
                dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    //Response.Redirect("/Supervisor/Responsavel.aspx");
                    Response.Redirect("/Producao/EscolherSetor.aspx");
                }

                else
                {
                    SiteMaster.AlertPersonalizado(this, "Registro ou senha incorretos");
                    txtRegistro.Text = "";
                }
            }
            catch(Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, "Aconteceu o seguinte erro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }         
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