using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Relatorio
    {
        private MySqlConnection connection;
        public Relatorio()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public List<Classes.Relatorio> Read(DateTime dataInicio, DateTime dataFim)
        {
            var grdRelatorio = new List<Classes.Relatorio>();
            var sqlDataIni = dataInicio.ToString("yyyy-MM-dd");
            var sqlDataFim = dataFim.ToString("yyyy-MM-dd");

            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"SELECT pro.descricao AS produto, datahoraIni, datahoraFin, NPecas, NPecasBoas, lotePecas, se.descricao AS setor, idMaquina, loteTinta 
                                                    FROM processo, produto as pro, setor as se 
                                                    WHERE DATE(datahoraIni) BETWEEN '{sqlDataIni}' AND '{sqlDataFim}' AND id_produto = pro.id AND id_setor = se.id AND se.id = 0=0", connection);

                //comando.CommandText += " AND datahoraIni = @dataInicio";
                //comando.Parameters.Add(new MySqlParameter("dataInicio", dataInicio));


                //comando.CommandText += " AND datahoraFin = @dataFim";
                //comando.Parameters.Add(new MySqlParameter("dataFim", dataFim));

                var reader = comando.ExecuteReader();
                while(reader.Read())
                {
                    grdRelatorio.Add(new Classes.Relatorio
                    {
                        DataInicio = reader.GetDateTime("datahoraIni"),
                        DataFinal = reader.GetDateTime("datahoraFin"),
                        Produto = reader.GetString("produto"),
                        QtsPecas = reader.GetInt32("NPecas"),
                        TotalPecasBoas = reader.GetInt32("NPecasBoas"),
                        LotePecas = reader.GetString("lotePecas"),
                        Setor = reader.GetString("setor"),
                        Maquina = reader.GetString("idMaquina"),
                        LoteTinta = reader.GetString("loteTinta")
                    });
                }
            }
            catch(Exception ex)
            {
                string bo = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return grdRelatorio;
        }
    }
}