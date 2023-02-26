using MySqlConnector;
using System;
using System.Collections.Generic;
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

        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            DateTime DataInicio = cldInicio.SelectedDate;
            DateTime DataFinal = cldFinal.SelectedDate;


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
            var relatorio = new Negocio.Relatorio().Read(dataInicio, dataFim);
            grdRelatorio.DataSource = relatorio;
            grdRelatorio.DataBind();
        }
    }
}