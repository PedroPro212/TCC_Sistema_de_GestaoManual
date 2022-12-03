using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GestaoManual.Negocio
{
    public class Setor
    {
        private MySqlConnection connection;
        public Setor()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.Setor Read(string id)
        {
            return this.Read(id, "").FirstOrDefault();
        }


        public List<Classes.Setor> Read(string id, string descricao)
        {
            var setores = new List<Classes.Setor>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT descricao, id FROM setor WHERE (1=1) ", connection);
                if (descricao.Equals("") == false)
                {
                    comando.CommandText += $" AND descricao like @descricao";
                    comando.Parameters.Add(new MySqlParameter("descricao", $"%{descricao}%"));
                }
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    setores.Add(new Classes.Setor
                    {
                        Descricao = reader.GetString("descricao"),
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
            return setores;
        }

        public bool Create(Classes.Setor setor)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO setor (descricao) VALUES (@descricao)", connection);
                comando.Parameters.Add(new MySqlParameter("descricao", setor.Descricao));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.Setor setor)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE setor SET descricao = @descricao WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("descricao", setor.Descricao));
                comando.Parameters.Add(new MySqlParameter("id", setor.Id));
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
                var comando = new MySqlCommand("DELETE FROM setor WHERE id = " + id, connection);
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