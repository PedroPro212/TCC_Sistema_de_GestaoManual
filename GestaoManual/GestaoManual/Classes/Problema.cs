using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class Problema
    {
        public int Id { get; set; }
        public int IdRegistro { get; set; }
        public int IdSetor { get; set; }
        public string NomeProblema { get; set; }
        public string Descricao { get; set; }
        public string DataEnvio { get; set; }
        public bool Resolvido { get; set; }
    }
}