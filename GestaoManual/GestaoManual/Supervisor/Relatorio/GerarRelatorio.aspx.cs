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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            DateTime DataInicio = cldInicio.SelectedDate;
            DateTime DataFinal = cldFinal.SelectedDate;
        }
    }
}