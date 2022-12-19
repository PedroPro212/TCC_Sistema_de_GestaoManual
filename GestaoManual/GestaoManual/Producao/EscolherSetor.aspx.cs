using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Producao
{
    public partial class EscolherSetor : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                connection.Open();
                ddlSetor.Items.Clear();
                var reader = new MySqlCommand("SELECT id, descricao FROM setor WHERE id!=0", connection).ExecuteReader();
                while(reader.Read())
                {
                    var setor = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }   
                connection.Close();

                connection.Open();
                int id = Convert.ToInt32(Session["Login"].ToString());

                var rdr = new MySqlCommand("select id, substring_index(nome, ' ', -1) as UltimoNome, substring_index(nome, ' ', 1) as PrimeiroNome from funcionarios WHERE id=" + id, connection).ExecuteReader();
                while(rdr.Read())
                {
                    var segundo = new ListItem(rdr.GetString("UltimoNome"), rdr.GetInt32("id").ToString());
                    var primeiro = new ListItem(rdr.GetString("PrimeiroNome"), rdr.GetInt32("id").ToString());
                    var nome = segundo + ", " + primeiro;
                    lblNome.Text = nome;
                }
                connection.Close();
                
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            connection.Open();
            int value = Convert.ToInt32(ddlSetor.SelectedValue);

            if(value == 1)
            {
                Response.Redirect("Corte/Corte.aspx");
            }
            else if(value == 2)
            {
                Response.Redirect("PinturaImersao/PinturaImersao.aspx");
            }
            else
            {
                SiteMaster.AlertPersonalizado(this, "Tende novamente");
            }
            connection.Close();
        }
    }
}