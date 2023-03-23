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

namespace GestaoManual.Login
{
    public partial class RedefinirSenha : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGerar_Numero_Click(object sender, EventArgs e)
        {
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
            catch(Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, "Email não localizado\n" + ex);
            }

            // Gerar número
            Random random = new Random();
            int numeroAleatorio = random.Next(1000, 9999);

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
            mailMessage.Subject = "Seu código para redefinir sua senha chegou!!";
            mailMessage.Body = "Cuidado, não espalhe para ninguém seu código!\nCódigo: " + numeroAleatorio;
            Session["numeroAleatorio"] = numeroAleatorio;

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
    }
}