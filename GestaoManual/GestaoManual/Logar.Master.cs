using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual
{
    public partial class Logar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void AlertPersonalizado(Page page, string mensagem)
        {
            page.ClientScript.RegisterStartupScript(
                page.GetType(),
                "MessageBox" + Guid.NewGuid(),
                "<script language='javascript'>swal('" + mensagem + "');</script>"
                );
        }

        public static void AlertPersonalizado(Page page, string mensagem, string pagina)
        {
            page.ClientScript.RegisterStartupScript(
                page.GetType(),
                "MessageBox" + Guid.NewGuid(),
                "<script language='javascript'>swal('" + mensagem + "');window.location = '" + pagina + "'</script>"
                );
        }
    }
}