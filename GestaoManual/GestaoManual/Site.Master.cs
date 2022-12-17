﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoManual
{
    public partial class SiteMaster : MasterPage
    {
        public static string ConnectionString = "Server=127.0.0.1;User ID=root;Password=;Database=metalurgicasaveiro";   //Filipe e Pedro Note
        //public static string ConnectionString = "Server=127.0.0.1;User ID=root;Password=1234;Database=metalurgicasaveiro";  // Computador Pedro
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