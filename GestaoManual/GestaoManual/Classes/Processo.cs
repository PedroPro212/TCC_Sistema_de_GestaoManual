using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Processo
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public DateTime Datahora { get; set; }
        public int NoPecas { get; set; }
        public string LotePecas { get; set; }
        public int IdOperador { get; set; }
        public string EtapaProcesso { get; set; }
        public int IdMaquina { get; set; }
        public string LoteTinta { get; set; }
    }
}