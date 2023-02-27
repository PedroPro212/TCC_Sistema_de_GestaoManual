using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Atribuir
{
    public partial class Atribuir : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string registro = Session["login"].ToString();
            int acesso = 0;
            int idSetor = 0;

            connection.Open();
            MySqlCommand comando = new MySqlCommand("SELECT l.id_acesso, f.id_setor FROM login AS l, funcionarios AS f WHERE l.registro = f.id AND l.registro = @registro", connection);
            comando.Parameters.AddWithValue("@registro", registro);
            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                acesso = reader.GetInt32("id_acesso");
                idSetor = reader.GetInt32("id_setor");
            }
            connection.Close();

            if (acesso == 4)
            {
                connection.Open();
                ddlOperador.Items.Clear();
                reader = new MySqlCommand("SELECT id, nome FROM funcionarios", connection).ExecuteReader();
                while (reader.Read())
                {
                    var operador = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                    ddlOperador.Items.Add(operador);
                }
                connection.Close();
            }

            if (acesso == 2)
            {
                connection.Open();
                ddlOperador.Items.Clear();
                reader = new MySqlCommand($"SELECT id, nome FROM funcionarios WHERE id_setor ={idSetor}", connection).ExecuteReader();
                while (reader.Read())
                {
                    var operador = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                    ddlOperador.Items.Add(operador);
                }
                connection.Close();

                connection.Open();
                ddlMaquina.Items.Clear();
                reader = new MySqlCommand($"SELECT id, nome FROM maquina WHERE id_setor={idSetor}", connection).ExecuteReader();
                while (reader.Read())
                {
                    var maquina = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                    ddlMaquina.Items.Add(maquina);
                }
            }
        }
    }
}