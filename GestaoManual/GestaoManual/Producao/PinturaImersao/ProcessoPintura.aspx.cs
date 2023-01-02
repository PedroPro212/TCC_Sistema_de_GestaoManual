using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;

namespace GestaoManual.Producao.PinturaImersao
{
    public partial class ProcessoPintura : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            connection.Open();
            int id = Convert.ToInt32(Session["Login"].ToString());

            var reader = new MySqlCommand("select id, substring_index(nome, ' ', -1) as UltimoNome, substring_index(nome, ' ', 1) as PrimeiroNome from funcionarios WHERE id=" + id, connection).ExecuteReader();
            while(reader.Read())
            {
                var segundo = new ListItem(reader.GetString("UltimoNome"), reader.GetInt32("id").ToString());
                var primeiro = new ListItem(reader.GetString("PrimeiroNome"), reader.GetInt32("id").ToString());
                var nome = segundo + ", " + primeiro;
                lblNome.Text = nome;
            }
            connection.Close();

            connection.Open();
            int idP = Convert.ToInt32(Session["Produto"].ToString());
            var rdr = new MySqlCommand($"SELECT id, descricao FROM produto WHERE id={idP} AND id_setor=2", connection).ExecuteReader();
            while(rdr.Read())
            {
                var produto = new ListItem(rdr.GetString("descricao"), rdr.GetInt32("id").ToString());
                lblProduto.Text = produto.ToString();
            }
            connection.Close();

        }

        protected void tmrInicio_Tick()
        {
            lblHoraInicio.Text = DateTime.Now.ToString("HH:mm:ss dd:MM:yy");
        }
    }
}