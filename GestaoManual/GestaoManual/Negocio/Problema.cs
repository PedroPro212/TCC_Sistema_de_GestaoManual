using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Problema
    {
        private MySqlConnection connection;
        public Problema()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public bool Create(Classes.Problema problema)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"INSERT INTO suporte(idRegistro, idSetor, dataEnvio, problema, descricao, resolvido) " +
                                               $"VALUES (@idRegistro,@setor,NOW(),@problema,@descricao,false)", connection);
                comando.Parameters.Add(new MySqlParameter("idRegistro", problema.IdRegistro));
                comando.Parameters.Add(new MySqlParameter("setor", problema.IdSetor));
                comando.Parameters.Add(new MySqlParameter("problema", problema.NomeProblema));
                comando.Parameters.Add(new MySqlParameter("descricao", problema.Descricao));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Classes.Problema> Read(int setor, string registro, string nomeproblema)
        {
            var problemas = new List<Classes.Problema>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT * FROM suporte WHERE resolvido = 0", connection);
                if (registro.Equals("") == false)
                {
                    comando.CommandText += $" AND idRegistro = @registro";
                    comando.Parameters.Add(new MySqlParameter("registro", registro));
                }
                if (nomeproblema.Equals("") == false)
                {
                    comando.CommandText += $" AND problema = @problema";
                    comando.Parameters.Add(new MySqlParameter("problema", $"%{nomeproblema}%"));
                }
                if (setor!=0)
                {
                    comando.CommandText += $" AND idSetor = @setor";
                    comando.Parameters.Add(new MySqlParameter("setor", setor));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    problemas.Add(new Classes.Problema
                    {
                        Id = reader.GetInt32("id"),
                        DataEnvio = reader.GetDateTime("dataEnvio").ToString("dd/MM/yyyy"),
                        IdRegistro = reader.GetInt32("idRegistro"),
                        IdSetor = reader.GetInt32("idSetor"),
                        NomeProblema = reader.GetString("problema"),
                        Descricao = reader.GetString("descricao"),
                        Resolvido = reader.GetBoolean("resolvido")
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
            return problemas;
        }

        public bool MarcarConcluido(int id)
        {
            try 
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE suporte SET resolvido = 1 WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("id", id));
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