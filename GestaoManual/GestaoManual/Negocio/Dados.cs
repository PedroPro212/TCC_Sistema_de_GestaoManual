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
        //public bool Dados(Classes.Dados dados)
        //{
        //    int id = HttpSessionStateBase
        //    try
        //    {
        //        connection.Open();
        //        var comando = new MySqlCommand($"SELECT id, nome, data_nascimento, cpf, email, tel, id_setor FROM funcionarios WHERE id={}")
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}