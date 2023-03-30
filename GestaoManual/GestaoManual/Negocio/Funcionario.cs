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

        public List<Classes.Funcionario> Read(string id, string nome, string email)
        {
            var funcionarios = new List<Classes.Funcionario>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT f.nome, f.data_nascimento, f.cpf, f.email, f.tel, f.id_setor, f.id, s.descricao FROM funcionarios AS f, setor AS s WHERE f.id_setor = s.id", connection);
                if (nome.Equals("") == false)
                {
                    comando.CommandText += $" AND f.nome like @nome";
                    comando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
                }
                if (email.Equals("") == false)
                {
                    comando.CommandText += $" AND f.email = @email";
                    comando.Parameters.Add(new MySqlParameter("email", $"%{email}%"));
                }
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND f.id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    funcionarios.Add(new Classes.Funcionario
                    {
                        Nome = reader.GetString("nome"),
                        DataN = reader.GetDateTime("data_nascimento").ToString("dd/MM/yyyy"),
                        Cpf = reader.GetString("cpf"),
                        Email = reader.GetString("email"),
                        Tel = reader.GetString("tel"),
                        Setor = reader.GetInt32("id_setor"),
                        Id = reader.GetInt32("id"),
                        NomeSetor = reader.GetString("descricao")
                    });
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return funcionarios;
        }
    }
}