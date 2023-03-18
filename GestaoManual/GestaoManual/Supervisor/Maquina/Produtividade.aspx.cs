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

            DataTable table = new DataTable();
            table.Columns.Add("PecasBoas");
            table.Columns.Add("Maquina");

            while (rdr2.Read())
            {
                table.Rows.Add(rdr2.GetInt32("PecasBoas").ToString(), rdr2.GetString("idMaquina"));
            }
            dtlTeste.DataSource = table;
            dtlTeste.DataBind();
        }
    }
}