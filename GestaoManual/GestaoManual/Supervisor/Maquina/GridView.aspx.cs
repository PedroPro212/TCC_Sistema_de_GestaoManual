using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Maquina
{
    public partial class GridView : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                connection.Open();
                ddlSetor.Items.Clear();
                var reader = new MySqlCommand($"SELECT id, descricao FROM setor WHERE id!=0", connection).ExecuteReader();
                while (reader.Read())
                {
                    var setor = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }
                connection.Close();
            }
        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdicionarMaquina.aspx");
        }

        protected void btnProdutividade_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produtividade.aspx");
        }

        protected void grdMaquina_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Redirect("DadosMaquina.aspx");
        }

        protected void grdMaquina_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#171f25'; this.style.cursor='hand';");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#212529'");
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int setor = Convert.ToInt32(ddlSetor.SelectedValue);
            var maquina = new Negocio.Maquina().Read(Convert.ToInt32(""), "", setor);
            grdMaquina.DataSource= maquina;
            grdMaquina.DataBind();
        }
    }
}