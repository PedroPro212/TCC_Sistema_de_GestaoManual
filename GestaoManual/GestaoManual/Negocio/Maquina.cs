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

        public Classes.Maquina Read(int setor)
        {
            return this.Read(setor, "", Convert.ToInt32("")).FirstOrDefault();
        }


        public List<Classes.Maquina> Read(int id, string nome, int setor)
        {
            var maquinas = new List<Classes.Maquina>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"SELECT ma.id, ma.nome, id_setor, se.id, se.descricao 
                                                    FROM maquina as ma, setor as se
                                                    WHERE ma.id_setor = se.id AND ma.id = {setor}", connection);
                if (nome.Equals("") == false)
                {
                    comando.CommandText += $" AND tipo like @nome";
                    comando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
                }
                if (setor.Equals("") == false)
                {
                    comando.CommandText += $" AND setor = @setor";
                    comando.Parameters.Add(new MySqlParameter("setor", setor));
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
                        Nome = reader.GetString("nome"),
                        Setor = reader.GetString("descricao"),
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
                var comando = new MySqlCommand($@"INSERT INTO maquina (nome, id_setor, id_encarregado) VALUES (@nome, @id_setor, @id_encarregado)", connection);
                comando.Parameters.Add(new MySqlParameter("nome", maquina.Nome));
                comando.Parameters.Add(new MySqlParameter("id_setor", maquina.idSetor));
                comando.Parameters.Add(new MySqlParameter("id_encarregado", maquina.idEncarregado));
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
                //comando.Parameters.Add(new MySqlParameter("tipo", maquina.Tipo));
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