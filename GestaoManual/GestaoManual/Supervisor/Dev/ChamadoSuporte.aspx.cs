using GestaoManual.Classes;
using GestaoManual.Negocio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Dev
{
    public partial class ChamadoSuporte : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                connection.Open();
                ddlSetor.Items.Clear();
                var setor = new ListItem("Setor", "0");
                ddlSetor.Items.Add(setor);
                var reader = new MySqlCommand($"SELECT id, descricao FROM setor WHERE id!=0", connection).ExecuteReader();
                while (reader.Read())
                {
                    setor = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }
                connection.Close();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int setor = Convert.ToInt32(ddlSetor.SelectedValue);
            string nomeproblema = ddlProblema.SelectedValue;
            var problemas = new Negocio.Problema().Read(setor, txtPesquisar.Text, nomeproblema);
            Session["dados4"] = problemas;
            grdProblema.DataSource = problemas;
            grdProblema.DataBind();
        }

        protected void grdProblema_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var problemas = (List<Classes.Problema>)Session["dados4"];

            if (e.CommandName == "MarcarConcluido")
            {
                new Negocio.Problema().MarcarConcluido(problemas[index].Id);
                Response.Redirect("ChamadoSuporte.aspx");
            }

        }
    }
}