using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Operador
    {
        private MySqlConnection connection;

        public Operador()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public bool Create(Classes.Operador operador)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"INSERT INTO operador(registro, idSetor, idMaquina) " +
                                               $"VALUES (@registro, @idSetor, @idMaquina)", connection);
                comando.Parameters.Add(new MySqlParameter("registro", operador.IdRegistro));
                comando.Parameters.Add(new MySqlParameter("idSetor", operador.IdSetor));
                comando.Parameters.Add(new MySqlParameter("idMaquina", operador.IdMaquina));
                
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)//verificar foreign key idsetor
            {
                return false;
            }
            return true;
        }
    }
}