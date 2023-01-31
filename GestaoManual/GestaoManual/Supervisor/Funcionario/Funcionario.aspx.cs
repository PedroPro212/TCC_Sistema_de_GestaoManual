using System;
using System.Collections.Generic;
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
        }
    }
}