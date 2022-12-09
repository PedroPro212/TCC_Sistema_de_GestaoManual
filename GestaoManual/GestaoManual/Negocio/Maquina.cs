using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Maquina
    {
        private MySqlConnection connection;
        public Maquina()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.Maquina Read(string id)
        {
            return this.Read(id, "").FirstOrDefault();
        }


        public List<Classes.Maquina> Read(string id, string tipo)
        {
            var maquinas = new List<Classes.Maquina>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT tipo, id FROM maquina WHERE (1=1) ", connection);
                if (tipo.Equals("") == false)
                {
                    comando.CommandText += $" AND tipo like @tipo";
                    comando.Parameters.Add(new MySqlParameter("tipo", $"%{tipo}%"));
                }
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    maquinas.Add(new Classes.Maquina
                    {
                        Tipo = reader.GetString("tipo"),
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
            return maquinas;
        }

        public bool Create(Classes.Maquina maquina)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO maquina (id , tipo) VALUES (@id, @tipo)", connection);
                comando.Parameters.Add(new MySqlParameter("id", maquina.Id));
                comando.Parameters.Add(new MySqlParameter("tipo", maquina.Tipo));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.Maquina maquina)
        {
            try //***
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE maquina SET tipo = @tipo WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("tipo", maquina.Tipo));
                comando.Parameters.Add(new MySqlParameter("id", maquina.Id));
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
                var comando = new MySqlCommand("DELETE FROM maquina WHERE id = " + id, connection);
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