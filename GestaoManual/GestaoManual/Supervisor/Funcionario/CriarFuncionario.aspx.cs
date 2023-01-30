using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Funcionario
{
    public partial class CriarFuncionario : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCPF.MaxLength= 11;
            int id = Convert.ToInt32(Session["Login"].ToString());
            if (IsPostBack == false)
            {
                connection.Open();
                ddlSetor.Items.Clear();
                var rdr = new MySqlCommand($"SELECT id, descricao FROM setor", connection).ExecuteReader();
                while(rdr.Read())
                {
                    var setor = new ListItem(rdr.GetString("descricao"), rdr.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }
                connection.Close();

                connection.Open();
                var reader = new MySqlCommand($"SELECT * FROM login WHERE id={id} AND id_acesso=4", connection).ExecuteReader();
                while (reader.Read())
                {
                    dev.Visible = true;
                    setor.Visible = true;
                }
                connection.Close();
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Login"].ToString());

            // Caso o usuario tiver o nível de acesso como dev
            if(dev.Visible == true)
            {
                var funcionario = new Classes.Funcionario();
                funcionario.Nome = txtNome.Text;
                funcionario.DataN = txtNascimento.Text;
                funcionario.Cpf = txtCPF.Text;
                funcionario.Email = txtEmail.Text;
                funcionario.Tel = txtTel.Text;
                funcionario.Setor = Convert.ToInt32(ddlSetor.SelectedValue);
                new Negocio.Funcionario().Create(funcionario);
            }
            else // Para outros acessos
            {
                connection.Open();
                var rdr = new MySqlCommand($"SELECT id, id_registro, idsetor FROM encarregado WHERE id_registro={id}", connection).ExecuteReader();
                while (rdr.Read())
                {
                    var setor = new ListItem(rdr.GetInt32("idsetor").ToString(), rdr.GetInt32("id_registro").ToString());
                    lblInvisivel.Text = setor.ToString();
                }
                connection.Close();

                var funcionario = new Classes.Funcionario();
                funcionario.Nome = txtNome.Text;
                funcionario.DataN = txtNascimento.Text;
                funcionario.Cpf = txtCPF.Text;
                funcionario.Email = txtEmail.Text;
                funcionario.Tel = txtTel.Text;
                funcionario.Setor = Convert.ToInt32(lblInvisivel.Text);
            }




            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
        }
    }
}