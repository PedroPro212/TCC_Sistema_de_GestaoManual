using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual.Producao.PinturaImersao
{
    public partial class PinturaImersao : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connection.Open();
                ddlProduto.Items.Clear();
                var reader = new MySqlCommand("SELECT id, descricao, id_setor FROM produto WHERE id_setor=2 AND id!=0", connection).ExecuteReader();
                while(reader.Read())
                {
                    var produtos = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());
                    ddlProduto.Items.Add(produtos);
                }
                connection.Close();
            }
        }

        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ddl = Convert.ToInt32(ddlProduto.SelectedItem.Value);
            if (!IsPostBack)
            {
                connection.Open();
                switch (ddl)
                {
                    case 1:
                        imgProduto.ImageUrl = "/imgsproducao/dobradicas.png";
                        break;

                    case 2:
                        imgProduto.ImageUrl = "/imgsproducao/correio.png";
                        break;
                }
                connection.Close();
            }
        }
    }
}