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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click()
        {
            //int setor = Convert.ToInt32(ddlSetor.SelectedValue);
            var problemas = new Negocio.Problema().Read(0,"","");
            Session["dados4"] = problemas;
            grdProblema.DataSource = problemas ;
            grdProblema.DataBind();
        }

        protected void grdProblema_RowCommand()
        {

        }
    }
}