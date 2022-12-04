using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class TecnicoQualidade
    {
        private MySqlConnection connection;
        public TecnicoQualidade()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.TecnicoQualidade Read(string id)
        {
            return this.Read(id, "", "", "").FirstOrDefault();
        }

        public List<Classes.TecnicoQualidade> Read(string id, string nome, string registro, string senha)
        {
            var tecnicos = new List<Classes.TecnicoQualidade>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT nome, registro, senha id FROM tecnicoqualidade WHERE (1=1) ", connection);
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
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    tecnicos.Add(new Classes.TecnicoQualidade
                    {
                        Nome = reader.GetString("nome"),
                        Registro = reader.GetString("registro"),
                        Senha = reader.GetString("senha"),
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
            return tecnicos;
        }

        public bool Create(Classes.TecnicoQualidade tecnicoqualidade)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO tecnicoqualidade (nome, registro, senha) VALUES (@nome, @registro, @senha)", connection);
                comando.Parameters.Add(new MySqlParameter("nome", tecnicoqualidade.Nome));
                comando.Parameters.Add(new MySqlParameter("registro", tecnicoqualidade.Registro));
                comando.Parameters.Add(new MySqlParameter("senha", tecnicoqualidade.Senha));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.TecnicoQualidade tecnicoqualidade)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE tecnicoqualidade SET nome = @nome, registro = @registro, senha = @senha WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("nome", tecnicoqualidade.Nome));
                comando.Parameters.Add(new MySqlParameter("registro", tecnicoqualidade.Registro));
                comando.Parameters.Add(new MySqlParameter("senha", tecnicoqualidade.Senha));
                comando.Parameters.Add(new MySqlParameter("id", tecnicoqualidade.Id));
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
                var comando = new MySqlCommand("DELETE FROM tecnicoqualidade WHERE id = " + id, connection);
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