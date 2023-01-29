using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
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
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var funcionario = new Classes.Funcionario();
            funcionario.Nome = txtNome.Text;
            funcionario.DataN = txtNascimento.Text;
            funcionario.Cpf = txtCPF.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Tel = txtTel.Text;
            funcionario.Setor = Convert.ToInt32(ddlSetor.SelectedValue);
            new Negocio.Funcionario().Create(funcionario);

            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
        }
    }
}