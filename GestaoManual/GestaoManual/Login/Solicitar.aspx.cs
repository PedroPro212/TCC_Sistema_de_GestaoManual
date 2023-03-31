using Microsoft.Office.Interop.Excel;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace GestaoManual.Login
{
    public partial class RedefinirSenha : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        public int numeroAleatorio = 0;
        public static DateTime tempoEnvio = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtN1.MaxLength = 1;
            txtN2.MaxLength = 1;
            txtN3.MaxLength = 1;
            txtN4.MaxLength = 1;
            divConferir.Visible = false;
        }

        protected void btnGerar_Numero_Click(object sender, EventArgs e)
        {
            if(Conferir() == true)
            {
                divSolicitar.Visible = false;
                divConferir.Visible = true;
                // Capturar o email do funcionário
                string email = "";
                try
                {
                    connection.Open();
                    var comando = new MySqlCommand($@"SELECT id,email FROM funcionarios where id=@id", connection);
                    comando.Parameters.Add(new MySqlParameter("id", txtRegistro.Text));
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        email = reader.GetString("email");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    SiteMaster.AlertPersonalizado(this, "Email não localizado\n" + ex);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, "Email não localizado\n" + ex);
            }

                // Gerar número
                Random random = new Random();
                numeroAleatorio = random.Next(1000, 9999);

            try
            {
                connection.Open();
                var comando2 = new MySqlCommand($@"UPDATE `login` SET `CdRecuperacao`='{numeroAleatorio.ToString()}',`CdRecDataCriacao`=NOW() WHERE registro=@registro;", connection);
                comando2.Parameters.Add(new MySqlParameter("registro", txtRegistro.Text));
                comando2.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {

            }


            // Enviar Email
            string remetente = "0000888202@senaimgaluno.com.br";
            string destinatario = email;
            string senha = "Pe212004ho";

                var smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 10000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(remetente, senha);

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(remetente);
            mailMessage.To.Add(destinatario);
            mailMessage.Subject = "Código de redefinição de senha";
            mailMessage.Body = "Uma solicitação de redefinição de senha foi iniciada por sua conta.\n" +
                "Se não foi você que a solicitou, ignore esta mensagem.\n" +
                "Por sua segurança, não compartilhe este código.\nCódigo: " + numeroAleatorio;
            //Session["numeroAleatorio"] = numeroAleatorio;
            Session["RigistroRedefinir"] = txtRegistro.Text;


                try
                {
                    for (int i = 0; i < 1; i++)
                    {
                        smtpClient.Send(mailMessage);
                    }

                }
                catch (Exception ex)
                {
                    SiteMaster.AlertPersonalizado(this, "Erro ao enviar email: " + ex);
                }
            }

            catch (Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, "Erro ao enviar email: " + ex);
            }

            tempoEnvio = DateTime.Now;

        }

        protected void btnConferir_Click(object sender, EventArgs e)
        {
            string N1 = txtN1.Text;
            string N2 = txtN2.Text;
            string N3 = txtN3.Text;
            string N4 = txtN4.Text;
            string resulS = N1 + N2 + N3 + N4;
            int resulI = Convert.ToInt32(resulS);
            // int numeroAleatorio = (int)Session["numeroAleatorio"];
            int numeroAleatorio =55555;
            DateTime tempoConferir = DateTime.Now;

            txtTeste.Text = Convert.ToString(tempoConferir - tempoEnvio);

            connection.Open();
            var comando = new MySqlCommand($@"SELECT CdRecuperacao FROM login where registro = @registro", connection);
            comando.Parameters.Add(new MySqlParameter("registro", txtRegistro.Text));
            var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                numeroAleatorio =  Convert.ToInt32(reader.GetString("CdRecuperacao"));
            }
            connection.Close();

            Session["RegistroRedef"] = txtRegistro.Text;
            
            if (resulI == numeroAleatorio)
            {
                Response.Redirect("RedefinirSenha.aspx");
            }
            else
            {
                SiteMaster.AlertPersonalizado(this, "As senhas não conferem!");
            }

        }

        public bool Conferir()
        {
            if(txtRegistro.Text == "")
            {
                SiteMaster.AlertPersonalizado(this, "O campo de registro está vazio, coloque seu registro para solicitar a redefinição da senha");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}