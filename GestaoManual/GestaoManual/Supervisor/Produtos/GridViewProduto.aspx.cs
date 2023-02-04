using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Supervisor.Produtos
{
    public partial class GridViewProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdicionarProduto.aspx");
        }
        
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var produtos = new Negocio.Produto().Read(txtPesquisar.Text);
            Session["dados3"] = produtos;
            grdProduto.DataSource = produtos;
            grdProduto.DataBind();
        }

        protected void grdProduto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var produtos = (List<Classes.Produto>)Session["dados3"];

            if (e.CommandName == "excluir")
            {
                new Negocio.Produto().Delete(produtos[index].Id);
                Response.Redirect("GridViewProduto.aspx");
            }
        }
    }
}