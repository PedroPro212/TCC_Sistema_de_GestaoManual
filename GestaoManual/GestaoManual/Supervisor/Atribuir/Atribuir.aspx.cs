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
        int acesso;
        int idSetor;
        static int setor;
        static int idMaquina;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string registro = Session["login"].ToString();

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
                    var operador = new ListItem("", "0");
                    ddlOperador.Items.Add(operador);
                    reader = new MySqlCommand("SELECT id, nome FROM funcionarios", connection).ExecuteReader();
                    while (reader.Read())
                    {
                        operador = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                        ddlOperador.Items.Add(operador);
                    }
                    connection.Close();
                }

                if (acesso == 2)
                {
                    connection.Open();
                    ddlOperador.Items.Clear();
                    reader = new MySqlCommand($"SELECT id, nome FROM funcionarios WHERE id_setor={idSetor}", connection).ExecuteReader();
                    while (reader.Read())
                    {
                        var operador = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                        ddlOperador.Items.Add(operador);
                    }
                    connection.Close();
                }
            }
        }

        protected void ddlOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand comando = new MySqlCommand($"SELECT id_setor FROM funcionarios WHERE id={ddlOperador.SelectedValue}", connection);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                idSetor = reader.GetInt32("id_setor");
            }
            connection.Close();

            connection.Open();
            ddlMaquina.Items.Clear();
            var maquina = new ListItem("", "0");
            ddlMaquina.Items.Add(maquina);
            reader = new MySqlCommand($"SELECT id, nome, id_setor FROM maquina WHERE id_setor={idSetor}", connection).ExecuteReader();
            setor = idSetor;
            while (reader.Read())
            {
                maquina = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                ddlMaquina.Items.Add(maquina);
            }
            connection.Close();

            if (ddlOperador.SelectedValue == "0")
            {
                ddlMaquina.Items.Clear();
                ddlMaquina.Enabled = false;
            }
            else
                ddlMaquina.Enabled = true;

            //if ((ddlOperador.SelectedValue == "0") || (ddlMaquina.SelectedValue == "0"))
            //    btnAtribuir.Enabled = false;
            //else
            //    btnAtribuir.Enabled = true;
        }

        protected void btnAtribuir_Click(object sender, EventArgs e)
        {
            var operador = new Classes.Operador();
            operador.IdMaquina = Convert.ToInt32(ddlMaquina.SelectedValue);
            operador.IdSetor = setor;
            operador.IdRegistro = Convert.ToInt32(ddlOperador.SelectedValue);
            new Negocio.Operador().Create(operador);
        }

        protected void ddlMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMaquina = Convert.ToInt32(ddlMaquina.SelectedValue);

            if ((ddlOperador.SelectedValue == "0") || (ddlMaquina.SelectedValue == "0"))
                btnAtribuir.Enabled = false;
            else
                btnAtribuir.Enabled = true;
        }
    }
}