using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor
{
    public partial class Suporte : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        int id;
        int idSetor;
        string nome;
        string email;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("../Login/index.aspx");
            }

            connection.Open();
            id = Convert.ToInt32(Session["Login"].ToString());
            var rdr = new MySqlCommand($"SELECT id_setor, nome, email FROM funcionarios WHERE id = {id}", connection).ExecuteReader();
            if (rdr.Read())
            {
                idSetor = rdr.GetInt32("id_setor");
                nome = rdr.GetString("nome");
                email = rdr.GetString("email");
            }
            connection.Close();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            var problema = new Classes.Problema();
            problema.IdRegistro = Convert.ToInt32(Session["Login"].ToString());
            problema.IdSetor = idSetor;
            problema.NomeProblema = ddlSuporte.SelectedItem.Text;
            problema.Descricao = txtPergunta.Text;
            new Negocio.Problema().Create(problema);
            new Negocio.Problema().EnviarEmail(ddlSuporte.SelectedItem.Text, txtPergunta.Text, nome, email, problema.IdRegistro, problema.IdSetor);

            txtPergunta.Text = "";
        }
    }
}