using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Maquina
{
    public partial class Produtividade : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("../../Login/index.aspx");
            }

            if (!IsPostBack)
            {
                connection.Open();
                ddlSetor.Items.Clear();
                var rdr = new MySqlCommand("SELECT descricao, id FROM setor", connection).ExecuteReader();
                while (rdr.Read())
                {
                    var setor = new ListItem(rdr.GetString("descricao"), rdr.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }
                connection.Close();
            }

            connection.Open();
            var rdr2 = new MySqlCommand($"SELECT id, SUM(NPecasBoas) AS 'PecasBoas', id_setor, idMaquina FROM processo " +
                                        $"WHERE id_setor = {ddlSetor.SelectedValue} GROUP BY idMaquina", connection).ExecuteReader();
            
            int i = 0;

            ddlMaquina.Items.Clear();
            ddlPecas.Items.Clear();

            while (rdr2.Read())
            {
                i++;

                var item = new ListItem(rdr2.GetString("idMaquina"), rdr2.GetString("idMaquina"));
                ddlMaquina.Items.Add(item);

                item = new ListItem(rdr2.GetInt32("PecasBoas").ToString(), rdr2.GetInt32("PecasBoas").ToString());
                ddlPecas.Items.Add(item);
            }
            noMaquinas.Value = i.ToString();
        }
    }
}