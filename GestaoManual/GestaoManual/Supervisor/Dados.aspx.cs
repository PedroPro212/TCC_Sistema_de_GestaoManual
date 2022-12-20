using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor
{
    public partial class Dados : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSenha1.Enabled= false;
            txtSenha2.Enabled= false;

            int id = Convert.ToInt32(Session["Login"].ToString());
            try
            {
                connection.Open();
                var rdr = new MySqlCommand($"SELECT id, nome, data_nascimento, email, tel, id_setor FROM funcionarios WHERE id={id}", connection).ExecuteReader();
                while(rdr.Read())
                {
                    var nome = new ListItem(rdr.GetString("nome"), rdr.GetInt32("id").ToString());
                    var email = new ListItem(rdr.GetString("email"), rdr.GetInt32("id").ToString());

                    lblNome.Text = nome.ToString();
                    txtEmail.Text = email.ToString();
                }
                connection.Close();
            }
            catch
            {
                SiteMaster.AlertPersonalizado(this, "Não foi possível trazer os seus dados");
            }
            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void ckbSenha_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbSenha.Checked == true)
            {
                txtSenha1.Enabled = true;
                txtSenha2.Enabled = true;
            }
            else
            {
                txtSenha1.Enabled = false;
                txtSenha2.Enabled = false;
                txtSenha1.Text = "";
                txtSenha2.Text = "";
            }
        }
    }
}