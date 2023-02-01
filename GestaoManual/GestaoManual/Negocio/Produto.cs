using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Produto
    {
        private MySqlConnection connection;
        public Produto()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public bool Create(Classes.Produto produto)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"INSERT INTO produto (descricao) VALUES(@descricao)", connection);
                comando.Parameters.Add(new MySqlParameter("descricao", produto.Descricao));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Classes.Produto> Read(string descricao)
        {
            var produtos = new List<Classes.Produto>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT id, descricao FROM produto WHERE (1=1)", connection);
                if (descricao.Equals("") == false)
                {
                    comando.CommandText += $" AND descricao like @descricao";
                    comando.Parameters.Add(new MySqlParameter("descricao", $"%{descricao}%"));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    produtos.Add(new Classes.Produto
                    {
                        Id = reader.GetInt32("id"),
                        Descricao = reader.GetString("descricao")
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
            return produtos;
        }

        public bool Delete(int id)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand("DELETE FROM produto WHERE id = " + id, connection);
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