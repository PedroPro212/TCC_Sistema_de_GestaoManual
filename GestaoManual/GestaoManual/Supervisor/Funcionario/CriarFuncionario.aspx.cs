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
            if (Session["Login"] == null)
            {
                Response.Redirect("../../Login/index.aspx");
            }

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
                try
                {
                    if(TxtVazia() == false)
                    {
                        SiteMaster.AlertPersonalizado(this, "Todos os campos precisam estarem preenchidos");
                    }
                    else
                    {
                        var funcionario = new Classes.Funcionario();
                        funcionario.Nome = txtNome.Text;
                        funcionario.DataN = txtNascimento.Text;
                        funcionario.Cpf = txtCPF.Text;
                        funcionario.Email = txtEmail.Text;
                        funcionario.Tel = txtTel.Text;
                        funcionario.Setor = Convert.ToInt32(ddlSetor.SelectedValue);
                        new Negocio.Funcionario().Create(funcionario);

                        SiteMaster.AlertPersonalizado(this, "Cadastrado com sucesso");
                    }

                }
                catch(Exception ex)
                {
                    SiteMaster.AlertPersonalizado(this, "Aconteceu um erro: " + ex);
                }
            }
            else // Para outros acessos
            {
                try
                {
                    if(TxtVazia() == false)
                    {
                        SiteMaster.AlertPersonalizado(this, "Todos os campos precisam estarem preenchidos");
                    }
                    else
                    {
                        connection.Open();
                        var reader = new MySqlCommand($"SELECT id, id_setor FROM funcionarios WHERE id={id}", connection).ExecuteReader();
                        while (reader.Read())
                        {
                            var setor = new ListItem(reader.GetInt32("id_setor").ToString(), reader.GetInt32("id").ToString());
                            lblInvisivel2.Text = setor.ToString();
                        }
                        connection.Close();

                        var funcionario = new Classes.Funcionario();
                        funcionario.Nome = txtNome.Text;
                        funcionario.DataN = txtNascimento.Text;
                        funcionario.Cpf = txtCPF.Text;
                        funcionario.Email = txtEmail.Text;
                        funcionario.Tel = txtTel.Text;
                        funcionario.Setor = Convert.ToInt32(lblInvisivel2.Text);
                        new Negocio.Funcionario().Create(funcionario);
                    }

                }
                catch(Exception ex)
                {
                    SiteMaster.AlertPersonalizado(this, "Ops, aconteceu um erro ao cadastrar:\n" + ex);
                }

            }

            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
        }

        public bool TxtVazia()
        {
            if((txtNome.Text == "")||(txtNascimento.Text == "")||(txtCPF.Text == "")||(txtEmail.Text == "")||(txtTel.Text == ""))
            {
                return false;
            }
            return true;
        }
    }
}