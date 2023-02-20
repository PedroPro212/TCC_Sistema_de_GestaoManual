using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Producao
    {
        private MySqlConnection connection;
        public Producao()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public bool FinalizarProcesso(Classes.Producao producao)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"INSERT INTO processo (id_produto, datahoraIni, datahoraFin, NPecas, NPecasBoas, lotePecas, idOperador, id_setor, idMaquina, loteTinta) VALUES (@id_produto, @datahoraIni, @datahoraFin, @NPecas, @NPecasBoas, @lotePecas, @idOperador, @id_setor, @idMaquina, @loteTinta)", connection);
                comando.Parameters.Add(new MySqlParameter("id_produto", producao.IdProduto));
                comando.Parameters.Add(new MySqlParameter("datahoraIni", producao.DataHoraIni));
                comando.Parameters.Add(new MySqlParameter("datahoraFin", producao.DataHoraFin));
                comando.Parameters.Add(new MySqlParameter("NPecas", producao.NumPecas));
                comando.Parameters.Add(new MySqlParameter("NPecasBoas", producao.NumPecasBoas));
                comando.Parameters.Add(new MySqlParameter("lotePecas", producao.LotePecas));
                comando.Parameters.Add(new MySqlParameter("idOperador", producao.IDOperador));
                comando.Parameters.Add(new MySqlParameter("id_setor", producao.IdSetor));
                comando.Parameters.Add(new MySqlParameter("idMaquina", producao.IDMaquina));
                comando.Parameters.Add(new MySqlParameter("loteTinta", producao.LoteTinta));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}