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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdicionarMaquina.aspx");
        }

        protected void btnProdutividade_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produtividade.aspx");
        }
    }
}