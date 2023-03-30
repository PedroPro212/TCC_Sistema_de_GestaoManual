using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GestaoManual.Supervisor.Funcionario
{
    public partial class Funcionario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCriarFuncionario_Click(object sender, EventArgs e)
        {
            Response.Redirect("CriarFuncionario.aspx");
        }

        protected void grdFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdFuncionario_DataBound(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var funcionarios = new Negocio.Funcionario().Read("", txtPesquisar.Text, "");
            Session["dados"] = funcionarios;
            grdFuncionario.DataSource = funcionarios;
            grdFuncionario.DataBind();
            btnExportarExcel.Enabled = true;
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType= "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=UserInfo.xls");
            Response.Charset= "";
            StringWriter sw = new StringWriter(); 
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdFuncionario.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}