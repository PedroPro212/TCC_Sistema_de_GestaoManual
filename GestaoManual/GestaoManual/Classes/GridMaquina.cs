using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoManual.Classes
{
    public class GridMaquina
    {
        public int IdMaquina { get; set; }
        public string NomeMaquina { get; set; }
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public int IdOperador { get; set; }
        public string NomeOperador { get; set; }
    }
}