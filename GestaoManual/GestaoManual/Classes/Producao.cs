using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Producao
    {
        public int ID { get; set; }
        public int IdSetor  { get; set;}
        public int IdProduto { get; set; }
        public string CdBarrasIdentificacao { get;set; }
        public int IDOperador  { get; set;}
        public string IDMaquina  { get; set;}
        public DateTime DataHoraIni  { get; set;}
        public DateTime DataHoraFin  { get; set;}
        public int NumPecas  { get; set;}
        public int NumPecasBoas { get; set;}
        public string LotePecas  { get; set;}
        public string LoteTinta  { get; set;}
    }
}