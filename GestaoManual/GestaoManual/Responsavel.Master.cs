using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual
{
    public partial class Responsavel : System.Web.UI.MasterPage
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            connection.Open();
            int id = Convert.ToInt32(Session["Login"].ToString());

            var rdr = new MySqlCommand("select id, substring_index(nome, ' ', -1) as UltimoNome, substring_index(nome, ' ', 1) as PrimeiroNome from funcionarios WHERE id=" + id, connection).ExecuteReader();
            while (rdr.Read())
            {
                var segundo = new ListItem(rdr.GetString("UltimoNome"), rdr.GetInt32("id").ToString());
                var primeiro = new ListItem(rdr.GetString("PrimeiroNome"), rdr.GetInt32("id").ToString());
                var nome = segundo + ", " + primeiro;
                lblNome.Text = nome;
            }
            connection.Close();
        }
    }
}