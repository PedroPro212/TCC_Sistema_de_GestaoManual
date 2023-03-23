using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Login
    {
        private MySqlConnection connection;
        public Login()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

    }
}