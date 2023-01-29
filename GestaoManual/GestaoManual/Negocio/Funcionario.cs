using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Funcionario
    {
        private MySqlConnection connection;

        public Funcionario()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public bool Create(Classes.Funcionario funcionario)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"INSERT INTO funcionarios (nome, data_nascimento, cpf, email, tel, id_setor) VALUES(@nome, @data_nascimento, @cpf, @email, @tel, @id_setor)", connection);
                comando.Parameters.Add(new MySqlParameter("nome", funcionario.Nome));
                comando.Parameters.Add(new MySqlParameter("data_nascimento", funcionario.DataN));
                comando.Parameters.Add(new MySqlParameter("cpf", funcionario.Cpf));
                comando.Parameters.Add(new MySqlParameter("email", funcionario.Email));
                comando.Parameters.Add(new MySqlParameter("tel", funcionario.Tel));
                comando.Parameters.Add(new MySqlParameter("id_setor", funcionario.Setor));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}