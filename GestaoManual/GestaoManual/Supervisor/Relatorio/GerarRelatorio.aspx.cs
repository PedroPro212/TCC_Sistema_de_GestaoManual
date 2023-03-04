using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Relatorio
{
    public partial class GerarRelatorio : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            btnGerar.Enabled = false;
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=RelatorioProducao.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdRelatorio.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void grdRelatorio_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdRelatorio_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = cldInicio.SelectedDate.Date;
            DateTime dataFim = cldFinal.SelectedDate.Date;

            if(dataFim < dataInicio)
            {
                SiteMaster.AlertPersonalizado(this, "A data do calendário de Finalização é menor que a do calendário de Início! \nRevise sua consulta");
            }
            else
            {
                btnGerar.Enabled = true;
                var relatorio = new Negocio.Relatorio().Read(dataInicio.Date, dataFim.Date);
                grdRelatorio.DataSource = relatorio;
                grdRelatorio.DataBind();
            }
        }
    }
}