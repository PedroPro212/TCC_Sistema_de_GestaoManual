using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
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
                var setor = new ListItem("Escolher Setor", "0");
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
            /*if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#171f25'; this.style.cursor='hand';");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#212529'");
            }*/
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int setor = Convert.ToInt32(ddlSetor.SelectedValue);
            var gridmaquina = new Negocio.GridMaquina().Read(txtPesquisar.Text, setor, txtPesquisarOp.Text);
            Session["dados2"] = gridmaquina;
            grdMaquina.DataSource= gridmaquina;
            grdMaquina.DataBind();
            btnExportarExcel.Enabled = true;
        }

        protected void ddlSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPesquisar_Click(null, null);
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=UserInfo.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdMaquina.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}