using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Dados
    {
        private MySqlConnection connection;
        public Dados() 
        { 
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }
        
    }
}