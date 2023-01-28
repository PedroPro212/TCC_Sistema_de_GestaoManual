using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor
{
    public partial class Dados : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            ckbSenha_CheckedChanged(null, null);
            ckbEditar_CheckedChanged(null, null);
            ckbEditarEmail_CheckedChanged(null, null);
            txtTelefone.MaxLength = 11;

            if ((ckbEditarEmail.Checked == true) && (ckbEditarTelefone.Checked == true))
            {
                txtEmail.Enabled = true;
                txtTelefone.Enabled = true;
            }
            else if ((ckbEditarEmail.Checked == true) && (ckbEditarTelefone.Checked == false))
            {
                txtEmail.Enabled = true;
                txtTelefone.Enabled = false;
            }
            else if ((ckbEditarEmail.Checked == false) && (ckbEditarTelefone.Checked == true))
            {
                txtEmail.Enabled = false;
                txtTelefone.Enabled = true;
            }
            else
            {
                txtEmail.Enabled = false;
                txtTelefone.Enabled = false;
            }

            int id = Convert.ToInt32(Session["Login"].ToString());
            
            if(!IsPostBack)
            try
            {
                connection.Open();
                var rdr = new MySqlCommand($"SELECT id, nome, data_nascimento, email, tel, id_setor FROM funcionarios WHERE id={id}", connection).ExecuteReader();
                while (rdr.Read())
                {
                    var nome = new ListItem(rdr.GetString("nome"), rdr.GetInt32("id").ToString());
                    var email = new ListItem(rdr.GetString("email"), rdr.GetInt32("id").ToString());
                    var data = new ListItem(rdr.GetDateTime("data_nascimento").ToString("dd/MM/yyyy"), rdr.GetInt32("id").ToString());
                    var tel = new ListItem(rdr.GetString("tel"), rdr.GetInt32("id").ToString());

                    lblNome.Text = nome.ToString();
                    txtEmail.Text = email.ToString();
                    lblData.Text = data.ToString();
                    txtTelefone.Text = tel.ToString();
                }
                connection.Close();

                connection.Open();
                var reader = new MySqlCommand($"SELECT l.id, l.registro, l.id_acesso, a.id, a.descricao FROM login as l, acesso as a WHERE a.id = l.id_acesso AND l.id={id}", connection).ExecuteReader();
                while (reader.Read())
                {
                    var setor = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());

                    lblSetor.Text = setor.ToString();
                }
                connection.Close();
            }

            catch
            {
                SiteMaster.AlertPersonalizado(this, "Não foi possível trazer os seus dados");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ckbSenha.Checked == true)
            {
                if (ValidarSenha() == true)
                {
                    var dados = new Classes.Dados();
                    dados.Id = Convert.ToInt32(Session["Login"].ToString());
                    dados.Senha = txtSenha2.Text;
                    new Negocio.Dados().UpdateSenha(dados);

                    SiteMaster.AlertPersonalizado(this, "Sua nova senha é: " + txtSenha2.Text);
                    txtSenha1.Text = "";
                    txtSenha2.Text = "";
                    ckbSenha.Checked = false;
                }
            }

            if (ckbEditarTelefone.Checked == true)
            {
                var dados = new Classes.Dados();
                dados.Id = Convert.ToInt32(Session["Login"].ToString());
                dados.Tel = txtTelefone.Text;
                new Negocio.Dados().UpdateTel(dados);
            }

            if (ckbEditarEmail.Checked == true)
            {
                var dados = new Classes.Dados();
                dados.Id = Convert.ToInt32(Session["Login"].ToString());
                dados.Email = txtEmail.Text;
                new Negocio.Dados().UpdateEmail(dados);
            }
        }
            

            protected void ckbSenha_CheckedChanged(object sender, EventArgs e)
            {
                if (ckbSenha.Checked == true)
                {
                    txtSenha1.Enabled = true;
                    txtSenha2.Enabled = true;
                }
                else
                {
                    txtSenha1.Enabled = false;
                    txtSenha2.Enabled = false;
                    txtSenha1.Text = "";
                    txtSenha2.Text = "";
                }
            }

            protected void ckbEditar_CheckedChanged(object sender, EventArgs e)
            {
                if (ckbEditarTelefone.Checked == true)
                    txtTelefone.Enabled = true;
                else
                    txtTelefone.Enabled = false;
            }

            protected void ckbEditarEmail_CheckedChanged(object sender, EventArgs e)
            {
                if (ckbEditarEmail.Checked == true)
                    txtEmail.Enabled = true;
                else
                    txtEmail.Enabled = false;
            }

            public bool ValidarSenha()
            {
                if (txtSenha1.Text == txtSenha2.Text)
                {
                    if ((txtSenha1.Text == "") || (txtSenha2.Text == ""))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    SiteMaster.AlertPersonalizado(this, "As senhas precisam ser iguais!");
                    return false;
                }
            }

            public bool ValidarEmail(string email)
            {
                string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (System.Text.RegularExpressions.Regex.IsMatch(email, strModelo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }