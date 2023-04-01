using MySqlConnector;
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
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("../../Login/index.aspx");
            }
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

            var reader = new MySqlCommand("SELECT COUNT(descricao) AS qts FROM produto", connection);

            try
            {
                connection.Open();
                lblQTS.Text = "";
                MySqlDataReader dataReader;
                dataReader = reader.ExecuteReader();
                while (dataReader.Read())
                {
                    lblQTS.Text += dataReader.GetInt32("qts");
                }
            }
            catch
            {

            }
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