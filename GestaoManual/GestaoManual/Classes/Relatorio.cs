using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Relatorio
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public string Produto { get; set; }
        public int QtsPecas  { get; set; }
        public int TotalPecasBoas  { get; set; }
        public string LotePecas  { get; set; }
        public string LoteTinta  { get; set; }
        public string Setor { get; set; }
        public string Maquina { get; set; }
    }
}