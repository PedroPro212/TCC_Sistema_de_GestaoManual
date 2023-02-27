using MySqlConnector;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class GridMaquina
    {
        private MySqlConnection connection;
        public GridMaquina()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public List<Classes.GridMaquina> Read(string maquina, int setor, string operador) 
        {
            var gridmaquinas = new List<Classes.GridMaquina>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT m.id AS mId, m.nome AS mNome, s.id AS sId, s.descricao AS sNome, o.registro AS oId, f.nome AS fNome FROM maquina AS m, setor AS s, operador AS o, funcionarios AS f WHERE m.id = o.idMaquina AND m.id_setor = s.id AND o.registro = f.id", connection);
                if (maquina.Equals("") == false)
                {
                    comando.CommandText += $" AND m.nome like @maquina";
                    comando.Parameters.Add(new MySqlParameter("maquina", $"%{maquina}%"));
                }
                if (setor != 0)
                {
                    comando.CommandText += $" AND s.id = @setor";
                    comando.Parameters.Add(new MySqlParameter("setor", setor));
                }
                if (operador.Equals("") == false)
                {
                    comando.CommandText += $" AND f.nome like @operador";
                    comando.Parameters.Add(new MySqlParameter("operador", $"%{operador}%"));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    gridmaquinas.Add(new Classes.GridMaquina
                    {
                        IdMaquina = reader.GetInt32("mId"),
                        NomeMaquina = reader.GetString("mNome"),
                        IdSetor = reader.GetInt32("sId"),
                        NomeSetor = reader.GetString("sNome"),
                        IdOperador = reader.GetInt32("oId"),
                        NomeOperador = reader.GetString("fNome")
                    });
                }
            }
            catch(Exception e)
            {
               
            }
            finally
            {
                connection.Close();
            }
            return gridmaquinas;
        }
    }
}