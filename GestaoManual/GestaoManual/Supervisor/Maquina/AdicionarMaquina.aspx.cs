using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Maquina
{
    public partial class AdicionarMaquina : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Login"].ToString());
            
            if (IsPostBack == false)
            {
                connection.Open();
                ddlSetor.Items.Clear();
                var rdr = new MySqlCommand($"SELECT id, descricao FROM setor WHERE id!=0", connection).ExecuteReader();
                while (rdr.Read())
                {
                    var setor = new ListItem(rdr.GetString("descricao"), rdr.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }
                connection.Close();

                connection.Open();
                var reader = new MySqlCommand($"SELECT * FROM login WHERE id={id} AND id_acesso=4", connection).ExecuteReader();
                while(reader.Read())
                {
                    dev.Visible= true;
                    pSetor.Visible= true;
                    ddlSetor.Visible= true;
                }
                connection.Close();
            }
           
        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Login"].ToString());

            if(dev.Visible == true)
            {
                try
                {
                    connection.Open();
                    var reader = new MySqlCommand($"SELECT id, id_registro, idsetor FROM encarregado WHERE idsetor=" + ddlSetor.SelectedValue, connection).ExecuteReader();
                    while (reader.Read())
                    {
                        var encarregado = new ListItem(reader.GetInt32("id_registro").ToString(), reader.GetInt32("id").ToString());
                        lblinvisivel.Text = encarregado.ToString();
                    }
                    connection.Close();

                    var maquina = new Classes.Maquina();
                    maquina.Nome = txtNome.Text;    
                    maquina.idSetor = Convert.ToInt32(ddlSetor.SelectedValue);
                    maquina.idEncarregado = Convert.ToInt32(lblinvisivel.Text);
                    new Negocio.Maquina().Create(maquina);

                    SiteMaster.AlertPersonalizado(this, "Funcionário cadastrado com sucesso");
                }
                catch
                {
                    SiteMaster.AlertPersonalizado(this, "Não foi possível cadastrar o funcionário no momento, se o erro persistir contate o suporte");
                }
            }
            else
            {
                try
                {
                    // Capturar setor
                    connection.Open();
                    var rdr = new MySqlCommand($"SELECT id, id_setor FROM funcionarios WHERE id={id}", connection).ExecuteReader();
                    while (rdr.Read())
                    {
                        var setor = new ListItem(rdr.GetInt32("id_setor").ToString(), rdr.GetInt32("id").ToString());
                        lblinvisivel2.Text = setor.ToString();
                    }
                    connection.Close();

                    // Capturar encarregado
                    connection.Open();
                    var reader = new MySqlCommand($"SELECT id, registro, id_acesso FROM login WHERE id={id}", connection).ExecuteReader();
                    while (reader.Read())
                    {
                        var encarregado = new ListItem(reader.GetInt32("registro").ToString(), reader.GetInt32("id").ToString());
                        lblinvisivel.Text = encarregado.ToString();
                    }
                    connection.Close();

                    var maquina = new Classes.Maquina();
                    maquina.Nome = txtNome.Text;
                    maquina.idSetor = Convert.ToInt32(lblinvisivel2.Text);
                    maquina.idEncarregado = Convert.ToInt32(lblinvisivel.Text);
                    new Negocio.Maquina().Create(maquina);

                    SiteMaster.AlertPersonalizado(this, "Funcionário cadastrado com sucesso");
                }
                catch
                {
                    SiteMaster.AlertPersonalizado(this, "Não foi possível cadastrar o funcionário no momento, se o erro persistir contate o suporte");
                }
            }
        }
    }
}