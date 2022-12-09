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

        public Classes.Operador Read(string id)
        {
            return this.Read(id, "","","","").FirstOrDefault();
        }

        public List<Classes.Operador> Read(string id, string nome, string registro, string senha, string idSetor)
        {
            var operadores = new List<Classes.Operador>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT nome, registro, senha, idSetor id FROM operador WHERE (1=1) ", connection);
                if (nome.Equals("") == false)
                {
                    comando.CommandText += $" AND nome like @nome";
                    comando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
                }
                if (registro.Equals("") == false)
                {
                    comando.CommandText += $" AND registro like @registro";
                    comando.Parameters.Add(new MySqlParameter("registro", $"%{registro}%"));
                }
                if (senha.Equals("") == false)
                {
                    comando.CommandText += $" AND senha like @senha";
                    comando.Parameters.Add(new MySqlParameter("senha", $"%{senha}%"));
                }
                if (idSetor.Equals("") == false)
                {
                    comando.CommandText += $" AND idSetor = @idSetor";
                    comando.Parameters.Add(new MySqlParameter("idSetor", idSetor));
                }
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    operadores.Add(new Classes.Operador
                    {
                        Nome = reader.GetString("nome"),
                        Registro = reader.GetString("registro"),
                        Senha = reader.GetString("senha"),
                        IdSetor = reader.GetInt32("idSetor"),
                        Id = reader.GetInt32("id")
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
            return operadores;
        }

        public bool Create(Classes.Operador operador)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO operador (nome, registro, senha, idSetor) VALUES (@nome, @registro, @senha, @idSetor)", connection);
                comando.Parameters.Add(new MySqlParameter("nome", operador.Nome));
                comando.Parameters.Add(new MySqlParameter("registro", operador.Registro));
                comando.Parameters.Add(new MySqlParameter("senha", operador.Senha));
                comando.Parameters.Add(new MySqlParameter("idSetor", operador.IdSetor));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.Operador operador)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE operador SET nome = @nome, registro = @registro, senha = @senha, idSetor = @idSetor WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("nome", operador.Nome));
                comando.Parameters.Add(new MySqlParameter("registro", operador.Registro));
                comando.Parameters.Add(new MySqlParameter("senha", operador.Senha));
                comando.Parameters.Add(new MySqlParameter("idSetor", operador.IdSetor));
                comando.Parameters.Add(new MySqlParameter("id", operador.Id));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand("DELETE FROM operador WHERE id = " + id, connection);
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