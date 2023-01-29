//using MySqlConnector;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace GestaoManual.Negocio
//{
//    public class Encarregado
//    {
//        private MySqlConnection connection;
//        public Encarregado()
//        {
//            connection = new MySqlConnection(SiteMaster.ConnectionString);
//        }

//        public Classes.Encarregado Read(string id)
//        {
//            return this.Read(id, "", "", "","").FirstOrDefault();
//        }

//        public List<Classes.Encarregado> Read(string id, string nome, string registro, string senha, string idSetor)
//        {
//            var encarregados = new List<Classes.Encarregado>();
//            try
//            {
//                connection.Open();
//                var comando = new MySqlCommand($"SELECT nome, registro, senha, idSetor, id FROM encarregado WHERE (1=1) ", connection);
//                if (nome.Equals("") == false)
//                {
//                    comando.CommandText += $" AND nome like @nome";
//                    comando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
//                }
//                if (registro.Equals("") == false)
//                {
//                    comando.CommandText += $" AND registro like @registro";
//                    comando.Parameters.Add(new MySqlParameter("registro", $"%{registro}%"));
//                }
//                if (senha.Equals("") == false)
//                {
//                    comando.CommandText += $" AND senha like @senha";
//                    comando.Parameters.Add(new MySqlParameter("senha", $"%{senha}%"));
//                }
//                if (idSetor.Equals("") == false)
//                {
//                    comando.CommandText += $" AND idSetor like @idSetor";
//                    comando.Parameters.Add(new MySqlParameter("idSetor", $"%{idSetor}%"));
//                }
//                if (id.Equals("") == false)
//                {
//                    comando.CommandText += $" AND id = @id";
//                    comando.Parameters.Add(new MySqlParameter("id", id));
//                }
//                var reader = comando.ExecuteReader();
//                while (reader.Read())
//                {
//                    encarregados.Add(new Classes.Encarregado
//                    {
//                        Nome = reader.GetString("nome"),
//                        Registro = reader.GetString("registro"),
//                        Senha = reader.GetString("senha"),
//                        IdSetor = reader.GetInt32("idSetor"),
//                        Id = reader.GetInt32("id")
//                    });
//                }
//            }
//            catch
//            {

//            }
//            finally
//            {
//                connection.Close();
//            }
//            return encarregados;
//        }

//        public bool Create(Classes.Encarregado encarregado)
//        {
//            try
//            {
//                connection.Open();
//                var comando = new MySqlCommand($@"INSERT INTO encarregado (nome, registro, senha, idSetor) VALUES (@nome, @registro, @senha, @idSetor)", connection);
//                comando.Parameters.Add(new MySqlParameter("nome", encarregado.Nome));
//                comando.Parameters.Add(new MySqlParameter("registro", encarregado.Registro));
//                comando.Parameters.Add(new MySqlParameter("senha", encarregado.Senha));
//                comando.Parameters.Add(new MySqlParameter("idSetor", encarregado.IdSetor));
//                comando.ExecuteNonQuery();
//                connection.Close();
//            }
//            catch
//            {
//                return false;
//            }
//            return true;
//        }

//        public bool Update(Classes.Encarregado encarregado)
//        {
//            try
//            {
//                connection.Open();
//                var comando = new MySqlCommand($@"UPDATE encarregado SET nome = @nome, registro = @registro, senha = @senha, idSetor = @idSetor WHERE id = @id", connection);
//                comando.Parameters.Add(new MySqlParameter("nome", encarregado.Nome));
//                comando.Parameters.Add(new MySqlParameter("registro", encarregado.Registro));
//                comando.Parameters.Add(new MySqlParameter("senha", encarregado.Senha));
//                comando.Parameters.Add(new MySqlParameter("idSetor", encarregado.IdSetor));
//                comando.Parameters.Add(new MySqlParameter("id", encarregado.Id));
//                comando.ExecuteNonQuery();
//                connection.Close();
//            }
//            catch
//            {
//                return false;
//            }
//            return true;
//        }

//        public bool Delete(int id)
//        {
//            try
//            {
//                connection.Open();
//                var comando = new MySqlCommand("DELETE FROM encarregado WHERE id = " + id, connection);
//                comando.ExecuteNonQuery();
//                connection.Close();
//            }
//            catch
//            {
//                return false;
//            }
//            return true;
//        }
//    }
//}